using FruitableShop.Models;
using Newtonsoft.Json;

namespace FruitableShop.Repository
{
    // ========== Factory ========== //
    public class UserDetailRepository : IUserDetailRepository
    {
        public string ObjName { get; set; }

        private readonly HttpClient _client;
        Uri baseAdress = new Uri("http://localhost:5041/api");

        public UserDetailRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAdress;
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

        public void ShowInformation(string message)
        {
            Console.WriteLine("Instance {0} - {1}", ObjName, message);
        }
    }
}
