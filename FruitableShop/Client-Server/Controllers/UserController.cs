using Client_Server.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Client_Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly FruitableStoreContext _ctx;

        public UserController(FruitableStoreContext ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var users = _ctx.Users.ToList();
                if (users.Count == 0)
                {
                    return NotFound("User not available");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var users = _ctx.Users.Find(id);
                if (users == null)
                {
                    return NotFound($"User details not found with {id}");
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(User users)
        {
            try
            {
                _ctx.Users.Add(users);
                _ctx.SaveChanges();

                return Ok("User created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            ;
        }

        [HttpPut]
        public IActionResult Put(User model)
        {
            if (model == null || model.Id == 0)
            {
                if (model == null)
                {
                    return BadRequest("Model data is invalid");
                }
                else if (model.Id == 0)
                {
                    return BadRequest($"User Id {model.Id} is invalid");
                }
            }

            try
            {
                var users = _ctx.Users.Find(model.Id);
                if (users == null)
                {
                    return NotFound($"User not found with id {model.Id}");
                }
                users.Username = model.Username;
                users.Email = model.Email;
                users.Address = model.Address;
                users.Phone = model.Phone;
                users.Password = model.Password;
                _ctx.SaveChanges();
                return Ok("User details updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var users = _ctx.Users.Find(id);
                if (users == null)
                {
                    return NotFound($"User not found {id}");
                }
                _ctx.Users.Remove(users);
                _ctx.SaveChanges();
                return Ok("User details deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUser(string email, string password)
        {
            var user = _ctx.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("User not found with provided email and password.");
            }
        }
    }
}
