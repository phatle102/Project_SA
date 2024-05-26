using FruitableShop.Models;
using FruitableShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FruitableShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            List<User> users = _userRepository.GetAllUser();
            return View(users);
        }
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveAddUser(User user)
        {
            _userRepository.Create(user);
            return RedirectToAction("Index");
        }
        public IActionResult EditUser(int id)
        {
            return View("EditUser", _userRepository.FindById(id));
        }
        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            _userRepository.Update(user);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteUser(int id)
        {
            return View("DeleteUser", _userRepository.FindById(id));
        }
        public IActionResult ConfirmDelete(User user)
        {
            _userRepository.Delete(user.Id);
            return RedirectToAction("Index");
        }
    }
}
