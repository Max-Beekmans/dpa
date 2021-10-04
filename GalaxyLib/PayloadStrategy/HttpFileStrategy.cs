using System;
using System.Net.Http;

namespace GalaxyLib.PayloadStrategy
{
    public class HttpFilterStrategy : IFileStrategy
    {
        public string GetPayload(string location)
        {
            try
            {
                using var client = new HttpClient();
                var response = client.GetAsync(location).Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
