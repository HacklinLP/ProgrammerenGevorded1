using Microsoft.Data.SqlClient;
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentDL.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private string _connectionString;
        public PartnerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void MaakPartnerAan(Partner partner)
        {
            string SQL = "INSERT INTO Partner(Naam, Email, Telefoonnummer, Type_Partner) " +
                         "VALUES(@Naam, @Email, @Telefoonnummer, @Type_Partner)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@Naam", partner.Naam);
                cmd.Parameters.AddWithValue("@Email", partner.Email);
                cmd.Parameters.AddWithValue("@Telefoonnummer", partner.Telefoonnummer);
                cmd.Parameters.AddWithValue("@Type_Partner", partner.Type_Partner);
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdatePartner(Partner partner)
        {   
            string SQL = "UPDATE Partner " +
                         "SET Naam=@Naam, Email=@Email, Telefoonnummer=@Telefoonnummer, Type_Partner=@Type_Partner " +
                         "WHERE ID=@ID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@Naam", partner.Naam);
                cmd.Parameters.AddWithValue("@Email", partner.Email);
                cmd.Parameters.AddWithValue("@Telefoonnummer", partner.Telefoonnummer);
                cmd.Parameters.AddWithValue("@Type_Partner", partner.Type_Partner);
                cmd.Parameters.AddWithValue("@ID", partner.Id);
                cmd.ExecuteNonQuery();
            }
        }
        public void VerwijderPartner(Partner partner)
        {
            string SQL = "DELETE FROM Partner " +
                         "WHERE ID=@ID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@ID", partner.Id);
                int rijen = cmd.ExecuteNonQuery();
                if(rijen == 0)
                {
                    Console.WriteLine("Geen rijen aangepast.");
                }
            }
        }
        public List<Partner> GeefAllePartners()
        {
            List<Partner> partners = new List<Partner>();

            string SQL = "SELECT Id, Naam, Email, Telefoonnummer, Type_Partner " +
                         "FROM Partner";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using(SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            string naam = reader.GetString(reader.GetOrdinal("Naam"));
                            string email = reader.GetString(reader.GetOrdinal("Email"));
                            string telefoonnummer = reader.GetString(reader.GetOrdinal("Telefoonnummer"));
                            string type_Partner = reader.GetString(reader.GetOrdinal("Type_Partner"));

                            Partner partner;

                            if (type_Partner == "Bedrijf")
                            {
                                partner = new Bedrijf(id, naam, email, telefoonnummer, type_Partner, new List<string>());
                            }
                            else if (type_Partner == "Bouwfirma")
                            {
                                partner = new Bouwfirma(id, naam, email, telefoonnummer, type_Partner, new List<string>());
                            }
                            else if (type_Partner == "Burger")
                            {
                                partner = new Burger(id, naam, email, telefoonnummer, type_Partner, new List<string>());
                            }
                            else
                            {
                                partner = new Organisatie(id, naam, email, telefoonnummer, type_Partner, new List<string>());
                            }
                            partners.Add(partner);
                        }
                    }
                }
            }
            return partners;
        }

        public void VoegPartnerToeAanProject(Project project, Partner partner)
        {
            string SQL = "INSERT INTO Partner_Project(ProjectId, PartnerId, PartnerRol) " +
                         "VALUES(@ProjectId, @PartnerId, @PartnerRol)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                string StringRollen = partner.Rollen != null && partner.Rollen.Any() ? string.Join(",", partner.Rollen) : null;

                cmd.CommandText = SQL;

                cmd.Parameters.AddWithValue("@ProjectId", project.Id);
                cmd.Parameters.AddWithValue("@PartnerId", partner.Id);
                cmd.Parameters.AddWithValue("@PartnerRol", StringRollen);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Partner> GeefPartnerOpNaam(string naam)
        {
            List<Partner> partners = new List<Partner>();
            
            string SQL = "SELECT Id, Naam, Email, Telefoonnummer, Type_Partner " +
                         "FROM Partner " +
                         "WHERE Naam LIKE @Naam";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@Naam", "%" + naam + "%");

                conn.Open();

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("Id"));
                        string naamDb = reader.GetString(reader.GetOrdinal("Naam"));
                        string email = reader.GetString(reader.GetOrdinal("Email"));
                        string telefoonnummer = reader.GetString(reader.GetOrdinal("Telefoonnummer"));
                        string type_Partner = reader.GetString(reader.GetOrdinal("Type_Partner"));

                        Partner partner;

                        if (type_Partner == "Bedrijf")
                        {
                            partner = new Bedrijf(id, naam, email, telefoonnummer, type_Partner, new List<string>());
                        }
                        else if (type_Partner == "Bouwfirma")
                        {
                            partner = new Bouwfirma(id, naam, email, telefoonnummer, type_Partner, new List<string>());
                        }
                        else if (type_Partner == "Burger")
                        {
                            partner = new Burger(id, naam, email, telefoonnummer, type_Partner, new List<string>());
                        }
                        else
                        {
                            partner = new Organisatie(id, naam, email, telefoonnummer, type_Partner, new List<string>());
                        }
                        partners.Add(partner);
                    }
                }
            }
            return partners;
        }

        public List<Partner> ZoekOpProjectId(int projectId)
        {
            List<Partner> partners = new List<Partner>();

            string SQL = "Select p.Id as id, p.Naam as naam, p.Email as email, p.Telefoonnummer as telefoonnummer, p.type_partner as type_partner, pp.Rol_Partner as rol_partner " +
                         "FROM Partner p " +
                         "INNER JOIN Partner_Project pp ON p.Id = pp.Partner_Id " +
                         "WHERE pp.Project_Id = @Project_Id ";

            using(SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = SQL;

                cmd.Parameters.AddWithValue("@Project_Id", projectId);

                conn.Open();


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("Id"));
                        string naam = reader.GetString(reader.GetOrdinal("Naam"));
                        string email = reader.GetString(reader.GetOrdinal("Email"));
                        string telefoonnummer = reader.GetString(reader.GetOrdinal("Telefoonnummer"));
                        string type_Partner = reader.GetString(reader.GetOrdinal("Type_Partner"));
                        string rollenString = reader.GetString(reader.GetOrdinal("Rol_Partner"));

                        List<string> Rollen = rollenString.Split(",").ToList();

                        Partner partner;

                        if (type_Partner == "Bedrijf")
                        {
                            partner = new Bedrijf(id, naam, email, telefoonnummer, type_Partner, Rollen);
                        }
                        else if (type_Partner == "Bouwfirma")
                        {
                            partner = new Bouwfirma(id, naam, email, telefoonnummer, type_Partner, Rollen);
                        }
                        else if (type_Partner == "Burger")
                        {
                            partner = new Burger(id, naam, email, telefoonnummer, type_Partner, Rollen);
                        }
                        else
                        {
                            partner = new Organisatie(id, naam, email, telefoonnummer, type_Partner, Rollen);
                        }
                        partners.Add(partner);
                    }
                }
            }
            return partners;
        }

        public bool BestaatEmail(string email)
        {
            string SQL = "SELECT COUNT(Email) " +
                         "FROM Partner " +
                         "WHERE Email=@Email";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using(SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@Email", email);
                int count = (int)cmd.ExecuteScalar();
                if(count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
