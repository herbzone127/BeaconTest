﻿
using Newtonsoft.Json;
using System;
using System.Net.Http;

using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Services.Data
{
    /// <summary>
    /// A generic wrapper class to REST API calls
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class HTTPClientWrapper<T> where T : class
    {
        /// <summary>
        /// For getting the resources from a web api
        /// </summary>
        /// <param name="url">API Url</param>
        /// <returns>A Task with result object of type T</returns>
        public static async Task<T> Get(string url)
        {
            T result = null;
            using (var httpClient = new HttpClient())
            {
              
                //if (!string.IsNullOrEmpty(Global.Token))
                //{




                //   

                //}
                //else
                //{

                //}
                var response = await httpClient.GetAsync(new Uri(url));

                //response.EnsureSuccessStatusCode();
                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                    {
                        throw new Exception(x.Result.ToString());
                    }
                    if (response.IsSuccessStatusCode)
                    {
                       
                            result = JsonConvert.DeserializeObject<T>(x.Result);
                          
                        

                    }
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        throw new Exception(x.Result.ToString());
                    }


                });
            }

            return result;
        }

        

        /// <summary>
        /// For creating a new item over a web api using POST
        /// </summary>
        /// <param name="apiUrl">API Url</param>
        /// <param name="postObject">The object to be created</param>
        /// <returns>A Task with created item</returns>
        public static async Task<string> PostRequest(string apiUrl, T postObject) 
        {
            string result = null;

            using (var client = new HttpClient())
            {
              
                var serializeJson = JsonConvert.SerializeObject(postObject);
                HttpContent content = new StringContent(serializeJson, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiUrl, content).ConfigureAwait(false);

                //response.EnsureSuccessStatusCode();

                await response.Content.ReadAsStringAsync().ContinueWith((Task<string> x) =>
                {
                    if (x.IsFaulted)
                    {
                        throw new Exception(x.Result);
                    }
                    if (response.IsSuccessStatusCode)
                    {
                        result = x.Result;
                       
                    }
                 


                });
            
            }

            return result;
        }

        /// <summary>
        /// For updating an existing item over a web api using PUT
        /// </summary>
        /// <param name="apiUrl">API Url</param>
        /// <param name="putObject">The object to be edited</param>
        public static async Task PutRequest(string apiUrl, T putObject)
        {
            using (var client = new HttpClient())
            {
                var serializeJson = JsonConvert.SerializeObject(putObject);
                HttpContent content = new StringContent(serializeJson);
                var response = await client.PutAsync(apiUrl, content).ConfigureAwait(false);

                response.EnsureSuccessStatusCode();
            }
        }
    }
}
