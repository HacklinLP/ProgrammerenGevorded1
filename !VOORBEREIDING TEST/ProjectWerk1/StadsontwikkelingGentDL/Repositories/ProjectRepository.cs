using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.DTO;
using StadontwikkelingGentBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StadontwikkelingGentDL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private string _connectionString;
        private PartnerRepository _partnerRepo;

        public ProjectRepository(string connectionString)
        {
            _connectionString = connectionString;
            _partnerRepo = new PartnerRepository(_connectionString);
        }

        public List<ProjectDTOUi> GeefAlleProjecten()
        {
            string SQL = "SELECT prj.ID as prj_id, prj.Titel as prj_title, prj.StartDatum as prj_date, prj.Status as prj_status, grprj.ID as green_ID, inprj.ID as ino_ID, stdprj.ID as stad_ID " +
                         "FROM Project as prj " +
                         "LEFT JOIN Eigenaar as eig on prj.Eigenaar_ID = eig.ID " +
                         "LEFT JOIN Groene_Ruimte_Project as grprj on prj.ID = grprj.Project_ID " +
                         "LEFT JOIN Inovatief_Project as inprj on prj.ID = inprj.Project_ID " +
                         "LEFT JOIN Stads_Ontwikkelings_Project as stdprj on prj.ID = stdprj.Project_ID";
            
            List<ProjectDTOUi> toReturn = new List<ProjectDTOUi>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idprj = reader.GetInt32(reader.GetOrdinal("prj_id"));
                        string titel = reader.GetString(reader.GetOrdinal("prj_title"));
                        DateTime? date = null;
                        if (!reader.IsDBNull("prj_date"))
                        {
                            date = reader.GetDateTime(reader.GetOrdinal("prj_date"));
                        }
                        string statusEnum = reader.GetString(reader.GetOrdinal("prj_status"));

                        StatusProject status = statusEnum switch
                        {
                            "Uitvoering" => status = StatusProject.Uitvoering,
                            "Afgerond" => status = StatusProject.Afgerond,
                            _ => status = StatusProject.Planning
                        };
                        
                        bool isGroen = false;
                        bool isino = false;
                        bool IsStad = false;

                        if (!reader.IsDBNull("green_ID"))
                        {
                            isGroen = true;
                        }
                        if (!reader.IsDBNull("ino_ID"))
                        {
                            isino = true;
                        }
                        if (!reader.IsDBNull("stad_ID"))
                        {
                            IsStad = true;
                        }

                        ProjectDTOUi prj;
                        prj = new ProjectDTOUi(idprj, titel, date, status, isGroen, IsStad, isino);

                        toReturn.Add(prj);
                    }
                }
                return toReturn;
            }
        }

        public Project GeefProjectOpId(int id)
        {
            string SQL = "SELECT prj.ID as prj_id, prj.Titel as prj_title, prj.Beschrijving as prj_dscr, prj.Straat as prj_strt, prj.Huisnummer as prj_hsnr, prj.Gemeente as prj_rgn, prj.Provincie as prj_prvnc, prj.Wijk as prj_dstr, prj.StartDatum as prj_date, prj.Status as prj_status, grprj.ID as green_ID, grprj.Oppervlakte as green_srfc, grprj.Wandelroutes as green_paths, grprj.Beoordeling as green_rvw, grprj.Biodiversiteit_score as green_bio, grprj.Is_Opgenomen as grprj_available, inprj.ID as ino_ID, inprj.Wooneenheden as ino_blds, inprj.Heeft_Rondleiding as ino_tour, inprj.Heeft_Showwoning as ino_model, inprj.Architecturale_Score as ino_score, inprj.Samenwerking_Gent as ino_coop, stdprj.ID as stad_ID, stdprj.Vergunningstatus as stad_status, stdprj.Heeft_Architecturele_Waarde as stad_worth, stdprj.Toegankelijkheid as stdprj_access, stdprj.Is_Bezienswaardig as stad_viewable, stdprj.Heeft_Info_Voorzien as stad_info " +
                "FROM Project as prj " +
               "LEFT JOIN Groene_Ruimte_Project as grprj on prj.ID = grprj.Project_ID " +
               "LEFT JOIN Inovatief_Project as inprj on prj.ID = inprj.Project_ID " +
               "LEFT JOIN Stads_Ontwikkelings_Project as stdprj on prj.ID = stdprj.Project_ID " +
               "WHERE prj.ID = @ID";
            string SQLFaciliteitenLijst = "SELECT fac.Naam_Faciliteit as fac_name, fac.vast as fac_status " +
                "FROM Faciliteit as fac " +
                "LEFT JOIN Groene_Ruimte_Project_Faciliteit as grnfac on fac.ID = grnfac.Faciliteit_ID " +
                "LEFT JOIN Groene_Ruimte_Project as grprj on grnfac.Groene_Ruimte_Project_ID = grprj.ID";
            string WoonLijst = "SELECT bld.Naam_Woonvorm as bld_name, bld.vast as bld_status " +
              "FROM Woonvorm as bld " +
              "LEFT JOIN Inovatief_Project_Woonvorm as inobld on bld.ID = inobld.Woonvorm_ID " +
              "LEFT JOIN Inovatief_Project as inoprj on inobld.Innovatief_ID = inoprj.ID";



            List<Partner> partners = new();
            List<TypeProject> projecttypes = new();
            List<Faciliteit> faciliteiten = new();
            List<Woonvorm> woonvorms = new();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            using (SqlConnection conn2 = new SqlConnection(_connectionString))
            using (SqlCommand cmd2 = conn2.CreateCommand())
            {
                conn.Open();
                conn2.Open();
                cmd.CommandText = SQL;
                cmd2.CommandText = SQLFaciliteitenLijst;
                cmd.Parameters.AddWithValue("@ID", id);
                // GROEN


                using(SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        int idprj = reader.GetInt32(reader.GetOrdinal("prj_id"));
                        string titel = reader.GetString(reader.GetOrdinal("prj_title"));
                        DateTime? date = null;
                        if (!reader.IsDBNull("prj_date"))
                        {
                            date = reader.GetDateTime(reader.GetOrdinal("prj_date"));
                        }
                        string statusEnum = reader.GetString(reader.GetOrdinal("prj_status"));

                        StatusProject status = statusEnum switch
                        {
                            "Uitvoering" => status = StatusProject.Uitvoering,
                            "Afgerond" => status = StatusProject.Afgerond,
                            _ => status = StatusProject.Planning
                        };

                        string beschrijvingProject = reader.GetString(reader.GetOrdinal("prj_dscr"));
                        string straat = reader.GetString(reader.GetOrdinal("prj_strt"));
                        string wijk = reader.GetString(reader.GetOrdinal("prj_dstr"));
                        string gemeente = reader.GetString(reader.GetOrdinal("prj_rgn"));
                        string provincie = reader.GetString(reader.GetOrdinal("prj_prvnc"));
                        string huisnr = reader.GetString(reader.GetOrdinal("prj_hsnr"));

                        Adres adres = new(straat, huisnr, gemeente, provincie, wijk);
                       
                        //GROEN
                        
                        using (SqlDataReader reader2 = cmd2.ExecuteReader())
                        {
                            
                            if (!reader.IsDBNull("green_ID"))
                            {
                                while (reader2.Read())
                                {
                                    faciliteiten.Add(new Faciliteit(reader2.GetString(reader2.GetOrdinal("fac_name")), reader2.GetBoolean(reader2.GetOrdinal("fac_status"))));
                                }

                                double oppervlakte = reader.GetDouble(reader.GetOrdinal("green_srfc"));
                                int? bezoekerbeoordeling = null;
                                if (!reader.IsDBNull("green_rvw"))
                                {
                                    bezoekerbeoordeling = reader.GetInt32(reader.GetOrdinal("green_rvw"));
                                }
                                int paden = reader.GetInt32(reader.GetOrdinal("green_paths"));
                                int bioscore = reader.GetInt32(reader.GetOrdinal("green_bio"));
                                bool opgenomen = reader.GetBoolean(reader.GetOrdinal("grprj_available"));



                                GroeneRuimteProject groenProject = new(oppervlakte, bioscore, paden, faciliteiten, opgenomen, bezoekerbeoordeling);

                                projecttypes.Add(groenProject);

                              
                            }


                        }

                        // STADSONTWIKKELING
                        if (!reader.IsDBNull("stad_ID"))
                        {
                            string enumStatus = reader.GetString(reader.GetOrdinal("stad_status"));
                            VergunningStatus statuss = enumStatus switch
                            {
                                "InAanvraag" => statuss = VergunningStatus.InAanvraag,
                                "Goedgekeurd" => statuss = VergunningStatus.Goedgekeurd,
                                "Geweigerd" => statuss = VergunningStatus.Geweigerd,
                                _ => statuss = VergunningStatus.InAanvraag
                            };


                            string enumToegankelijkheid = reader.GetString(reader.GetOrdinal("stdprj_access"));
                            OpenbareToegankelijkheid toegankelijkheid = enumToegankelijkheid switch
                            {
                                "VolledigOpenbaar" => toegankelijkheid = OpenbareToegankelijkheid.VolledigOpenbaar,
                                "Gedeeltelijk" => toegankelijkheid = OpenbareToegankelijkheid.Gedeeltelijk,
                                "Gesloten" => toegankelijkheid = OpenbareToegankelijkheid.Gesloten,
                                _ => toegankelijkheid = OpenbareToegankelijkheid.VolledigOpenbaar
                            };


                            bool waarde = reader.GetBoolean(reader.GetOrdinal("stad_worth"));
                            bool info = reader.GetBoolean(reader.GetOrdinal("stad_info"));
                            bool zien = reader.GetBoolean(reader.GetOrdinal("stad_viewable"));

                            StadsOntwikkelingsProject stadsOntwikkelingsProject = new StadsOntwikkelingsProject(statuss, waarde, toegankelijkheid, zien, info);

                            projecttypes.Add(stadsOntwikkelingsProject);
                        }



                        cmd2.CommandText = WoonLijst;
                        // INNOVATIEF WONEN
                        using (SqlDataReader reader2 = cmd2.ExecuteReader())
                        {
                            if (!reader.IsDBNull("ino_ID"))
                            {
                                while (reader2.Read())
                                {
                                    woonvorms.Add(new Woonvorm(reader2.GetString(reader2.GetOrdinal("bld_name")), reader2.GetBoolean(reader2.GetOrdinal("bld_status"))));
                                }





                                int wooneenheden = reader.GetInt32(reader.GetOrdinal("ino_blds"));
                                bool rondleiding = reader.GetBoolean(reader.GetOrdinal("ino_tour"));
                                bool show = reader.GetBoolean(reader.GetOrdinal("ino_model"));
                                int? score = null;
                                if (!reader.IsDBNull("ino_score"))
                                {
                                    score = reader.GetInt32(reader.GetOrdinal("ino_score"));
                                }
                                bool samenwerking = reader.GetBoolean(reader.GetOrdinal("ino_coop"));



                                InnovatiefWonenProject woonProject = new(wooneenheden, woonvorms, rondleiding, show, score, samenwerking);

                                projecttypes.Add(woonProject);

                            }
                        }
                        partners = _partnerRepo.ZoekOpProjectId(id);
                        Project prj = new Project(id, titel, date, status, beschrijvingProject, adres, partners, projecttypes);
                       
                        return prj;
                    }
                }



            }
            return null;
        }

        public List<Project> ZoekOpType(string type)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

            }
            return null;
        }
        public List<Project> ZoekOpWijk(string wijk)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

            }
            return null;
        }
        public List<Project> ZoekOpStatus(Enum status)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

            }
            return null;
        }
        public List<Project> ZoekOpPartner(string partnerNaam)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {


                List<Project> proj = new List<Project>();
                List<Partner> partners = _partnerRepo.GeefPartnerOpNaam(partnerNaam);
                foreach (Partner partner in partners)
                {

                }
                return proj;
            }
        }
        public List<Project> ZoekOpStartDatum(DateTime datum)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

            }
            return null;
        }
        public void VoegProjectIn(Project project, int eigenaarId)
        {
            string status = project.Status.ToString();

            string SQL = "INSERT INTO Project(Titel, StartDatum, Status, Beschrijving, Eigenaar_ID, Straat, Huisnummer, Gemeente, Provincie, Wijk) " +
                         "OUTPUT inserted.ID VALUES(@Titel, @StartDatum, @Status, @Beschrijving, @Eigenaar_ID, @Straat, @Huisnummer, @Gemeente, @Provincie, @Wijk)";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@Titel", project.Titel);
                cmd.Parameters.AddWithValue("@StartDatum", project.StartDatum.HasValue ? (object)project.StartDatum.HasValue : DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Beschrijving", project.Beschrijving);
                cmd.Parameters.AddWithValue("@Eigenaar_ID", eigenaarId);
                cmd.Parameters.AddWithValue("@Straat", project.Locatie.Straat);
                cmd.Parameters.AddWithValue("@Huisnummer", project.Locatie.Huisnummer);
                cmd.Parameters.AddWithValue("@Gemeente", project.Locatie.Gemeente);
                cmd.Parameters.AddWithValue("@Provincie", project.Locatie.Provincie);
                cmd.Parameters.AddWithValue("@Wijk", project.Locatie.Wijk);
                int projectId = (int)cmd.ExecuteScalar();

                int trueProjId = projectId;



                foreach (TypeProject type in project.ProjectTypes)
                {
                    if (type.GetType() == typeof(GroeneRuimteProject))
                    {
                        GroeneRuimteProject gpr = (GroeneRuimteProject)type;
                        bool wandel = gpr.IsOpgenomenInWandelroute;

                        SQL = "INSERT INTO Groene_Ruimte_Project(Project_ID, Oppervlakte, Wandelroutes, Beoordeling, Biodiversiteit_Score) " +
                              "OUTPUT inserted.ID " +
                              "VALUES(@Project_ID, @Oppervlakte, @Wandelroutes, @Beoordeling, @Biodiversiteit_Score)";

                        cmd.CommandText = SQL;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Project_ID", projectId);
                        cmd.Parameters.AddWithValue("@Oppervlakte", gpr.OppervlakteVierkanteM);
                        cmd.Parameters.AddWithValue("@Wandelroutes", gpr.AantalWandelpaden);
                        cmd.Parameters.AddWithValue("@Beoordeling", gpr.BeoordelingBezoekers);
                        cmd.Parameters.AddWithValue("Biodiversiteit_Score", gpr.BiodiversiteitsScore);
                        int groenId = (int)cmd.ExecuteScalar();

                        SQL = "INSERT INTO Faciliteit(Naam_Faciliteit, Vast) " +
                              "OUTPUT inserted.ID " +
                              "VALUES(@Naam_Faciliteit, @Vast)";
                        cmd.CommandText = SQL;
                        foreach (Faciliteit faciliteit in gpr.Faciliteiten)
                        {
                            cmd.Parameters.AddWithValue("@Naam_Faciliteit", faciliteit.Soort);
                            cmd.Parameters.AddWithValue("@Vast", faciliteit.Vast);
                            int facId = (int)cmd.ExecuteScalar();


                            SQL = "INSERT INTO Groene_Ruimte_Project_Faciliteit(Groene_Ruimte_Project_ID, Faciliteit_ID) " +
                            "VALUES (@Groene_Ruimte_Project_ID, @Faciliteit_ID)";
                            cmd.CommandText = SQL;
                            cmd.Parameters.AddWithValue("@Groene_Ruimte_Project_ID", groenId);
                            cmd.Parameters.AddWithValue("@Faciliteit_ID", facId);
                        }

                    }
                    else if (type.GetType() == typeof(InnovatiefWonenProject))
                    {
                        InnovatiefWonenProject ivwPr = (InnovatiefWonenProject)type;
                        SQL = "INSERT INTO Inovatief_Project(Project_ID, Wooneenheden, Heeft_Rondleiding, Heeft_Showwoning, Architecturale_Score, Samenwerking_Gent)" +
                        " OUTPUT inserted.ID " +
                        "VALUES(@Project_ID, @Wooneenheden, @Heeft_Rondleiding, @Heeft_Showwoning, @Architecturale_Score, @Samenwerking_Gent)";

                        cmd.CommandText = SQL;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Project_ID", projectId);
                        cmd.Parameters.AddWithValue("@Wooneenheden", ivwPr.AantalWooneenheden);
                        cmd.Parameters.AddWithValue("@Heeft_Rondleiding", ivwPr.IsRondleidingMogelijk);
                        cmd.Parameters.AddWithValue("@Heeft_Showwoning", ivwPr.IsShowwoningBeschikbaar);
                        cmd.Parameters.AddWithValue("@Architecturale_Score", ivwPr.ArchitecturaleScore);
                        cmd.Parameters.AddWithValue("Samenwerking_Gent", ivwPr.HeeftSamenwerkingErfgoedOfToerismeGent);
                        int ivwPrID = (int)cmd.ExecuteScalar();


                        SQL = "INSERT INTO Woonvorm(Naam_Woonvorm, Vast) " +
                            "OUTPUT inserted.ID " +
                            "VALUES (@Naam_Woonvorm, @Vast)";
                        cmd.CommandText = SQL;
                        foreach (Woonvorm woonvorm in ivwPr.TypeWoonvormen)
                        {
                            cmd.Parameters.AddWithValue("@Naam_Woonvorm", woonvorm.Soort);
                            cmd.Parameters.AddWithValue("@Vast", woonvorm.Vast);
                            projectId = (int)cmd.ExecuteScalar();
                            int facId = projectId;
                            projectId = trueProjId;

                            SQL = "INSERT INTO Inovatief_Project_Woonvorm(Innovatief_Project_ID, Woonvorm_ID) " +
                            "VALUES (@Innovatief_Project_ID, @Woonvorm_ID)";
                            cmd.CommandText = SQL;
                            cmd.Parameters.AddWithValue("@Innovatief_Project_ID", ivwPrID);
                            cmd.Parameters.AddWithValue("@Woonvorm_ID", facId);
                        }

                    }
                    else if (type.GetType() == typeof(StadsOntwikkelingsProject))
                    {
                        SQL = "INSERT INTO Stads_Ontwikkelings_Project(Project_ID, Vergunningstatus, Heeft_Architecturele_Waarde, Toegankelijkheid, Is_Bezienswaardig, Heeft_Info_Voorzien)" +
                        " VALUES(@Project_ID, @Vergunningstatus, @Heeft_Architecturele_Waarde, @Toegankelijkheid, @Is_Bezienswaardig, @Heeft_Info_Voorzien)";


                        StadsOntwikkelingsProject stadsOntwikkelingsProject = (StadsOntwikkelingsProject)type;
                        string vergunningStatus = stadsOntwikkelingsProject.VergunStatus.ToString();
                        bool waarde = stadsOntwikkelingsProject.HeeftArchitectureleWaarde;
                        bool bezienwaardig = stadsOntwikkelingsProject.IsBezienswaardig;
                        bool info = stadsOntwikkelingsProject.HeeftUitlegbordOfInfoWandeling;
                        string toegankelijkheid = stadsOntwikkelingsProject.Toegankelijkheid.ToString();

                        cmd.CommandText = SQL;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Project_ID", projectId);
                        cmd.Parameters.AddWithValue("@Vergunningstatus", vergunningStatus);
                        cmd.Parameters.AddWithValue("@Heeft_Architecturele_Waarde", waarde);
                        cmd.Parameters.AddWithValue("@Toegankelijkheid", toegankelijkheid);
                        cmd.Parameters.AddWithValue("@Is_Bezienswaardig", bezienwaardig);
                        cmd.Parameters.AddWithValue("@Heeft_Info_Voorzien", info);
                        cmd.ExecuteNonQuery();
                    }

                }
            }
        }
        public void UpdateProject(Project project)
        {
            string status = project.Status.ToString();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = tran;

                    try
                    {
                        //Update Project tabel
                        string SQL = "UPDATE Project " +
                                     "SET Titel=@Titel, StartDatum=@StartDatum, Status=@Status, Beschrijving=@Beschrijving, Straat=@Straat, Huisnummer=@Huisnummer, Gemeente=@Gemeente, Provincie=@Provincie, Wijk=@Wijk " +
                                     "WHERE ID=@ID";

                        cmd.CommandText = SQL;
                        cmd.Parameters.AddWithValue("@Titel", project.Titel);
                        cmd.Parameters.AddWithValue("@StartDatum", project.StartDatum);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@Beschrijving", project.Beschrijving);
                        cmd.Parameters.AddWithValue("@Straat", project.Locatie.Straat);
                        cmd.Parameters.AddWithValue("@Huisnummer", project.Locatie.Huisnummer);
                        cmd.Parameters.AddWithValue("@Gemeente", project.Locatie.Gemeente);
                        cmd.Parameters.AddWithValue("@Provincie", project.Locatie.Provincie);
                        cmd.Parameters.AddWithValue("@Wijk", project.Locatie.Wijk);
                        cmd.Parameters.AddWithValue("@ID", project.Id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        foreach (TypeProject type in project.ProjectTypes)
                        {
                            if (type is GroeneRuimteProject gpr)
                            {
                                //Update Groene_Ruimte_Project tabel
                                bool wandel = gpr.IsOpgenomenInWandelroute;

                                SQL = "UPDATE Groene_Ruimte_Project " +
                                      "SET Oppervlakte=@Oppervlakte, Wandelroutes=@Wandelroutes, Beoordeling=@Beoordeling, Biodiversiteits_Score=@Biodiversiteits_Score " +
                                      "WHERE Project_ID=@Project_ID";

                                cmd.CommandText = SQL;

                                cmd.Parameters.AddWithValue("@Project_ID", project.Id);
                                cmd.Parameters.AddWithValue("@Oppervlakte", gpr.OppervlakteVierkanteM);
                                cmd.Parameters.AddWithValue("@Wandelroutes", gpr.AantalWandelpaden);
                                cmd.Parameters.AddWithValue("@Beoordeling", gpr.BeoordelingBezoekers);
                                cmd.Parameters.AddWithValue("@Biodiversiteits_Score", gpr.BiodiversiteitsScore);
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();

                                //Update Faciliteiten tabel
                                SQL = "UPDATE Faciliteit " +
                                      "SET Naam_Faciliteit=@Naam_Faciliteit, Vast=@Vast " +
                                      "Where ID=@ID";

                                foreach (Faciliteit faciliteit in gpr.Faciliteiten)
                                {
                                    cmd.CommandText = SQL;

                                    cmd.Parameters.AddWithValue("@Naam_Faciliteit", faciliteit.Soort);
                                    cmd.Parameters.AddWithValue("@Vast", faciliteit.Vast);
                                    cmd.Parameters.AddWithValue("@ID", faciliteit.Id);
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                }
                            }
                            else if (type is InnovatiefWonenProject ivwPr)
                            {
                                //Update Inovatief_Project tabel
                                SQL = "UPDATE Inovatief_Project " +
                                      "SET Wooneenheden=@Wooneenheden, Heeft_Rondleiding=@Heeft_Rondleiding, Architecturale_Score=@Architecturale_Score, Samenwerking_Gent=@Samenwerking_Gent " +
                                      "WHERE Project_ID=@Project_ID";

                                cmd.CommandText = SQL;

                                cmd.Parameters.AddWithValue("@Project_ID", project.Id);
                                cmd.Parameters.AddWithValue("@Wooneenheden", ivwPr.AantalWooneenheden);
                                cmd.Parameters.AddWithValue("@Heeft_Rondleiding", ivwPr.IsRondleidingMogelijk);
                                cmd.Parameters.AddWithValue("@Heeft_Showwoning", ivwPr.IsShowwoningBeschikbaar);
                                cmd.Parameters.AddWithValue("@Architecturale_Score", ivwPr.ArchitecturaleScore);
                                cmd.Parameters.AddWithValue("@Samenwerking_Gent", ivwPr.HeeftSamenwerkingErfgoedOfToerismeGent);
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();

                                //Update Woonvorm tabel
                                SQL = "UPDATE Woonvorm " +
                                      "SET Naam_Woonvorm=@Naam_Woonvorm, Vast=@Vast " +
                                      "WHERE ID=@ID";

                                foreach (Woonvorm woonvorm in ivwPr.TypeWoonvormen)
                                {
                                    cmd.CommandText = SQL;

                                    cmd.Parameters.AddWithValue("@Naam_Woonvorm", woonvorm.Soort);
                                    cmd.Parameters.AddWithValue("@Vast", woonvorm.Vast);
                                    cmd.Parameters.AddWithValue("@ID", woonvorm.Id);
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();
                                }
                            }
                            else if (type is StadsOntwikkelingsProject stadsOntwikkelingsProject)
                            {
                                //Update Stads_Ontwikkelings_Project tabel
                                SQL = "UPDATE Stads_Ontwikkelings_Project " +
                                      "SET Vergunningstatus=@Vergunningstatus, Heeft_Architecturele_Waarde=@Heeft_Architecturele_Waarde, Toegankelijkheid=@Toegankelijkheid, Is_Bezienswaardig=@Is_Bezienswaardig, Heeft_Info_Voorzien=@Heeft_Info_Voorzien " +
                                      "WHERE Project_ID=@Project_ID";

                                cmd.CommandText = SQL;
                                cmd.Parameters.AddWithValue("@Project_ID", project.Id);
                                cmd.Parameters.AddWithValue("@Vergunningstatus", stadsOntwikkelingsProject.VergunStatus);
                                cmd.Parameters.AddWithValue("@Heeft_Architecturele_Waarde", stadsOntwikkelingsProject.HeeftArchitectureleWaarde);
                                cmd.Parameters.AddWithValue("@Toegankelijkheid", stadsOntwikkelingsProject.Toegankelijkheid);
                                cmd.Parameters.AddWithValue("@Is_Bezienswaardig", stadsOntwikkelingsProject.IsBezienswaardig);
                                cmd.Parameters.AddWithValue("@Heeft_Info_Voorzien", stadsOntwikkelingsProject.HeeftUitlegbordOfInfoWandeling);
                                cmd.ExecuteNonQuery();
                                cmd.Parameters.Clear();
                            }
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        Console.WriteLine("Update failed: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public void VerwijderProject(Project project)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = tran;

                    try
                    {
                        //Verwijder Partner links
                        string SQL = "DELETE FROM Partner_Project " +
                                     "Where Project_ID=@Project_ID";
                        cmd.CommandText = SQL;
                        cmd.Parameters.AddWithValue("@Project_ID", project.Id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        //Verwijder links in Groene_Ruimte_Project_Faciliteit
                        SQL = "DELETE GRPF " +
                              "FROM Groene_Ruimte_Project_Faciliteit GRPF " +
                              "JOIN Groene_Ruimte_Project GRP On GRPF.Groene_Ruimte_Project_ID = GRP.ID " +
                              "WHERE GRP.Project_ID=@Project_ID";
                        cmd.CommandText = SQL;
                        cmd.Parameters.AddWithValue("@Project_ID", project.Id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        //Verwijder_Groene_Ruimte_Project
                        SQL = "DELETE FROM Groene_Ruimte_Project " +
                              "WHERE Project_ID=@Project_ID";
                        cmd.CommandText = SQL;
                        cmd.Parameters.AddWithValue("@Project_ID", project.Id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        //Verwijder links in Innovatief_Project_Woonvorm
                        SQL = "DELETE IPW " +
                              "FROM Inovatief_Project_Woonvorm IPW " +
                              "JOIN Inovatief_Project IP ON IPW.Innovatief_ID = IP.ID " +
                              "WHERE IP.Project_ID=@Project_ID";
                        cmd.CommandText = SQL;
                        cmd.Parameters.AddWithValue("@Project_ID", project.Id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        //Verwijder Inovatief_Project rij
                        SQL = "DELETE FROM Inovatief_Project " +
                              "WHERE Project_ID=@Project_ID";
                        cmd.CommandText = SQL;
                        cmd.Parameters.AddWithValue("@Project_ID", project.Id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        //Verwijder Stads_Ontwikkelings_Project
                        SQL = "DELETE FROM Stads_Ontwikkelings_Project " +
                              "WHERE Project_ID=@Project_ID";
                        cmd.CommandText = SQL;
                        cmd.Parameters.AddWithValue("@Project_ID", project.Id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        //Verwijder Project
                        SQL = "DELETE FROM Project " +
                              "WHERE ID=@Project_ID";
                        cmd.CommandText = SQL;
                        cmd.Parameters.AddWithValue("@Project_ID", project.Id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        Console.WriteLine("Verwijderen mislukt: " + ex.Message);
                        throw;
                    }
                }
            }
        }
        public List<TypeProject> GeefProjectTypesOpProjectId(int projectId)
        {
            List<TypeProject> projectTypes = new List<TypeProject>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string SQL = "SELECT ID, Oppervlakte, Wandelroutes, Beoordeling and Biodiversiteits_Score " +
                                 "FROM Groene_Ruimte_Project " +
                                 "WHERE Project_ID=@Project_ID";
                }
            }

            return projectTypes;
        }
        public Partner GeefPartnerOpId(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

            }
            return null;
        }

        public List<Project> ZoekOpWijk(Adres wijk)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

            }
            return null;
        }

        public List<Project> ZoekOpStatus(StatusProject status)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

            }
            return null;
        }

        public void MaakFaciliteitAan(Faciliteit faciliteit)
        {
            string SQL = "INSERT INTO Faciliteit(Naam_Faciliteit, Vast) VALUES(@Naam_Faciliteit, @Vast)";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@Naam_Faciliteit", faciliteit.Soort);
                cmd.Parameters.AddWithValue("@Vast", faciliteit.Vast);
                cmd.ExecuteNonQuery();
            }

        }



        public void MaakWoonvormAan(Woonvorm woonvorm)
        {
            string SQL = "INSERT INTO Woonvorm(Naam_Woonvorm, Vast) VALUES(@Naam_Woonvorm, @Vast)";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@Naam_Woonvorm", woonvorm.Soort);
                cmd.Parameters.AddWithValue("@Vast", woonvorm.Vast);
                cmd.ExecuteNonQuery();
            }
        }



        public void VoegFaciliteitToe(Faciliteit faciliteit, int groenId)
        {
            string SQL = "SELECT ID FROM Faciliteit WHERE Naam_Faciliteit=@Naam_Faciliteit";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@Naam_Faciliteit", faciliteit.Soort);
                int? facId = (int)cmd.ExecuteScalar();

                if (facId != null)
                {
                    SQL = "INSERT INTO Groene_Ruimte_Project_Faciliteit(Groene_Ruimte_Project_ID, Faciliteit_ID) VALUES(@Groene_Ruimte_Project_ID, @Faciliteit_ID)";

                    cmd.CommandText = SQL;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Groene_Ruimte_Project_ID", groenId);
                    cmd.Parameters.AddWithValue("@Faciliteit_ID", facId);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SQL = "INSERT INTO Faciliteit(Naam_Faciliteit, Vast) OUTPUT inserted.ID VALUES(@Naam_Faciliteit, @Vast)";
                    cmd.CommandText = SQL;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Naam_Faciliteit", faciliteit.Soort);
                    cmd.Parameters.AddWithValue("@Vast", faciliteit.Vast);
                    facId = (int)cmd.ExecuteScalar();

                    SQL = "INSERT INTO Groene_Ruimte_Project_Faciliteit(Groene_Ruimte_Project_ID, Faciliteit_ID) VALUES(@Groene_Ruimte_Project_ID, @Faciliteit_ID)";

                    cmd.CommandText = SQL;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Groene_Ruimte_Project_ID", groenId);
                    cmd.Parameters.AddWithValue("@Faciliteit_ID", facId);
                    cmd.ExecuteNonQuery();

                }


            }



        }

        public void VoegWoonvormToe(Woonvorm woonvorm, int inoID)
        {
            string SQL = "SELECT ID FROM Woonvorm WHERE Naam_Woonvorm=@Naam_Woonvorm";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@Naam_Woonvorm", woonvorm.Soort);
                int? facId = (int)cmd.ExecuteScalar();

                if (facId != null)
                {
                    SQL = "INSERT INTO Inovatief_Project_Woonvorm(Innovatief_ID, Woonvorm_ID) VALUES(@Innovatief_ID, @Woonvorm_ID)";

                    cmd.CommandText = SQL;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Innovatief_ID", inoID);
                    cmd.Parameters.AddWithValue("@Woonvorm_ID", facId);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SQL = "INSERT INTO Woonvorm(Naam_Woonvorm, Vast) OUTPUT inserted.ID VALUES(@Naam_Woonvorm, @Vast)";
                    cmd.CommandText = SQL;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Naam_Woonvorm", woonvorm.Soort);
                    cmd.Parameters.AddWithValue("@Vast", woonvorm.Vast);
                    facId = (int)cmd.ExecuteScalar();

                    SQL = "INSERT INTO Inovatief_Project_Woonvorm(Innovatief_ID, Woonvorm_ID) VALUES(@Innovatief_ID, @Woonvorm_ID)";

                    cmd.CommandText = SQL;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Groene_Ruimte_Project_ID", inoID);
                    cmd.Parameters.AddWithValue("@Faciliteit_ID", facId);
                    cmd.ExecuteNonQuery();

                }
            }

        }

        public void VerwijderFaciliteit(Faciliteit faciliteit)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

            }

        }

        public void UpdateFaciliteit(Faciliteit faciliteit)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

            }

        }

        public List<ProjectDTOUi> GeefAlleProjectenOpEigenaarId(int id)
        {
            string SQL = "SELECT prj.ID as prj_id, prj.Titel as prj_title, prj.StartDatum as prj_date, prj.Status as prj_status, grprj.ID as green_ID, inprj.ID as ino_ID, stdprj.ID as stad_ID " +
                "FROM Project as prj " +
               "LEFT JOIN Eigenaar as eig on prj.Eigenaar_ID = eig.ID " +
               "LEFT JOIN Groene_Ruimte_Project as grprj on prj.ID = grprj.Project_ID " +
               "LEFT JOIN Inovatief_Project as inprj on prj.ID = inprj.Project_ID " +
               "LEFT JOIN Stads_Ontwikkelings_Project as stdprj on prj.ID = stdprj.Project_ID " +
               "WHERE eig.ID = @ID";
            List<ProjectDTOUi> toReturn = new List<ProjectDTOUi>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@ID", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idprj = reader.GetInt32(reader.GetOrdinal("prj_id"));
                        string titel = reader.GetString(reader.GetOrdinal("prj_title"));
                        DateTime? date = null;
                        if (!reader.IsDBNull("prj_date"))
                        {
                            date = reader.GetDateTime(reader.GetOrdinal("prj_date"));
                        }
                        string statusEnum = reader.GetString(reader.GetOrdinal("prj_status"));

                        StatusProject status = statusEnum switch
                        {
                            "Uitvoering" => status = StatusProject.Uitvoering,
                            "Afgerond" => status = StatusProject.Afgerond,
                            _ => status = StatusProject.Planning
                        };

                        bool isGroen = false;
                        bool isino = false;
                        bool IsStad = false;

                        if (!reader.IsDBNull("green_ID"))
                        {
                            isGroen = true;
                        }
                        if (!reader.IsDBNull("ino_ID"))
                        {
                            isino = true;
                        }
                        if (!reader.IsDBNull("stad_ID"))
                        {
                            IsStad = true;
                        }

                        ProjectDTOUi prj;
                        prj = new ProjectDTOUi(idprj, titel, date, status, isGroen, IsStad, isino);

                        toReturn.Add(prj);
                    }
                }

                return toReturn;
            }
        }
    }
}
