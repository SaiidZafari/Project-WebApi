using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcChocolateConsoleManagmentApi
{
    class GetReservation
    {
        public static async Task GetById(HttpClient client, string id)
        {
            // Get gamelist by Id
            try
            {
                HttpResponseMessage response = await client.GetAsync($"api/reservations/{id}");
                response.EnsureSuccessStatusCode();

                Reservation reservation = await response.Content.ReadAsAsync<Reservation>();

                Console.WriteLine($@" 

          Id    : {reservation.Id} 

          Name  : {reservation.FullName}

          Phone : {reservation.Phone}

          Gustes: {reservation.Guest}

          Date  : {reservation.Date}

          Price : {reservation.ArrangementPrice}");

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\n  {e.Message} \n");
            }
        }
    }
}
