using System;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DatabaseManagment
{
    class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .AddJsonFile("appsettngs.json", false, true)
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

        }
    }
}
