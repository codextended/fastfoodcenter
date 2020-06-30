using System.Data;
using FastfoodCenter.Data;
using FastfoodCenter.Entities.Models;
using FastfoodCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastfoodCenter.Controllers
{
    [Route("api/v1/FastfoodCenterApi/[controller]")]
    public class FoodController : Controller 
    {
        private UnitOfWork _unitOfWork = new UnitOfWork(new FastfoodCenterContext());

        [HttpGet]
        public IActionResult GetAllFoods() 
        {
            var foods = _unitOfWork.Foods.Get();
            if (foods !=  null)
            {
                return Ok(foods);
            }
            else 
            {
                return Ok();
            }
        }

        [HttpGet("id")]
        public IActionResult GetFoodById(int id)
        {
            Food food = _unitOfWork.Foods.GetById(id);
            if (food != null)
            {
                return Ok(food);
            }
            else
            {
                return BadRequest("No food found for this Id.");
            }
        }

        [HttpPut]
        public IActionResult UpdateFood([FromBody] Food food)
        {
             try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Foods.Update(food);
                    _unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (DataException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteUser(int id)
        {
            if (id != 0)
            {
                _unitOfWork.Foods.Delete(id);
                _unitOfWork.Save();
                return Ok("Food successfully deleted");
            }
            else
            {
                return BadRequest("Bad Food Id.");
            }
        }
    }
}