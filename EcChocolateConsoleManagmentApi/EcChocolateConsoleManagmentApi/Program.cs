using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static EcChocolateConsoleManagmentApi.Leayout;

namespace EcChocolateConsoleManagmentApi
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();

        static void Main(string[] args)
        {
            // Install-package Microsoft.AspNet.WebApi  44336

            httpClient.BaseAddress = new Uri("https://localhost:44366/api/");

            //httpClient.BaseAddress = new Uri("https://localhost:44380/api/");

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

                        RunClient(1);
                        RunClient(2);

                        Console.ReadKey(true);

                        break;

                    case ConsoleKey.D2:

                        RunClient(2);
                        Console.ReadKey(true);

                        break;

                    case ConsoleKey.D3:

                        RunClient(3);
                        RunClient(2);
                        Console.ReadKey(true);

                        break;

                    case ConsoleKey.D4:
                        RunClient(4);

                        RunClient(2);
                        Console.ReadKey(true);
                        break;

                    case ConsoleKey.D5:

                        applicationRunning = false;

                        break;
                }
                Console.Clear();

            } while (applicationRunning);

        }
    }
    
}
