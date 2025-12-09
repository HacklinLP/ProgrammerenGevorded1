using BL.Interfaces;
using BL.Model;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvinciesDL_SQL {
    public class ProvincieRepository : IProvincieRepository {
        private string _connectionString;

        public ProvincieRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public void UploadToDatabase(List<Provincie> data)
        {
            string SQLprovincie = "INSERT INTO provincie(naam) output INSERTED.ID VALUES(@naam)";
            string SQLgemeente = "INSERT INTO gemeente(naam, provincieid) output INSERTED.ID VALUES (@naam, @provincieid)";
            string SQLstraat = "INSERT INTO straat(naam, gemeenteid) VALUES(@naam, @gemeenteid)";
            using(SqlConnection conn = new SqlConnection(_connectionString))
                using(SqlCommand cmdProvincie = conn.CreateCommand())
                using(SqlCommand cmdGemeente = conn.CreateCommand())
                using(SqlCommand cmdStraat = conn.CreateCommand())
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                cmdProvincie.Transaction = sqlTransaction;
                cmdGemeente.Transaction = sqlTransaction;
                cmdStraat.Transaction = sqlTransaction;

                cmdProvincie.CommandText = SQLprovincie;
                cmdGemeente.CommandText = SQLgemeente;
                cmdStraat.CommandText = SQLstraat;

                cmdProvincie.Parameters.Add(new SqlParameter("@naam", System.Data.SqlDbType.NVarChar));
                cmdGemeente.Parameters.Add(new SqlParameter("@naam", System.Data.SqlDbType.NVarChar));
                cmdGemeente.Parameters.Add(new SqlParameter("@provincieid", System.Data.SqlDbType.Int));
                cmdStraat.Parameters.Add(new SqlParameter("@naam", System.Data.SqlDbType.NVarChar));
                cmdStraat.Parameters.Add(new SqlParameter("@gemeenteid", System.Data.SqlDbType.Int));
                int provincieId, gemeenteId;
                try
                {
                    foreach (Provincie provincie in data)
                    {
                        cmdProvincie.Parameters["@naam"].Value = provincie.Naam;
                        provincieId = (int)cmdProvincie.ExecuteScalar();
                        cmdGemeente.Parameters["@provincieid"].Value = provincieId; ;
                        foreach (Gemeente gemeente in provincie.Gemeentes)
                        {
                            cmdGemeente.Parameters["@naam"].Value = gemeente.Naam;
                            gemeenteId = (int)cmdGemeente.ExecuteScalar();
                            foreach (Straat straat in gemeente.Straten)
                            {
                                cmdStraat.Parameters["@naam"].Value = straat.Naam;
                                cmdStraat.ExecuteNonQuery();
                            }
                        }
                    }
                    sqlTransaction.Commit();
                }
                catch (Exception ex) { sqlTransaction.Rollback(); }
            //using(SqlCommand cmd = conn.CreateCommand())
            //{
            //    conn.Open();
            //    SqlTransaction tran = conn.BeginTransaction();
            //    cmd.Transaction = tran;
            //    try
            //    {
            //        cmd.CommandText = SQLprovincie;
            //        cmd.Parameters.Add(new SqlParameter("@naam", System.Data.SqlDbType.NVarChar));
            //        foreach(Provincie provincie in data)
            //        {
            //            cmd.Parameters["@naam"].Value = provincie.Naam;
            //            int provincieId = (int)cmd.ExecuteScalar();
            //            cmd.CommandText = SQLgemeente;
            //            cmd.Parameters.Clear();
            //            cmd.Parameters.AddWithValue("@provincieid", provincieId);
            //            cmd.Parameters.Add(new SqlParameter("@naam", System.Data.SqlDbType.NVarChar));

            //            foreach (Gemeente gemeente in provincie.Gemeentes)
            //            {
            //                cmd.Parameters["@naam"].Value = gemeente.Naam; 
            //                int gemeenteId=(int)cmd.ExecuteScalar();
            //                cmd.CommandText = SQLstraat;
            //                cmd.Parameters.Clear();
            //                cmd.Parameters.Add(new SqlParameter("@naam", System.Data.SqlDbType.NVarChar));
            //                cmd.Parameters.AddWithValue("@gemeenteid", gemeenteId);

            //                foreach(Straat straat in gemeente.Straten)
            //                {
            //                    cmd.Parameters["@naam"].Value = straat.Naam;
            //                    cmd.ExecuteNonQuery();
            //                }
            //            }
            //        }

            //        tran.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        tran.Rollback();
            //    }
            //}
        }
    }
}
