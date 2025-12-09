using LegoBL.Interfaces;
using Microsoft.Data.SqlClient;


public class LegoRepository 
{
    private string connectionString;

    public LegoRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public LegoTheme GetLegoTheme(string name)
    {
        string SQL = "SELECT t1.id leg"
    }

    //init db
    public void WriteLegoThemes(List<LegoTheme> legoThemes)
    {
        string SQLthema = "INSERT INTO legotheme(name) output INSERTED.ID VALUES (@name)";
        string SQLset = "INSERT INTO legoset(id,name,year,pieces,minifigs,minage,imageurl,retailprice,themeid) VALUES(@id,@name,@year,@pieces,@minifigs,@minage,@imageurl,@retailprice,@themeid)";

	    using(SqlConnection conn = new SqlConnection(connectionString))
        using(SqlCommand cmdThema = conn.CreateCommand())
        using(SqlCommand cmdSet = conn.CreateCommand())
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();
            cmdSet.Transaction = transaction;
            cmdThema.Transaction = transaction;
            cmdSet.CommandText = SQLset;
            cmdThema.CommandText = SQLthema;
            try
            {
                cmdThema.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.NVarChar));

                cmdSet.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.NVarChar));
                cmdSet.Parameters.Add(new SqlParameter("@name", System.Data.SqlDbType.NVarChar));
                cmdSet.Parameters.Add(new SqlParameter("@year", System.Data.SqlDbType.Int));
                cmdSet.Parameters.Add(new SqlParameter("@pieces", System.Data.SqlDbType.Int));
                cmdSet.Parameters.Add(new SqlParameter("@minifigs", System.Data.SqlDbType.Int));
                cmdSet.Parameters.Add(new SqlParameter("@minage", System.Data.SqlDbType.Int));
                cmdSet.Parameters.Add(new SqlParameter("@imageurl", System.Data.SqlDbType.NVarChar));
                cmdSet.Parameters.Add(new SqlParameter("@retailprice", System.Data.SqlDbType.Float));
                cmdSet.Parameters.Add(new SqlParameter("@themeid", System.Data.SqlDbType.Int));


                foreach (LegoTheme theme in legoThemes)
                {
                    cmdThema.Parameters["@name"].Value = theme.Name;
                    int themeId = (int)cmdThema.ExecuteScalar();

                    cmdSet.Parameters["@themeid"].Value = themeId;
                    foreach(LegoSet set in theme.LegoSets)
                    {
                        cmdSet.Parameters["@id"].Value = set.Id;
                        cmdSet.Parameters["@name"].Value = set.Name;
                        cmdSet.Parameters["@year"].Value = set.Year;
                        cmdSet.Parameters["@piecse"].Value = set.Pieces;
                        cmdSet.Parameters["@minifigs"].Value = set.MiniFigs;
                        if(set.MinAge.HasValue)
                            cmdSet.Parameters["@minage"].Value = set.MinAge;
                        else
                            cmdSet.Parameters["@minage"].Value = DBNull.Value;

                        if (set.ImageUrl == null)
                            cmdSet.Parameters["@imageurl"].Value = DBNull.Value;
                        else
                            cmdSet.Parameters["@imageurl"].Value = set.ImageUrl;

                        if (set.RetailPrice.HasValue)
                            cmdSet.Parameters["@retailprice"].Value = set.RetailPrice;
                        else
                            cmdSet.Parameters["@retailprice"].Value = DBNull.Value;

                        cmdSet.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}