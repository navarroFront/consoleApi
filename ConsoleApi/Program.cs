using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApi
{
    class Program
    {
       
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50513/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/product/1").Result;
            if (response.IsSuccessStatusCode)
            {
                var objetoRetorno = response.Content.ReadAsAsync<Product>().Result;
                Console.WriteLine("Produto: " + objetoRetorno.Name);
            }
            else
            {
                //Something has gone wrong, handle it here
            }
            Console.ReadKey();
        }

    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

    }
}
