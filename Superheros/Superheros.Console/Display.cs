using System;
using System.Threading.Tasks;
using Superheros.Console.Flows;

namespace Superheros.Console
{
    internal class Display
    {
        internal static void Print(string message) => System.Console.WriteLine($"\r\n{DateTime.UtcNow.Ticks} - {message}\r\n");

        internal static async Task ShowMenu()
        {
            string key;

            do
            {
                System.Console.Clear();
                System.Console.WriteLine("Choose authentication flow:");
                System.Console.WriteLine("1) Client credentials");
                System.Console.WriteLine("2) Resource owner password");
                System.Console.WriteLine("3) Exit");

                key = System.Console.ReadLine();

                System.Console.Clear();

                await SwitchOption(key);
            } 
            while (key != "3");

        }

        private static async Task SwitchOption(string key)
        {
            switch (key)
            {
                case "1":
                    await ClientCredentialsFlow.Start();
                    break;

                case "2":
                    await ResourceOwnerPasswordFlow.Start();
                    break;

                case "3":
                    break;
            }
        }
    }
}
