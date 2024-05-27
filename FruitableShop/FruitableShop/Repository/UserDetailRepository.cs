using FruitableShop.Models;
using Newtonsoft.Json;

namespace FruitableShop.Repository
{

    public class UserDetailRepository 
    {
        public string objName { get; set; }
        private static UserDetailRepository _instance;
        private static readonly object _lock = new object();
        private static int _instanceCount = 0;

        Uri baseAdress = new Uri("http://localhost:5041/api");
        private readonly HttpClient _client;
        public UserDetailRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAdress;
        }
        public static UserDetailRepository GetInstance()
        {
            // Sử dụng Double-Checked Locking để đảm bảo luồng chạy an toàn và tối ưu hiệu suất
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserDetailRepository();
                        _instanceCount++;
                    }
                }
            }

            return _instance;
        }
        public static int GetInstanceCount()
    {
        return _instanceCount;
    }

        public User FindById(int id)
        {
            HttpResponseMessage response = _client.GetAsync($"{_client.BaseAddress}/User/Get/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<User>(data);
            }
            return null;
        }
        public void showInformation(string message)
        {
            Console.WriteLine("Instance {0} - {1}", objName, message);
        }
    }
}
