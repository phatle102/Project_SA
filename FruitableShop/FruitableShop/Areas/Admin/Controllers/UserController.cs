using FruitableShop.Models;
using FruitableShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FruitableShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private IRepository<User> _userRepository;
        public UserController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<User> users = _userRepository.GetAllUser();
            return View(users);
        }
        [HttpGet]
        public ActionResult SearchUser(string keyword)
        {
            List<User> userList = _userRepository.SearchByName(keyword);
            return View(userList);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveAddUser(User user)
        {
            if (_userRepository.Create(user))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditUser(int id)
        {
            User user = _userRepository.FindById(id);
            if (user != null)
            {
                return View(user);
            }
            return View();
        }
        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            if (_userRepository.Update(user))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult DeleteUser(int id)
        {
            User user = _userRepository.FindById(id);
            if (user != null)
            {
                return View(user);
            }
            return View();
        }
        public IActionResult ConfirmDelete(User user)
        {
            if (_userRepository.Delete(user.Id))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
