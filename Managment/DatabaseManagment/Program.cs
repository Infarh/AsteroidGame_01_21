using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using DatabaseManagment.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DatabaseManagment
{
    class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", false, true)
           .Build();

        public static string ConnectionString => Configuration.GetConnectionString("Default");

        static void Main(string[] args)
        {
            //var config_builder = new ConfigurationBuilder()
            //   .AddJsonFile("appsettings.json", false, true);
            //var config = config_builder.Build();

            //var connection_string = @"Data Source=\\localhost;Initial Catalog=TestDB;Integrated Security=True;Timeout=30";
            ////var connection_string2 = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //var connection_string_builder = new SqlConnectionStringBuilder(connection_string);

            //connection_string_builder.DataSource = "(localdb)\\MSSQLLocalDB";
            //connection_string_builder.IntegratedSecurity = false;
            //connection_string_builder.UserID = "MyUser";
            //connection_string_builder.Password = "Password";

            //var new_connection_string = connection_string_builder.ConnectionString;

            //CreatePlayerTable(ConnectionString);

            var rnd = new Random();

            AddPlayerScore("Иванов", rnd.Next(0, 1001));
            AddPlayerScore("Петров", rnd.Next(0, 1001));
            AddPlayerScore("Сидоров", rnd.Next(0, 1001));

            var records_count = GetRecordsCount();

            Console.WriteLine("Число записей в таблице Players {0}", records_count);

            var ivanov_games_count = GetPlayerGamesCount("Иванов");

            Console.WriteLine("Иванов играл в нишу игру {0} раз", ivanov_games_count);

            Console.WriteLine();

            //foreach (var player in GetAllGameResults())
            //    Console.WriteLine(player);

            foreach (var (_, name, score) in GetAllGameResults().OrderByDescending(v => v.Score).Take(5))
                Console.WriteLine("{0} - {1}", name, score);


            var table = GetScoreTable();

            var row3 = table.Rows[3];
            var id3 = row3["Id"];
            var name3 = row3["name"];
            var score3 = row3["score"];

            row3["name"] = "QWE";

            var name31 = row3["name"];

            UpdateData(table);

            var db_connstion_options = new DbContextOptionsBuilder<PlayersDB>()
               .UseSqlServer(Configuration.GetConnectionString("EFCore"));

            using var db = new PlayersDB(db_connstion_options.Options);

            db.Database.EnsureCreated();

            if (!db.Players.Any())
            {
                for (var i = 1; i <= 10; i++)
                {
                    var player = new Data.Player { Name = $"Player-{i}", Sessions = new List<GameSession>() };

                    for (var j = 0; j < 10; j++)
                    {
                        var session = new GameSession { Player = player, Scores = rnd.Next(1, 1001) };
                        player.Sessions.Add(session);
                    }

                    db.Players.Add(player);
                }
                db.SaveChanges();
            }

            var total_scores = db.GameSessions.Sum(session => session.Scores);

            var player1_total_scores = db.Players.Where(p => p.Name == "Player-5").SelectMany(p => p.Sessions).Sum(s => s.Scores);

            Console.WriteLine();

            var best_players_query = db.Players
               .Select(p => new { p.Name, TotalScores = p.Sessions.Sum(s => s.Scores) })
               .OrderByDescending(p => p.TotalScores)
               .Take(5);

            foreach (var player in best_players_query)
                Console.WriteLine("{0} - {1}", player.Name, player.TotalScores);
        }

        #region ExecuteNonQuery

        private const string __CreateTablePlayer = @"
CREATE TABLE [dbo].[Players] (
    [Id]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (MAX) NOT NULL,
    [Score] INT            DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);";


        private static void CreatePlayerTable(string ConnectionStr)
        {
            using (var connection = new SqlConnection(ConnectionStr))
            {
                connection.Open();

                var create_table_command = new SqlCommand(
                    __CreateTablePlayer,
                    connection);

                create_table_command.ExecuteNonQuery();
            }
        }

        private const string __SqlInsertToPlayerTable = @"INSERT INTO [dbo].[Players] (Name, Score) VALUES (N'{0}', '{1}')";

        private static void AddPlayerScore(string PlayerName, int Score)
        {
            var connection_string = ConnectionString;

            using var connection = new SqlConnection(connection_string);

            connection.Open();

            var command = new SqlCommand(string.Format(__SqlInsertToPlayerTable, PlayerName, Score), connection);

            command.ExecuteNonQuery();
        }

        #endregion

        private static SqlConnection GetOpenedConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        #region ExecuteScalar

        private static int GetRecordsCount()
        {
            const string sql_count_query = "SELECT COUNT(*) FROM [dbo].[Players]";

            using var connection = GetOpenedConnection();

            var command = new SqlCommand(sql_count_query, connection);

            var records_count = command.ExecuteScalar();

            return (int)records_count;

        }

        private static int GetPlayerGamesCount(string Player)
        {
            const string sql_player_count = @"SELECT COUNT(*) FROM [dbo].[Players] WHERE {0}";

            using var connection = GetOpenedConnection();

            //var command = new SqlCommand(string.Format(sql_player_count, $"Name={Player}"), connection);
            var command = new SqlCommand(string.Format(sql_player_count, "Name=@PlayerName"), connection);

            var player_name = new SqlParameter("@PlayerName", SqlDbType.NVarChar, -1);
            command.Parameters.Add(player_name);

            player_name.Value = Player;

            return (int)command.ExecuteScalar();
        }

        #endregion

        public record Player(int Id, string Name, int Score);

        //public static Player[] GetAllGameResults()
        public static IEnumerable<Player> GetAllGameResults()
        {
            const string sql_select_all_from_Players = "SELECT * FROM Players";

            using var connection = GetOpenedConnection();

            var select_command = new SqlCommand(sql_select_all_from_Players, connection);

            using var reader = select_command.ExecuteReader();

            //var players_list = new List<Player>();
            if (reader.HasRows)
                while (reader.Read())
                {
                    var id = (int)reader.GetValue(0);
                    var name = reader.GetString(1);
                    var score = (int)reader["Score"];

                    var name_column_index = reader.GetOrdinal("Name");
                    var name1 = reader.GetString(name_column_index);

                    yield return new Player(id, name, score);

                    //players_list.Add(new Player(id, name, score));
                }

            //return players_list.ToArray();
        }

        public static DataTable GetScoreTable()
        {
            using var connection = GetOpenedConnection();

            var adapter = new SqlDataAdapter { SelectCommand = new SqlCommand("SELECT * FROM Players", connection) };

            var table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        public static void UpdateData(DataTable table)
        {
            using var connection = GetOpenedConnection();

            //var insert_command = new SqlCommand("INSERT INTO Players (Name, Score) VALUES (@Name, @Score); SET @ID=@@IDENTITY", connection)
            //{
            //    Parameters =
            //    {
            //        { "@Name", SqlDbType.NVarChar, -1, "Name" },
            //        { "@Score", SqlDbType.Int, 0, "Score" },
            //        { "@ID", SqlDbType.Int, 0, "ID" }
            //    }
            //};
            //insert_command.Parameters["@ID"].Direction = ParameterDirection.Output;

            //var update_command = new SqlCommand("UPDATE Players SET Name=@Name,Score=@Score WHERE ID=@ID", connection)
            //{
            //    Parameters =
            //    {
            //        { "@Name", SqlDbType.NVarChar, -1, "Name" },
            //        { "@Score", SqlDbType.Int, 0, "Score" },
            //        { "@ID", SqlDbType.Int, 0, "ID" }
            //    }
            //};
            //update_command.Parameters["@ID"].Direction = ParameterDirection.Output;

            //var delete_command = new SqlCommand("DELETE FROM Players WHERE ID=@ID", connection)
            //{
            //    Parameters =
            //    {
            //        { "@ID", SqlDbType.Int, 0, "ID" }
            //    }
            //};
            //delete_command.Parameters["@ID"].Direction = ParameterDirection.Output;

            //var adapter = new SqlDataAdapter
            //{
            //    SelectCommand = new SqlCommand("SELECT * FROM Players", connection),
            //    InsertCommand = insert_command,
            //    UpdateCommand = update_command,
            //    DeleteCommand = delete_command
            //};

            //adapter.Update(table);

            var adapter = new SqlDataAdapter { SelectCommand = new SqlCommand("SELECT * FROM Players", connection) };
            var builder = new SqlCommandBuilder(adapter);
            adapter.InsertCommand = builder.GetInsertCommand();
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.DeleteCommand = builder.GetDeleteCommand();

            adapter.Update(table);
        }
    }
}
