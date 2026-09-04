using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace multitool
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Title = "DWL - Discord Webhook Tool: Made by @an1spark";
                Banner();
                Menu();
                ConsoleKeyInfo input = Console.ReadKey();
                char option = input.KeyChar;
                Console.WriteLine(option);
                switch (option)
                {
                    case '1':
                        webhookMessage();
                        break;

                    case '2':
                        for (; ; )
                        {
                            webhookSpam();


                        }




                    case '3':
                        Goodbye();
                        await Task.Delay(5000);
                        return;
                }


            }

        }
        static void Banner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("             _____ ______   ___  ___  ___   _________  ___  _________  ________  ________  ___ ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("            |\\   _ \\  _   \\|\\  \\|\\  \\|\\  \\ |\\___   ___\\\\  \\|\\___   ___\\\\   __  \\|\\   __  \\|\\  \\");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("            \\ \\  \\\\\\__\\ \\  \\ \\  \\\\\\  \\ \\  \\\\|___ \\  \\_\\ \\  \\|___ \\  \\_\\ \\  \\|\\  \\ \\  \\|\\  \\ \\  \\  ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("             \\ \\  \\\\|__| \\  \\ \\  \\\\\\  \\ \\  \\    \\ \\  \\ \\ \\  \\   \\ \\  \\ \\ \\  \\\\\\  \\ \\  \\\\\\  \\ \\  \\ ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("              \\ \\  \\    \\ \\  \\ \\  \\\\\\  \\ \\  \\____\\ \\  \\ \\ \\  \\   \\ \\  \\ \\ \\  \\\\\\  \\ \\  \\\\\\  \\ \\  \\____ ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("               \\ \\__\\    \\ \\__\\ \\_______\\ \\_______\\ \\__\\ \\ \\__\\   \\ \\__\\ \\ \\_______\\ \\_______\\ \\_______\\");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("                \\|__|     \\|__|\\|_______|\\|_______|\\|__|  \\|__|    \\|__|  \\|_______|\\|_______|\\|_______|");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                                                 -Made By @an1spark");

        }
        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n1.) Send A Webhook Message");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2.) Spam A Webhook Message");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("3.) Exit");

        }
        static async void webhookMessage()
        {
            Console.Clear();
            Banner();
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Webhook URL: ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string webhook = Console.ReadLine();



            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Message: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string message = Console.ReadLine();

            string json = $"{{\"content\":\"{message}\"}}";

            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                client.PostAsync(webhook, content).Wait();
            }





        }
        static async Task webhookSpam()
        {
            Console.Clear();
            Banner();
            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Webhook URL: ");
            string webhook = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Message: ");
            string message = Console.ReadLine();

            string json = $"{{\"content\":\"{message}\"}}";

            using (HttpClient client = new HttpClient())
            {
                while (true)
                {
                    HttpContent content = new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                    await client.PostAsync(webhook, content);


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Spammed!");
                }
            }
        }

        static void Goodbye()
        {
            Console.Clear();
            Banner();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" \n                                                            Goodbye!!");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("                                                      Closing in 5 Seconds");
            
            Console.ResetColor();

        }
    }
}
