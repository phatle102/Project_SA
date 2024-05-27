using FruitableShop.Repository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace FruitableShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            bool isAuthenticated = await LoginRepository.Instance.Login(email, password);

            if (isAuthenticated)
            {
                // Đăng nhập thành công, thực hiện các thao tác cần thiết, ví dụ: chuyển hướng đến trang chính
                return RedirectToAction("Index", "User");
            }
            else
            {
                // Đăng nhập thất bại, hiển thị thông báo lỗi hoặc chuyển hướng đến trang đăng nhập lại
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
