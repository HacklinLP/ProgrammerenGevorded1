using Microsoft.Data.SqlClient;
using StudentBL.Interfaces;
using StudentBL.Model;
using System.Data;

namespace StudentDL
{
    public class StudentRepository : IStudentRepository
    {
        private string connectionString;

        public StudentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void VoegKlasToe(Klas klas)
        {
            string SQL = "INSERT INTO klas(naam,lokaal) output INSERTED.ID VALUES (@naam,@lokaal)";
            using (SqlConnection connection = new SqlConnection(connectionString)) //mbv using zal de connectie disposed worden als het actie uitgevoerd is
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@naam", klas.Naam); // als je de naam parameter tegenkomt (@naam) dan vul je de student.naam daar in
                if (klas.Lokaal == null)
                {
                    command.Parameters.AddWithValue("@lokaal", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@lokaal", klas.Lokaal);
                }
                //command.ExecuteNonQuery();
                int id = (int)command.ExecuteScalar();
                klas.Id = id;
            }
        }

        public void VoegStudentToe(Student student)
        {
            string SQL = "INSERT INTO student(naam,klasid) output INSERTED.ID VALUES (@naam, @klasid)";
            string SQLkoppel = "INSERT INTO student_cursus(student_id,cursus_id) VALUES(@student_id,@cursus_id)";
            using (SqlConnection connection = new SqlConnection(connectionString)) //mbv using zal de connectie disposed worden als het actie uitgevoerd is
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                SqlTransaction sqlTransaction = connection.BeginTransaction();
                try
                {
                    command.CommandText = SQL;
                    command.Parameters.AddWithValue("@naam", student.Naam);
                    command.Parameters.AddWithValue("@klasid", student.Klas.Id);
                    int id = (int)command.ExecuteScalar();
                    student.Id = id;

                    command.CommandText = SQLkoppel;
                    command.Parameters.Clear();
                    command.Parameters.Add(new SqlParameter("@student_id", student.Id));
                    command.Parameters.Add(new SqlParameter("@cursus_id", SqlDbType.Int));
                    foreach (Cursus cursus in student.Cursussen)
                    {
                        command.Parameters["cursus_id"].Value = cursus.Id;
                        command.ExecuteNonQuery();
                    }
                    sqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                }
            }
        }

        public void VoegCursussenToe(List<Cursus> cursussen)
        {
            string SQL = "INSERT INTO cursus(cursusnaam) output INSERTED.ID VALUES (@naam)";
            using (SqlConnection connection = new SqlConnection(connectionString)) //mbv using zal de connectie disposed worden als het actie uitgevoerd is
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = SQL;
                command.Parameters.Add(new SqlParameter("@naam", SqlDbType.NVarChar));
                    foreach (Cursus cursus in cursussen)
                    {
                        command.Parameters["@naam"].Value = cursus.Naam;
                        int id = (int)command.ExecuteScalar();
                        cursus.Id = id;
                    }

            }
        }

        public bool HeeftStudent(string naam)
        {
            string SQL = "INSERT INTO cursus(cursusnaam) output INSERTED.ID VALUES (@naam)";
            using (SqlConnection connection = new SqlConnection(connectionString)) //mbv using zal de connectie disposed worden als het actie uitgevoerd is
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@naam", naam);
                int n = (int)command.ExecuteScalar();
                if (n == 0)
                    return false;
                return true;
            }
        }

        public List<Cursus> GeefCursussen()
        {
            List<Cursus> data = new();
            string SQL = "SELECT * FROM cursus";
            using (SqlConnection connection = new SqlConnection(connectionString)) //mbv using zal de connectie disposed worden als het actie uitgevoerd is
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = SQL;
                IDataReader dr = command.ExecuteReader();
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
            string SQL = "select t1.*, t2.klasnaam, t2.lokaal, t4.id cursusid, t4.cursusnaam from student t1 \r\nleft join klas t2 on t1.klasid = t2.id\r\nleft join student_cursus t3 on t3.studentid = t1.id\r\nleft join cursus t4 on t3.cursusid = t4.id\r\nwhere t1.id=4";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = SQL;
                command.Parameters.AddWithValue("@id", id);
                using(IDataReader dr = command.ExecuteReader())
                {
                    dr.Read();
                    Student student = new Student(id, (string)dr["naam"]);

                    //kolomnummer vragen als je de naam weet
                    if (dr.IsDBNull(dr.GetOrdinal("klasid"))) 
                    {
                        Klas klas = new Klas((int)dr["klasid"], (string)dr["klasnaam"]);
                        if (!dr.IsDBNull(dr.GetOrdinal("lokaal")))
                            klas.Lokaal = (string)dr["lokaal"];
                        student.Klas = klas;
                    } 

                    if (dr.IsDBNull(dr.GetOrdinal("cursusid")))
                        student.Cursussen.Add(new Cursus((int)dr["cursusid"], (string)dr["cursusnaam"]));
                    while (dr.Read())
                    {
                        student.Cursussen.Add(new Cursus((int)dr["cursusid"], (string)dr["cursusnaam"]));
                    }
                    return student;
                }
            }
        }

        void IStudentRepository.GeefStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
