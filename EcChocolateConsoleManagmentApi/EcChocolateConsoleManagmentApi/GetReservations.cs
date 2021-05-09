using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcChocolateConsoleManagmentApi
{
    class GetReservations
    {

        public static async Task GetAll(HttpClient client)
        {
            // Get api/reservations
            try
            {
                
                HttpResponseMessage response = await client.GetAsync($"api/reservations");
                response.EnsureSuccessStatusCode();

                IEnumerable<Reservation> reservations = await response.Content.ReadAsAsync<IEnumerable<Reservation>>();

                //if (games != null)
                //{
                Console.WriteLine($"\n       >>>>>>>>  List Of the Reservations  <<<<<<<< \n");
                Console.WriteLine($"\n    Id \t FullName \t Phone \t\t Guest \t   ArrangementPrice ");
                Console.WriteLine($"  ================================================================ \n");
                foreach (var reservation in reservations)
                {

                    Console.WriteLine($"    {reservation.Id} \t {reservation.FullName} \t {reservation.Phone} \t {reservation.Guest} \t   {reservation.ArrangementPrice} ");
                }
                //}

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\n  {e.Message} \n");
            }
        }
    }
}
