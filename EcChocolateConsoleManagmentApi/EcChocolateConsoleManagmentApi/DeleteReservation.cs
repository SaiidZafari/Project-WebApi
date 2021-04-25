using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcChocolateConsoleManagmentApi
{
    class DeleteReservation
    {
        public static async Task DeleteData(HttpClient client, string id)
        {
            // Delete  api/GameList/id
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"api/reservations/{id}");
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\n  {e.Message} \n");
            }
        }
    }
}
