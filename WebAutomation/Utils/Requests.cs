using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomation.Utils
{
    class Requests
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<string> PostApi(string endpoint, string payload)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                var content = new StringContent(payload, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("https://api.demoblaze.com/" + endpoint, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return e.Message;
            }
        }
    }
}
