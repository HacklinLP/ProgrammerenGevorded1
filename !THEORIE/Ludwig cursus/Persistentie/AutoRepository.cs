using Domein;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistentie
{
    public class AutoRepository : IAutoRepository
    {
        private const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=GarageDB;Integrated Security=True; TrustServerCertificate=True";

        public List<Auto> GeefAutos()
        {
            List<Auto> autoLijst = new List<Auto>();
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new("SELECT Nummerplaat, Model, Merk FROM Autos;", connection);

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                string nummerplaat = (string)dataReader["nummerplaat"];
                                string merk = (string)dataReader["merk"];
                                string model = (string)dataReader["model"];

                                autoLijst.Add(new Auto(nummerplaat, merk, model));
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return autoLijst;
        }

        public Auto ReadAuto(string nummerplaat)
        {
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new("SELECT * FROM Autos WHERE Nummerplaat = @Nummerplaat;", connection);
                    command.Parameters.AddWithValue("@Nummerplaat", nummerplaat);

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            dataReader.Read();
                            string merk = (string)dataReader["merk"];
                            string model = (string)dataReader["model"];

                            return new Auto(nummerplaat, model, merk);  
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        //tag::executeNonReader[]
        public void InsertAuto(Auto auto)
        {
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();

                    string insertSql = $"INSERT INTO Auto (Nummerplaat, Merk, Model) VALUES (@Nummerplaat, @Merk, @Model);";
                    SqlCommand insertCommand = new(insertSql, connection);

                    insertCommand.Parameters.Add("@Nummerplaat", SqlDbType.VarChar);
                    insertCommand.Parameters["@Nummerplaat"].Value = auto.Nummerplaat;

                    insertCommand.Parameters.Add("@Merk", SqlDbType.VarChar);
                    insertCommand.Parameters["@Merk"].Value = auto.Merk;

                    insertCommand.Parameters.Add("@Model", SqlDbType.VarChar);
                    insertCommand.Parameters["@Model"].Value = auto.Model;

                    insertCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        public void DeleteAuto(string nummerplaat)
        {
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();

                    string deleteSQL = $"DELETE from Autos WHERE Nummerplaat = @nummerplaat;";

                    SqlCommand deleteCommand = new(deleteSQL, connection);
                    deleteCommand.Parameters.AddWithValue("@nummerplaat", nummerplaat);

                    deleteCommand.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateAuto(Auto auto)
        {
            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    connection.Open();

                    string updateSQL = $"UPDATE Autos SET Merk = @merk, Model = @model where Nummerplaat = @nummerplaat;";
                    SqlCommand command = new(updateSQL, connection);

                    command.Parameters.AddWithValue("@merk", auto.Merk);
                    command.Parameters.AddWithValue("@model", auto.Model);
                    command.Parameters.AddWithValue("@nummerplaat", auto.Nummerplaat);

                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }  
        }
    }
}
