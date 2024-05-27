using NuGet.Protocol.Plugins;

namespace FruitableShop.Repository
{
    public class LoginRepository
    {
        private static LoginRepository instance;
        private HttpClient client;

        private LoginRepository()
        {
            var baseAddress = new Uri("http://localhost:5041/api");
            client = new HttpClient { BaseAddress = baseAddress };
        }

        public static LoginRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginRepository();
                }
                return instance;
            }
        }
        public async Task<bool> Login(string username, string password)
        {
            // Gửi yêu cầu đăng nhập đến API
            var response = await client.GetAsync($"/users?username={username}&password={password}");

            // Xác định xem đăng nhập thành công hay không
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
