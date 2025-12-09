using Microsoft.Data.SqlClient;
using StudentBL.Interfaces;
using StudentBL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDL
{
    public class StudentRepository : IStudentRepository
    {
        private string connectionString;

        public StudentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cursus> GeefCursussen(string voorwaarde)
        {
            List<Cursus> data = new();
            string SQL;
            if (string.IsNullOrWhiteSpace(voorwaarde)) 
                SQL = "SELECT * FROM cursus";
            else SQL="SELECT * FROM cursus WHERE cursusnaam like @voorwaarde";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                if (!string.IsNullOrWhiteSpace(voorwaarde))
                    cmd.Parameters.AddWithValue("@voorwaarde", $"%{voorwaarde}%");
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    data.Add(new Cursus((int)dr["id"], (string)dr["cursusnaam"]));
                }
                dr.Close();
            }
            return data;
        }

        public Student GeefStudent(int id)
        {
            string SQL = "select t1.*,t2.naam klasnaam,t2.lokaal,t4.id cursusid,t4.cursusnaam from student t1 left join klas t2 on t1.klasid=t2.id left join student_cursus t3 on t3.student_id=t1.id left join cursus t4 on t3.cursus_id=t4.id where t1.id=@id";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@id", id);
                using(IDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    Student student = new Student(id, (string)dr["naam"]);

                    if (!dr.IsDBNull(dr.GetOrdinal("klasid")))
                    {
                        Klas klas = new Klas((int)dr["klasid"], (string)dr["klasnaam"]);
                        if (!dr.IsDBNull(dr.GetOrdinal("lokaal")))
                            klas.Lokaal = (string)dr["lokaal"];
                        student.Klas = klas;
                    }
                    if (!dr.IsDBNull(dr.GetOrdinal("cursusid")))
                        student.Cursussen.Add(new Cursus((int)dr["cursusid"], (string)dr["cursusnaam"]));
                    while (dr.Read())
                    {
                        student.Cursussen.Add(new Cursus((int)dr["cursusid"], (string)dr["cursusnaam"]));
                    }
                    return student;
                }
            }
        }

        public bool HeeftStudent(string naam)
        {
            string SQL = "SELECT count(*) FROM student WHERE naam=@naam";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@naam",naam);
                int n=(int)cmd.ExecuteScalar();
                if (n == 0) return false; 
                return true;
            }
        }

        public void VoegCursussenToe(List<Cursus> cursussen)
        {
            string SQL = "INSERT INTO cursus(cursusnaam) output INSERTED.ID VALUES(@naam)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.Add(new SqlParameter("@naam",SqlDbType.NVarChar));
                foreach (Cursus cursus in cursussen)
                {
                    cmd.Parameters["@naam"].Value = cursus.Naam;
                    int id = (int)cmd.ExecuteScalar();
                    cursus.Id = id;
                }
            }
        }

        public void VoegKlasToe(Klas klas)
        {
            string SQL = "INSERT INTO klas(naam,lokaal) output INSERTED.ID VALUES(@naam,@lokaal)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@naam", klas.Naam);
                if (klas.Lokaal==null)
                    cmd.Parameters.AddWithValue("@lokaal",DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@lokaal", klas.Lokaal);
                //cmd.ExecuteNonQuery();
                int id = (int)cmd.ExecuteScalar();
                klas.Id = id;
            }
        }

        public void VoegStudentToe(Student student)
        {
            string SQL = "INSERT INTO student(naam,klasid) output INSERTED.ID VALUES(@naam,@klasid)";
            string SQLkoppel = "INSERT INTO student_cursus(student_id,cursus_id) VALUES(@student_id,@cursus_id)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();
                try
                {
                    cmd.Transaction = sqlTransaction;
                    cmd.CommandText = SQL;
                    cmd.Parameters.AddWithValue("@naam", student.Naam);
                    cmd.Parameters.AddWithValue("@klasid", student.Klas.Id);
                    int id = (int)cmd.ExecuteScalar();
                    student.Id = id;

                    cmd.CommandText = SQLkoppel;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@student_id", student.Id);
                    cmd.Parameters.Add(new SqlParameter("@cursus_id", SqlDbType.Int));
                    foreach (Cursus cursus in student.Cursussen)
                    {
                        cmd.Parameters["@cursus_id"].Value = cursus.Id;
                        cmd.ExecuteNonQuery();
                    }
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                }
            }
        }
    }
}
