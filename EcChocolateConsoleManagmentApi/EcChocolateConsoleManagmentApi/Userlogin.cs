using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace EcChocolateConsoleManagmentApi
{
    internal class Userlogin
    {


        internal static string Login()
        {
            //string token = "";

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://localhost:44366/");

                // remove all etries from the System.Net.Http.Handlers
                client.DefaultRequestHeaders.Accept.Clear();

                //
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                bool notLoggedIn = true;

                string token = "";

                do
                {
                    Console.Clear();

                    Console.Write($@"


            Username: ");

                    string username = Console.ReadLine();

                    Console.Write($@"
            Password: ");

                    string password = Console.ReadLine();

                    var credentials = new Credentials
                    {
                        Username = username,
                        Password = password
                    };

                    var serializedData = JsonConvert.SerializeObject(credentials);

                    var data = new StringContent(serializedData, Encoding.UTF8, "application/json");

                    var response = client.PostAsync("api/auth", data).Result;

                    
                    if (response.IsSuccessStatusCode) // 200 OK
                    {
                        // TODO: Deserialize body (contains token)
                        var json = response.Content.ReadAsStringAsync().Result;

                        var tokenResponse = JsonConvert.DeserializeObject<Token>(json);

                        token = tokenResponse.Value;

                        notLoggedIn = false;

                    
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ah ah ah, you didn't say the magic word!");
                        Thread.Sleep(2000);
                    }

                } while (notLoggedIn);

                return token;
            }
        }

        

    }
}



//string token = "";

//using (var client = new HttpClient())
//{

//    client.BaseAddress = new Uri("https://localhost:44366/");

//    //client.BaseAddress = new Uri("https://localhost:44380/");

//    // remove all etries from the System.Net.Http.Handlers
//    client.DefaultRequestHeaders.Accept.Clear();

//    //
//    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//}