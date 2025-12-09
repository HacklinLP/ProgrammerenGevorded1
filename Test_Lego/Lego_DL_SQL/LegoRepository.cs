using LegoBL.Interfaces;


public class LegoRepository : ILegoRepository
{
    private string connectionString;

    public LegoRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    //public LegoTheme GetLegoTheme(string name)
    //{

    //}

    //init db
    public void WriteLegoThemes(List<LegoTheme> legoThemes)
    {
	    
    }
}