using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EcChocolateConsoleManagmentApi
{
    class Leayout
    {
        public static void RunClient(int x)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44366/");

                //client.BaseAddress = new Uri("https://localhost:44380/");

                // remove all etries from the System.Net.Http.Handlers
                client.DefaultRequestHeaders.Accept.Clear();

                //
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                switch (x)
                {
                    case 1:
                        GetReservations.GetAll(client).Wait();
                        Console.Write("\n  Insert ID of the game you wish to Edit: ");
                        var reservationId = Console.ReadLine();
                        Console.Write("\n");
                        Console.Clear();
                        GetReservation.GetById(client, reservationId).Wait();

                        Console.WriteLine($@"

            Please insert information for the new game:
           ============================================

                FullName:
                    
                   Phone:

         Number of Guest:

                    Date:

       Arrangement Price:
                  ");
                        Reservation newReservation = new Reservation();
                        newReservation.Id = int.Parse(reservationId);
                        Console.SetCursorPosition(26, 18);
                        newReservation.FullName = Console.ReadLine();
                        Console.SetCursorPosition(26, 20);
                        newReservation.Phone = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(26, 22);
                        newReservation.Guest = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(26, 24);
                        newReservation.Date = DateTime.Parse(Console.ReadLine());
                        Console.SetCursorPosition(26, 26);
                        newReservation.ArrangementPrice = int.Parse(Console.ReadLine());
                        EditReservation.UpdateData(client, reservationId, newReservation).Wait();

                        break;

                    case 2:
                        GetReservations.GetAll(client).Wait();
                        break;

                    case 3:
                        Console.WriteLine($@"

            Please insert information for the new game:
           ============================================

                FullName:
                    
                   Phone:

         Number of Guest:

                    Date:

       Arrangement Price:
                  ");
                        newReservation = new Reservation();
                        Console.SetCursorPosition(26, 5);
                        newReservation.FullName = Console.ReadLine();
                        Console.SetCursorPosition(26, 7);
                        newReservation.Phone = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(26, 9);
                        newReservation.Guest = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(26, 11);
                        newReservation.Date = DateTime.Parse(Console.ReadLine());
                        Console.SetCursorPosition(26, 13);
                        newReservation.ArrangementPrice = int.Parse(Console.ReadLine());
                        AddReservation.PostData(client, newReservation).Wait();

                        break;

                    case 4:
                        GetReservations.GetAll(client).Wait();
                        Console.Write("\n  Insert ID of the game you wish to delete: ");
                        reservationId = Console.ReadLine();
                        Console.Write("\n");

                        GetReservation.GetById(client, reservationId).Wait();
                        Console.Write("\n  Are you sure you want to delete this Game Y/N: ");
                        var answer = Console.ReadLine().ToLower();
                        if (answer == "y")
                        {
                             DeleteReservation.DeleteData(client, reservationId).Wait();
                        }
                        else
                        {
                            Console.WriteLine("\n  >>> The game is not deleted ! <<< \n");
                        }


                        break;

                }
            }
        }

    }
}
