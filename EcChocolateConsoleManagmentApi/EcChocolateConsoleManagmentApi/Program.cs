using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
//using static EcChocolateConsoleManagmentApi.Layout;

namespace EcChocolateConsoleManagmentApi
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)

        {
            client.BaseAddress = new Uri("https://localhost:44366/");
            //client.BaseAddress = new Uri("https://localhost:44366/api/");

            // Install-package Microsoft.AspNet.WebApi  44336
            // 
            //User.ClinetAccess();
            var token = Userlogin.Login();

            Console.Clear();

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;


            var isAdministrator = tokenS.Claims.Any(x => x.Type == "role" && x.Value == "Admin");

            var firstName = tokenS.Claims.FirstOrDefault(x => x.Type == "role")?.Value;

            Console.WriteLine($@"
                                                     Welcome {firstName}");
            Thread.Sleep(2000);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


            // CursorVisible = false;
            bool applicationRunning = true;

            do
            {

                Console.Write($@"

        1. Edit Reservation
    
        2. List Reservation

        3. Add Resevation

        4. Delete Reservation

        5. Exit

        Please choose one of the options: ");


                ConsoleKeyInfo input = Console.ReadKey(true);

                Console.Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        RunClient(1, client);
                        RunClient(2, client);

                        Console.ReadKey(true);

                        break;

                    case ConsoleKey.D2:

                        RunClient(2, client);
                        Console.ReadKey(true);

                        break;

                    case ConsoleKey.D3:

                        RunClient(3, client);
                        RunClient(2, client);
                        Console.ReadKey(true);

                        break;

                    case ConsoleKey.D4:
                        RunClient(4, client);

                        RunClient(2, client);
                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.D5:

                        applicationRunning = false;

                        break;
                }
                Console.Clear();

            } while (applicationRunning);

        }



        public static void RunClient(int x, HttpClient client)
        {
            switch (x)
            {
                case 1:

                    GetReservations.GetAll(client).Wait();
                    Console.Write("\n  Insert ID of the Reservation you wish to Edit: ");
                    var reservationId = Console.ReadLine();
                    Console.Write("\n");
                    Console.Clear();
                    GetReservation.GetById(client, reservationId).Wait();

                    Console.WriteLine($@"

            Please insert data for the new Reservation:
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

                    //GetAll(client).Wait();
                    GetReservations.GetAll(client).Wait();
                    break;

                case 3:
                    Console.WriteLine($@"

            Please insert information for the new Reservation:
           ====================================================

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
                    Console.Write("\n  Insert ID of the reservation you wish to delete: ");
                    reservationId = Console.ReadLine();
                    Console.Write("\n");

                    GetReservation.GetById(client, reservationId).Wait();
                    Console.Write("\n  Are you sure you want to delete this Reservation Y/N: ");
                    var answer = Console.ReadLine().ToLower();
                    if (answer == "y")
                    {
                        DeleteReservation.DeleteData(client, reservationId).Wait();
                    }
                    else
                    {
                        Console.WriteLine("\n  >>> The Reservation is not deleted ! <<< \n");
                    }

               break;
            }
        }

        
    }

}
