using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GardenBoxNamespace;
using System.Threading.Tasks;

namespace GardenBox5_23
{
    class Program
    {
        static int GetDimension(string whichDimension)
        {
            bool isAnInt = false;
            int intDimension = 0;
            while (!isAnInt)
            {
                Console.WriteLine($"What is the {whichDimension} of your garden box in feet?");
                string stringDimension = Console.ReadLine();
                isAnInt = int.TryParse(stringDimension, out intDimension);
            }
            return intDimension;
        }

        static void displayVeggies(SqlConnection connection)
        {
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM Veg", connection);
            SqlDataReader reader = selectCommand.ExecuteReader();

            Console.WriteLine("Which veggie would you like to plant?");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                  Console.WriteLine($"{reader["Id"]}) {reader["vegName"]}");
                }
            }
            reader.Close();
        }

        static string setVegName(SqlConnection connection)
        {
            string vegName = "";
            string stringVegId = "";
            int intVegId = 0;
            bool isValidId = false;
            bool isNumber = false;
            while (!isValidId)
            {
                Console.WriteLine("Select a veggie number from above.");
                stringVegId = Console.ReadLine();
                isNumber = int.TryParse(stringVegId, out intVegId);
                if (isNumber)
                {
                    SqlCommand selectCommand = new SqlCommand($"SELECT * FROM Veg WHERE Id='{intVegId}'", connection);
                    SqlDataReader reader = selectCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            vegName = Convert.ToString(reader["vegName"]);
                            isValidId = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Selection");
                    }
                    reader.Close();
                }
                else
                {
                    Console.WriteLine("Invalid Selection");
                }
            }
            return vegName;
        }

        static decimal setNumByArea(string veggie, SqlConnection connection)
        {
            decimal numByArea = 0.0m;
            SqlCommand selectCommand = new SqlCommand($"SELECT * FROM Veg WHERE vegName='{veggie}'", connection);
            SqlDataReader reader = selectCommand.ExecuteReader();

            if (reader.HasRows)
            {
              while (reader.Read())
                {
                    numByArea = Convert.ToDecimal(reader["vegPerArea"]);
                    numByArea /= 16.0m;
                }
            }
            reader.Close();
            return numByArea;
        }

        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDBFilename=\\mac\home\documents\visual studio 2015\Projects\GardenBox5_23\GardenBox5_23\Database1.mdf; Integrated Security=True");
            connection.Open();
            displayVeggies(connection);
            string veggie = setVegName(connection);
            decimal numByArea = setNumByArea(veggie, connection);
            GardenBox box = new GardenBox(GetDimension("length"), GetDimension("width"), veggie, numByArea);
            box.giveBoxInfo();
            Console.ReadLine();
        }
    }
}
