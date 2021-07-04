using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomation.Utils
{
    class Helpers
    {
        static protected Random random = new Random();

        /*
         * Helpers for API consuming:
         * CreateNewUserWithApi()
         * GetCategoryProductTitlesWithAPI()
         * GetCategoryJsonResponse()
         */
        public static async void CreateNewUserWithApi(string user, string pass)
        {
            string encodedPass = Base64Encode(pass);
            string payload = JsonConvert.SerializeObject(new
            {
                username = user,
                password = encodedPass
            });
            await Requests.PostApi("signup", payload);
        }

        public static async Task<List<string>> GetCategoryProductTitlesWithAPI(string category)
        {
            List<string> productTitles = new List<string>();
            JArray productsResponse = await GetCategoryJsonResponse(category);

            for (int i = 0; i < productsResponse.Count; i++)
            {
                productTitles.Add((string)productsResponse[i]["title"]);
            }

            return productTitles;
        }

        private static async Task<JArray> GetCategoryJsonResponse(string category)
        {
            string payload = JsonConvert.SerializeObject(new
            {
                cat = category
            });
            string response = await Requests.PostApi("bycat", payload);
            JObject jsonResponse = (JObject)JsonConvert.DeserializeObject(response);

            return (JArray)jsonResponse["Items"];
        }

        //Encode a string for security purposes (passwords)
        private static string Base64Encode(string textToEncode)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(textToEncode));
        }

        //generate a random text with letters and numbers
        public static string GenerateRandomLettersAndNumbers(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //generate random letters
        public static string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //generate random numbers
        public static string GenerateRandomNumbers(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //get random number
        public static int GetRandomNumber(int maximum, int minimum=0)
        {
            return random.Next(minimum, maximum);
        }

        //convert string to int
        public static int ConvertToInt(string number)
        {
            return int.Parse(number);
        }
    }
}
