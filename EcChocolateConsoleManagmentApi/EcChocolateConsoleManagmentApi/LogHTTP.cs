using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EcChocolateConsoleManagmentApi
{
    class LogHTTP
    {
        //public static async Task OpenHttp(string username, string password)
        //{

                        
        //    using (var client = new HttpClient())
        //    {

                

        //        client.BaseAddress = new Uri("https://localhost:44366/");

        //        //client.BaseAddress = new Uri("https://localhost:44380/");

        //        // remove all etries from the System.Net.Http.Handlers
        //        client.DefaultRequestHeaders.Accept.Clear();

        //        //
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        var credentials = new Credentials
        //        {
        //            Username = username,
        //            Password = password
                   
        //        };
        //         string SessionIdToken = ".AspNetCore.Antiforgery.HTjDuiPDNFA";
        //        try
        //        {
        //            HttpResponseMessage response = await client.PostAsJsonAsync($"account/login", credentials);
        //            response.EnsureSuccessStatusCode();
        //            string operationLocation = response.Headers.GetValues("Operation-Location").FirstOrDefault();


        //            // Reservation game = await response.Content.ReadAsAsync<Reservation>();
        //            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(".AspNetCore.Antiforgery.HTjDuiPDNFA", );
        //            Console.WriteLine("  >>> Updated <<<");
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            Console.WriteLine($"\n  {e.Message} \n");
        //        }
        //    }
        //}
    }
}
