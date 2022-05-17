using ECommerce.DTO;
using ECommerce.Entity;
using ECommerce.UnitOfWork;
using ECommerce.UserInterface.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.UserInterface.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IUoW _u;
        GeneralResponse _response;

        public ProductController(IUoW u, GeneralResponse response)
        {
            _u = u;
            _response = response;
        }

        [HttpGet(Name = "ListOfProducts")]
        public IQueryable<ProductList> ListOfProducts()
        {
            var pList = _u._pr.GetProductList();
            return pList;
        }

        [HttpGet( "{id:int}")]
        public IQueryable<ProductList> ListOfProductsByCatId(int id)
        {
            var plist = _u._pr.GetProductListByCatId(id);
            return plist;
        }

        [HttpGet("{id:int}")]
        public Product Find_Product(int id)
        {
            var product = _u._pr.Find(id);
            return product;
        }

        [HttpPost(Name = "Create_Product")]
        public GeneralResponse Create_Product(Product product)
        {
            try
            {
                _u._pr.Create(product);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The product numbered {product.ProductId} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Product cannot be created! ({ex.Message})";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public Product Delete_Product(int id)
        {
            Product product = _u._pr.Find(id);
            _u._pr.Delete(product);
            _u.Commit();
            _u.Dispose();
            return product;
        }

        [HttpPut]
        public GeneralResponse Update_Product(Product product)
        {
            try
            {
                _u._pr.Update(product);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The product numbered {product.ProductId} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Product cannot deleted! ({ex.Message})";
            }
            return _response;
        }
    }
}
