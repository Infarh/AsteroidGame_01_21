using System;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form game_form = new Form();
            game_form.Width = 800;
            game_form.Height = 600;

            game_form.Show();

            Game.Initialize(game_form);
            Game.Load();
            Game.Draw();

            //System.Threading.Thread.Sleep(10000);
            Application.Run(game_form);

            string[] players = {"Иванов", "Петров", "Сидоров" };

            var rnd = new Random();

            var player_name = players[rnd.Next(0, players.Length)];
            var scores = rnd.Next(100, 1001);
        }
    }
}
