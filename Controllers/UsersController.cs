using System.Data;
using FastfoodCenter.Data;
using FastfoodCenter.Entities.Models;
using FastfoodCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastfoodCenter.Controllers
{
    [Route("api/v1/FastfoodCenterApi/[controller]")]
    public class UsersController : Controller
    {
        private FastfoodCenterContext _context = new FastfoodCenterContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new FastfoodCenterContext());

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _unitOfWork.Users.Get();
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("id")]
        public IActionResult GetUserById(int id)
        {
            User user = _unitOfWork.Users.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }
            else 
            {
                return BadRequest("No user found for this Id");
            }
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Users.Update(user);
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
                _unitOfWork.Users.Delete(id);
                _unitOfWork.Save();
                return Ok("user successfully deleted");
            }
            else
            {
                return BadRequest("Bad user id");
            }
        }
    }
}