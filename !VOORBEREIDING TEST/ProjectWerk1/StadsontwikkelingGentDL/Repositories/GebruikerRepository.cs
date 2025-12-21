using Microsoft.Data.SqlClient;
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.DTO;
using StadontwikkelingGentBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StadontwikkelingGentDL.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private string _connectionString;
        private ProjectRepository projRepo;
        public GebruikerRepository(string connectionString)
        {
            _connectionString = connectionString;
            projRepo = new ProjectRepository(connectionString);
        }

        public void VoegGebruikerIn(Gebruiker gebruiker)
        {
            string SQL = "INSERT INTO Eigenaar(Email, Naam, TelefoonNummer, Administrator) VALUES(@Email, @Naam, @TelefoonNummer, @Administrator)";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {


                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@Email", gebruiker.Email);
                cmd.Parameters.AddWithValue("@Naam", gebruiker.Naam);
                cmd.Parameters.AddWithValue("@TelefoonNummer", gebruiker.TelNummer);
                cmd.Parameters.AddWithValue("@Administrator", gebruiker.IsAdmin);
                cmd.ExecuteNonQuery();


            }
        }
        public void UpdateGebruiker(Gebruiker gebruiker)
        {

            string SQL = "UPDATE Eigenaar SET Email=@Email, Naam=@Naam, TelefoonNummer=@TelefoonNummer, Administrator=@Administrator WHERE ID=@ID";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {


                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@Email", gebruiker.Email);
                cmd.Parameters.AddWithValue("@Naam", gebruiker.Naam);
                cmd.Parameters.AddWithValue("@TelefoonNummer", gebruiker.TelNummer);
                cmd.Parameters.AddWithValue("@Administrator", gebruiker.IsAdmin);
                cmd.Parameters.AddWithValue("@ID", gebruiker.Id);
                cmd.ExecuteNonQuery();

            }
        }
        public void VerwijderGebruiker(Gebruiker gebruiker)
        {
            string SQL = "DELETE FROM Eigenaar WHERE ID=@ID";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@ID", gebruiker.Id);
                cmd.ExecuteNonQuery();
            }
        }

        public bool BestaatEmail(string email)
        {
            string SQL = "SELECT count(Email) FROM Eigenaar WHERE Email=@Email";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@Email", email);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {

                    return true;
                }

            }
            return false;
        }

        public List<Gebruiker> GeefAlleGebruikers()
        {
            string SQL = "SELECT ID, Email, Naam, TelefoonNummer, Administrator FROM Eigenaar";
            List<Gebruiker> data = new();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("Id"));
                        string naam = reader.GetString(reader.GetOrdinal("Naam"));
                        string email = reader.GetString(reader.GetOrdinal("Email"));
                        string telefoonnummer = reader.GetString(reader.GetOrdinal("Telefoonnummer"));
                        bool Admin = reader.GetBoolean(reader.GetOrdinal("Administrator"));

                        Gebruiker gebr;
                        List<ProjectDTOUi> forUser = new List<ProjectDTOUi>();

                        forUser = projRepo.GeefAlleProjectenOpEigenaarId(id);

                        gebr = new Gebruiker(id, Admin, forUser, naam, email, telefoonnummer);

                        data.Add(gebr);
                    }
                }
            }

            return data;
        }
        public Gebruiker GeefGebruikerOpEmail(string email)
        {
            Gebruiker toReturn;
            List<ProjectDTOUi> forUser = new List<ProjectDTOUi>();
            string SQL = "SELECT ID, Email, Naam, TelefoonNummer, Administrator FROM Eigenaar WHERE Email=@Email";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        int id = reader.GetInt32(reader.GetOrdinal("ID"));
                        string naam = reader.GetString(reader.GetOrdinal("Naam"));
                        string emailgebr = reader.GetString(reader.GetOrdinal("Email"));
                        string telefoonnummer = reader.GetString(reader.GetOrdinal("TelefoonNummer"));
                        bool Admin = reader.GetBoolean(reader.GetOrdinal("Administrator"));



                        forUser = projRepo.GeefAlleProjectenOpEigenaarId(id);

                        toReturn = new Gebruiker(id, Admin, forUser, naam, emailgebr, telefoonnummer);
                        return toReturn;
                    }
                }
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
