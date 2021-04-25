using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcChocolateConsoleManagmentApi
{
    class AddReservation
    {
        public static async Task PostData(HttpClient client, Reservation reservation)
        {
            // Post  api/gamelists
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync($"api/Reservations", reservation);
                response.EnsureSuccessStatusCode();

                Reservation game = await response.Content.ReadAsAsync<Reservation>();

                Console.WriteLine("Saved");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\n  {e.Message} \n");
            }
        }
    }
}
