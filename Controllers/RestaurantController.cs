using System.Data;
using FastfoodCenter.Data;
using FastfoodCenter.Entities.Models;
using FastfoodCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastfoodCenter.Controllers
{
    [Route("api/v1/FastfoodCenterApi/[controller]")]
    public class RestaurantController : Controller
    {

        private UnitOfWork _unitOfWork = new UnitOfWork(new FastfoodCenterContext());
        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            var restaurants = _unitOfWork.Restaurants.Get();

            if (restaurants != null)
            {
                return Ok(restaurants);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("id")]
        public IActionResult GetRestaurantById(int id)
        {
            Restaurant restaurant = _unitOfWork.Restaurants.GetById(id);

            if (restaurant != null)
            {
                return Ok(restaurant);
            }
            else
            {
                return BadRequest("No Restaurant found for this Id.");
            }
        }

        [HttpPut]
        public IActionResult UpdateRestaurant([FromBody] Restaurant restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Restaurants.Update(restaurant);
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
        public IActionResult DeleteRestaurant(int id)
        {
            if (id != 0)
            {
                _unitOfWork.Restaurants.Delete(id);
                _unitOfWork.Save();
                return Ok("Restaurant deleted successfully.");
            }
            else 
            {
                return BadRequest("Bad Restaurant Id.");
            }
        } 
    }
}