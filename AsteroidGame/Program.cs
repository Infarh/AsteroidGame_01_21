using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace AsteroidGame
{
    static class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", false, true)
           .Build();

        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //Form game_form = new Form();
            //game_form.Width = 800;
            //game_form.Height = 600;

            //game_form.Show();

            //Game.Initialize(game_form);
            //Game.Load();
            //Game.Draw();

            ////System.Threading.Thread.Sleep(10000);
            //Application.Run(game_form);

            string[] players = {"Иванов", "Петров", "Сидоров" };

            var rnd = new Random();

            var player_name = players[rnd.Next(0, players.Length)];
            var scores = rnd.Next(100, 1001);

            var http = new HttpClient
            {
                BaseAddress = new Uri(Configuration["WebAPI"])
            };

            var response = http.PostAsJsonAsync($"api/players/add/{player_name}", scores).Result;
            if (!response.IsSuccessStatusCode)
                MessageBox.Show("Ошибка при отправке данных на игровой сервер", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
