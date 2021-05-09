using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcChocolateConsoleManagmentApi
{
    class DeleteReservation
    {
        public static async Task DeleteData(HttpClient client, string id)
        {
            // Delete  api/reservations/id
            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"api/reservations/{id}");
                response.EnsureSuccessStatusCode();

                Console.WriteLine("  >>> Reservation Is Deleted <<<");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\n  {e.Message} \n");
            }
        }
    }
}
