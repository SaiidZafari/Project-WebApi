using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcChocolateConsoleManagmentApi
{
    class LoginUser
    {
        
        

        internal static string Login(HttpClient httpClient, string username, string password)
        {
            bool notLoggedIn = true;

            string token = "";

            do
            {
                //Console.Clear();

                //Console.Write("Username: ");

                //string username = Console.ReadLine();

                //Console.Write("Password: ");

                //string password = Console.ReadLine();

                var credentials = new Credentials
                {
                    Username = username,
                    Password = password
                };

                var serializedData = JsonConvert.SerializeObject(credentials);

                //var data = new StringContent(serializedData, Encoding.UTF8, "application/json");

                var data = new StringContent(serializedData, Encoding.UTF8, "accont/login");

                //var response = httpClient.PostAsync("auth", data).Result;
                var response = httpClient.PostAsync("api/reservations", data).Result;

                if (response.IsSuccessStatusCode) // 200 OK
                {
                    
                }
                //else
                //{
                //    Clear();
                //    WriteLine("Ah ah ah, you didn't say the magic word!");
                //    Thread.Sleep(2000);
                //}

            } while (notLoggedIn);

            return token;
        }
    }
}
