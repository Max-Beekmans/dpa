using System;
using System.Net.Http;

namespace PayloadStrategy
{
    public class HttpFilterStrategy : IFileStrategy
    {
        public string GetPayload(string location)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response =
                        client.GetAsync(location).Result;
                    response.EnsureSuccessStatusCode();

                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
