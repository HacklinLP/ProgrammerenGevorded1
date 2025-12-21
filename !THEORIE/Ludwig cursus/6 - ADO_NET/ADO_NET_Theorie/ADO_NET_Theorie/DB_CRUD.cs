using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Reflection.PortableExecutable;

namespace ADO_NET_Theorie
{
    public class DB_CRUD
    {
        private const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=PersonenDB;Integrated Security=True;TrustServerCertificate=True";
        
        public static void Main(string[] args)
        {
            try
            {
                PrintPersonsTable(connectionString);
                UpdateRow(connectionString);
                PrintPersonsTable(connectionString);
                InsertRow(connectionString);
                PrintPersonsTable(connectionString);
                DeleteRow(connectionString);
                PrintPersonsTable(connectionString);
                
                /*AddPerson("Korneel", null, connectionString);
                PrintPersonsTable(connectionString); */
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //tag::executeReader[]
        public static void PrintPersonsTable(string connString)
        {
            using (SqlConnection connection = new(connString))
            {
                connection.Open();

                SqlCommand command = new("SELECT Id, Naam, Email, Geboortedatum FROM Personen;", connection);

                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    Console.WriteLine();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            int id = (int)dataReader["Id"];
                            string naam = (string)dataReader["Naam"];
                            string email = null;

                            if (!dataReader.IsDBNull(dataReader.GetOrdinal("Email")))
                            {
                                email = (string)dataReader["Email"];
                            }
                            
                            DateTime geboortedatum = (DateTime)dataReader["Geboortedatum"];
                            Console.WriteLine($"{id} | {naam} | {(email is null ? "N/A" : email)} | {geboortedatum.ToShortDateString()}");
                        }
                    }
                    else { Console.WriteLine("Geen personen gevonden."); }
                }

                connection.Close();
            }
        }
        //end::executeReader[]

        //tag::executeNonReader[]
        public static void InsertRow(string connString)
        {
            using (SqlConnection connection = new(connString))
            {
                connection.Open();
                Console.Write("\nInvoegen nieuwe persoon met naam John, geboortedatum 10 oktober 1979...");
                string insertSql = $"INSERT INTO Personen (Naam, Email, Geboortedatum) VALUES (@Name, @Email, @BirthDate);";
                SqlCommand insertCommand = new(insertSql, connection);

                insertCommand.Parameters.Add("@Name", SqlDbType.VarChar);
                insertCommand.Parameters["@Name"].Value = "John";

                insertCommand.Parameters.Add("@Email", SqlDbType.VarChar);
                insertCommand.Parameters["@Email"].Value = "john@mail.be";

                insertCommand.Parameters.Add("@BirthDate", SqlDbType.DateTime);
                insertCommand.Parameters["@BirthDate"].Value = DateTime.Now;

                insertCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void DeleteRow(string connString)
        {
            using (SqlConnection connection = new(connString))
            {
                connection.Open();
                Console.Write("\nVerwijderen persoon met id 3: ");
                string deleteSql = $"DELETE FROM Personen WHERE Id = {3};";
                SqlCommand deleteCommand = new(deleteSql, connection);
                deleteCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void UpdateRow(string connString)
        {
            using (SqlConnection connection = new(connString))
            {
                connection.Open();
                Console.Write("\nAanpassen naam in James van persoon met id 2: ");
                string updateSql = $"UPDATE Personen SET Naam = @Name WHERE Id = @Id; ";
                SqlCommand updateCommand = new(updateSql, connection);

                updateCommand.Parameters.AddWithValue("@Name", "James");
                updateCommand.Parameters.AddWithValue("@Id", 2);
 
                updateCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
        //end::executeNonReader[]

        //tag::executeScalar[]
        public static int AddPerson(string newName, string email, string connString)
        {
            Int32 newProdID = 0;
            
            string sql =    "INSERT INTO Personen (Naam, Email, Geboortedatum) " +
                            "OUTPUT inserted.Id " +
                            "VALUES (@Name, @Email, @BirthDate); ";

            using (SqlConnection conn = new(connString))
            {
                SqlCommand cmd = new(sql, conn);

                cmd.Parameters.Add("@Name", SqlDbType.VarChar);
                cmd.Parameters["@Name"].Value = newName;

                cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                if (email is null)
                    cmd.Parameters["@Email"].Value = DBNull.Value;
                else
                    cmd.Parameters["@Email"].Value = email;

                cmd.Parameters.Add("@BirthDate", SqlDbType.DateTime);
                cmd.Parameters["@BirthDate"].Value = DateTime.Now;

                try
                {
                    conn.Open();
                    newProdID = (Int32)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return (int)newProdID;
        }
        //end::executeScalar[]
    }
}
