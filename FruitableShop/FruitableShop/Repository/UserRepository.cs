using FruitableShop.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace FruitableShop.Repository
{
    // ========== Adapter Pattern ========== //
    public class UserRepository : IRepository<User>
    {
        Uri baseAdress = new Uri("http://localhost:5041/api");
        private readonly HttpClient _client;
        public UserRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAdress;
        }
        public bool Create(User entity)
        {
            string data = JsonConvert.SerializeObject(entity);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/User/Post", content).Result;
            return response.IsSuccessStatusCode;
        }

        public bool Delete(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/User/Delete/{id}").Result;
            return response.IsSuccessStatusCode;
        }

        public User FindById(int id)
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/User/Get/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<User>(data);
            }
            return null;
        }

        public List<User> GetAllUser()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/User/Get").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<User>>(data);
            }
            return new List<User>();
        }

        public List<User> SearchByName(string keyword)
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            string data = JsonConvert.SerializeObject(entity);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/User/Put", content).Result;
            return response.IsSuccessStatusCode;
        }
    }
}
