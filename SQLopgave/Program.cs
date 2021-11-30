using System;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SQLopgave
{
    class Program
    {
        private static string cs = @"Data Source=PROGAMER;Initial Catalog=gogaming; Integrated Security=SSPI";


        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Velkommen til GG (Go Gaming)");
                Console.Write("Søg: ");
                getdatafromSearch(Console.ReadLine());
                Console.ReadLine();
            }
            
        }


        static void getalldata()
        {
            using (SqlConnection connection = new(cs))
            {
                connection.Open();

                SqlCommand cmd = new("select * from gear", connection);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine($"{rdr["name"]} || {rdr["price"]} || {rdr["description"]}");

                }

            }
        }

        static void getdatafromSearch(string search)
        {

            using (SqlConnection connection = new(cs))
            {
                connection.Open();

                SqlCommand cmd = new($"select name,price,description from gear where name like '%{search}%'", connection);

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine($"{rdr["name"]} || {rdr["price"]} || {rdr["description"]}");

                }

            }
        }
    }
}
