using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Repository.Services
{
    public class ProductTypeApiService
    {
        public List<ProductType> GetAllProductTypes()
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57082");
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync("api/types").Result;

                string stringData = response.Content.ReadAsStringAsync().Result;

                List<ProductType> data = JsonConvert.DeserializeObject<List<ProductType>>(stringData);

                return data;
            }
            
        }        
    }
}
