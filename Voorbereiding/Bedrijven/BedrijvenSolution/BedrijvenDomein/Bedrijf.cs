namespace BedrijvenDomein;

public class Bedrijf
{
    public string Naam { get; set; }
    
    public string Industrie { get; set; }
    
    public string Sector { get; set; }
    
    public string Hoofdkwartier { get; set; }

    private int _oprichtingsjaar;

    public int Oprichtingsjaar
    {
        get
        {
            return _oprichtingsjaar;
        }
        set
        {
            if (value < DateTime.Now.Year)
                throw new BedrijfsException("Het oprichtingsjaar kan niet in de toekomst liggen");
            else
            {
                _oprichtingsjaar = value;
            }
        }
    }

    public string ExtraInfo { get; set; }
}