using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Repository.Services
{
    public class ProductApiService
    {
        public List<Product> GetAllProducts()
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57082");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("api/values").Result;

                string stringData = response.Content.ReadAsStringAsync().Result;

                List<Product> data = JsonConvert.DeserializeObject<List<Product>>(stringData);

                return data;
            }
            
        }

        public Product GetProduct(int productId)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57082");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync(String.Format("api/values/{0}",productId)).Result;

                string stringData = response.Content.ReadAsStringAsync().Result;

                Product data = JsonConvert.DeserializeObject<Product>(stringData);

                return data;
            }

        }

        public string CreateProduct(Product productToCreate)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57082");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                var stringData = JsonConvert.SerializeObject(productToCreate);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("api/values",contentData).Result;

                var message = response.Content.ReadAsStringAsync().Result;

                return message;
            }
        }

        public string UpdateProduct(Product productToUpdate)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57082");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);

                var stringData = JsonConvert.SerializeObject(productToUpdate);
                var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(String.Format("api/values/{0}",productToUpdate.Id), contentData).Result;

                var message = response.Content.ReadAsStringAsync().Result;

                return message;
            }            
        }

        public string DeleteProduct(int productToDelete)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57082");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);                

                HttpResponseMessage response = client.DeleteAsync(String.Format("api/values/{0}",productToDelete)).Result;

                var message = response.Content.ReadAsStringAsync().Result;

                return message;
            }
        }
    }
}
