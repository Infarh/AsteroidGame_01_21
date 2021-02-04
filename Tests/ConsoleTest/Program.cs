//using System.Collections;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using ConsoleTest.Service;
using Microsoft.Extensions.Configuration;

namespace ConsoleTest
{
    class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", false, true)
           .Build();

        static void Main(string[] args)
        {
            Console.WriteLine("К запросу к WebAPI готов. Нажмите Enter...");
            Console.ReadLine();

            var http = new HttpClient
            {
                BaseAddress = new Uri(Configuration["WebAPI"])
            };

            var players = http.GetFromJsonAsync<Player[]>("api/players").Result;

            foreach (var player in players)
            {
                player.Games = http.GetFromJsonAsync<Game[]>($"api/players/game/{player.Id}").Result;
            }

            foreach (var player in players)
            {
                Console.WriteLine("[id:{0}] {1}", player.Id, player.Name);
                foreach (var game in player.Games)
                    Console.WriteLine("\tgame {0} ({1:yyyy-MM-dd  HH:mm:ss}) - {2}", 
                        game.Id, game.Date, game.Scores);
            }

            Console.ReadLine();
        }
    }
}
