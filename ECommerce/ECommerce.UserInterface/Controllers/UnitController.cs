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
    public class UnitController : ControllerBase
    {
        IUoW _u;
        GeneralResponse _response;

        public UnitController(IUoW u, GeneralResponse response)
        {
            _u = u;
            _response = response;
        }

        [HttpGet(Name = "ListOfUnits")]
        public IQueryable<UnitList> ListOfUnits()
        {
            var uList = _u._unr.GetUnitList();
            return uList;
        }

        [HttpGet("{id:int}")]
        public Unit Find_Unit(int id)
        {
            var unit = _u._unr.Find(id);
            return unit;
        }

        [HttpPost(Name = "Create_Unit")]
        public GeneralResponse Create_Unit(Unit unit)
        {
            try
            {
                _u._unr.Create(unit);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The unit numbered {unit.UnitId} has created successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Unit cannot be created! ({ex.Message})";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public Unit Delete_Unit(int id)
        {
            Unit unit = _u._unr.Find(id);
            _u._unr.Delete(unit);
            _u.Commit();
            _u.Dispose();
            return unit;
        }

        [HttpPut]
        public GeneralResponse Update_Unit(Unit unit)
        {
            try
            {
                _u._unr.Update(unit);
                _u.Commit();
                _u.Dispose();
                _response.msgSuccess = $"The unit numbered {unit.UnitId} has updated successfully.";
            }
            catch (Exception ex)
            {
                _response.msgError = $"Unit cannot deleted! ({ex.Message})";
            }
            return _response;
        }
    }
}
