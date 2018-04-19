using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RentoBuddy.Models.ProductViewModels;

namespace ProjectMariott.Models
{
    public class ProductClient
    {
        public System.Net.HttpStatusCode AddProduct(ProductModel product)
        {
            using (var client = CreateActionClient("Post01"))
            {
                HttpResponseMessage response = null;
                try
                {
                    //response = client.PostAsJsonAsync(client.BaseAddress, company).Result;
                    var output = JsonConvert.SerializeObject(product);
                    HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                    response = client.PostAsync(client.BaseAddress, contentPost).Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return response.StatusCode;
            }
        }
        string _hostUri;

        public ProductClient(string hostUri)
        {
            _hostUri = hostUri;
        }

        HttpClient client;
        public HttpClient CreateSingletonClient()
        {
            if (client == null)
            {
                client = new HttpClient();
            }
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/rooms/");
            return client;
        }

        public HttpClient CreateSingletonActionClient(string action)
        {
            if (client == null)
            {
                client = new HttpClient();
            }
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/rooms/" + action);
            return client;
        }

        public HttpClient CreateClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/rooms/");
            return client;
        }

        public HttpClient CreateActionClient(string action)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(new Uri(_hostUri), "api/rooms/" + action);
            return client;
        }


        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage response;
                response = client.GetAsync(client.BaseAddress).Result;

                //var result = response.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                if (response.IsSuccessStatusCode)
                {
                    var avail = await response.Content.ReadAsStringAsync()
                        .ContinueWith<IEnumerable<ProductModel>>(postTask =>
                        {
                            return JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(postTask.Result);
                        });
                    return avail;
                }
                else
                {
                    return null;
                }
            }
            //return result;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync(ProductModel productId)
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage response;
                response = client.GetAsync(new Uri(client.BaseAddress, productId.ToString())).Result;
                //var result = response.Content.ReadAsAsync<string>().Result;
                if (response.IsSuccessStatusCode)
                {
                    var avail = await response.Content.ReadAsStringAsync()
                        .ContinueWith<IEnumerable<ProductModel>>(postTask =>
                        {
                            return JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(postTask.Result);
                        });
                    return avail;
                }
                else
                {
                    return null;
                }
            }
            //return result;
        }



        public System.Net.HttpStatusCode UpdateProduct(ProductModel productModel)
        {
            using (var client = CreateActionClient("Put01"))
            {
                HttpResponseMessage response;
                //response = client.PutAsJsonAsync(client.BaseAddress, company).Result;
                var output = JsonConvert.SerializeObject(productModel);
                HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                response = client.PostAsync(client.BaseAddress, contentPost).Result;
                return response.StatusCode;
            }
        }

        public async Task<System.Net.HttpStatusCode> UpdateProductAsync(ProductModel productModel)
        {
            using (var client = CreateActionClient("Post01"))
            {
                HttpResponseMessage response;
                //response = client.PutAsJsonAsync(client.BaseAddress, company).Result;
                var output = JsonConvert.SerializeObject(productModel);
                HttpContent contentPost = new StringContent(output, System.Text.Encoding.UTF8, "application/json");
                response = await client.PostAsync(client.BaseAddress, contentPost);
                return response.StatusCode;
            }
        }

        public System.Net.HttpStatusCode DeleteProduct(int productId)
        {
            using (var client = CreateClient())
            {
                HttpResponseMessage response;
                response = client.DeleteAsync(new Uri(client.BaseAddress, productId.ToString())).Result;
                response = client.DeleteAsync(new Uri(client.BaseAddress, productId.ToString())).Result;
                return response.StatusCode;
            }
        }
    }
}
