using FruitableShop.Models;
using FruitableShop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace FruitableShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private IRepository<User> _userRepository;
        private UserDetailFactory _userDetailFactory;
        public UserController(IRepository<User> userRepository, UserDetailFactory userDetailFactory)
        {
            _userRepository = userRepository;
            _userDetailFactory = userDetailFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<User> users = _userRepository.GetAll();
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
        [HttpGet]
        public IActionResult Detail(int id)
        {
            // ========== sử dụng singleton ========== //
            var userDetailRepo1 = _userDetailFactory.CreateUserDetailRepository();
            var userDetailRepo2 = _userDetailFactory.CreateUserDetailRepository();
            var userDetailRepo3 = _userDetailFactory.CreateUserDetailRepository();

            // Thiết lập thông tin đối tượng
            userDetailRepo1.ObjName = "User 1";
            userDetailRepo2.ObjName = "User 2";
            userDetailRepo3.ObjName = "User 3";

            userDetailRepo1.ShowInformation("Object 1");
            userDetailRepo2.ShowInformation("Object 2");
            userDetailRepo3.ShowInformation("Object 3");

            User user = userDetailRepo1.FindById(id);

            if (user != null)
            {
                return View(user);
            }

            return NotFound();
        }
    }
}
