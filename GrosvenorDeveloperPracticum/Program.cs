using System;
using Application;
using Application.Models;

namespace GrosvenorInHousePracticum
{
    class Program
    {
        static void Main()
        {
            var server = new Server(new Cook());
            while (true)
            {
                var unparsedOrder = Console.ReadLine();
                var output = server.TakeOrder(unparsedOrder);
                Console.WriteLine(output);
            }
        }
    }
}
