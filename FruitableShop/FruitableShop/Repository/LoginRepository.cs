using NuGet.Protocol.Plugins;

namespace FruitableShop.Repository
{
    // ========== Singleton ========== //
    public class LoginRepository
    {
        Uri baseAdress = new Uri("http://localhost:5041/api");
        private readonly HttpClient _client;

        private static LoginRepository instance;

        private LoginRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAdress;
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
        public async Task<bool> Login(string email, string password)
        {
            try
            {
                // Gửi yêu cầu GET đến API để kiểm tra xem username và password có hợp lệ không
                HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/User/GetUser?email={email}&password={password}");

                // Kiểm tra xem yêu cầu đã thành công và có dữ liệu trả về không
                if (response.IsSuccessStatusCode)
                {
                    // Đọc dữ liệu từ phản hồi (response)
                    var responseData = await response.Content.ReadAsStringAsync();

                    // Xác định xem thông tin đăng nhập có hợp lệ hay không dựa trên dữ liệu trả về
                    /*if (responseData == "valid")
                    {
                        // Thông tin đăng nhập hợp lệ
                        
                    }*/
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi gửi yêu cầu
                Console.WriteLine("Error: " + ex.Message);
            }

            // Trả về false nếu thông tin đăng nhập không hợp lệ hoặc có lỗi xảy ra
            return false;
        }
    }
}
