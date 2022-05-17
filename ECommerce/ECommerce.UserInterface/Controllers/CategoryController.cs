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

    public class CategoryController : ControllerBase
    {
        IUoW _u;
        GeneralResponse _response;

        public CategoryController(IUoW u, GeneralResponse response)
        {
            _u = u;
            _response = response;
        }

        [HttpGet(Name = "ListOfCategories")]
        public IQueryable<CategoryList> ListOfCategories()
        {
            var cList = _u._car.GetCategoryList();
            return cList;
        }

        [HttpGet("{id:int}")]
        public GeneralResponse Find_Category(int id)
        {
            var category = _u._car.Find(id);
            if (category != null)
            {
                _response.msgSuccess = $"The category {id} numbered is exist.";
            }
            else
                _response.msgError = $"There is no a {id} numbered category.";

            return _response;
        }

        [HttpPost(Name = "Create_Category")]
        public GeneralResponse Create_Category(Category category)
        {
            try
            {
                _u._car.Create(category);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"Category numbered {category.CategoryId} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = ex.Message;
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public Category Delete_Category(int id)
        {
            Category category = _u._car.Find(id);
            _u._car.Delete(category);
            _u.Commit();
            _u.Dispose();
            return category;
        }

        [HttpPut]
        public GeneralResponse Update_Category(Category category)
        {
            try
            {
                _u._car.Update(category);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"Category numbered {category.CategoryId} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = ex.Message;
            }
            return _response;
        }
    }
}
