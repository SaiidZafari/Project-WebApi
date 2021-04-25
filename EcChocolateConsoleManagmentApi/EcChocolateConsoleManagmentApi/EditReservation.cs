using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcChocolateConsoleManagmentApi
{
    class EditReservation
    {
        public static async Task UpdateData(HttpClient client,string id, Reservation reservation)
        {
            // Put  api/Reservations/id
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/Reservations/{id}", reservation);
                response.EnsureSuccessStatusCode();

                Reservation game = await response.Content.ReadAsAsync<Reservation>();

                Console.WriteLine("  >>> Updated <<<");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\n  {e.Message} \n");
            }
        }
    }
}
