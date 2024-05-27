using FruitableShop.Models;
using Newtonsoft.Json;
using System.Text;

namespace FruitableShop.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        Uri baseAdress = new Uri("http://localhost:5041/api");
        private readonly HttpClient _client;
        public ProductRepository()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAdress;
        }
        public bool Create(Product entity)
        {
            string data = JsonConvert.SerializeObject(entity);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress+"Product/Post", content).Result;
            return response.IsSuccessStatusCode;
        }

        public bool Delete(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress+"Product/Delete/{id}").Result;
            return response.IsSuccessStatusCode;
        }

        public Product FindById(int id)
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress+"Product/Get/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Product>(data);
            }
            return null;
        }

        public List<Product> GetAllUser()
        {
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress+"/Product/Get").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Product>>(data);
            }
            return new List<Product>();
        }

        public List<Product> SearchByName(string keyword)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product entity)
        {
            string data = JsonConvert.SerializeObject(entity);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "Product/Put", content).Result;
            return response.IsSuccessStatusCode;
        }
    }
}
