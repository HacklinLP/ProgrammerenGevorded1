namespace BedrijvenDomein;

public class Personeel
{
    public int Id { get; set; }
    
    public string Voornaam { get; set; }
    
    public string Achternaam { get; set; }

    private DateTime _geboortedatum;

    public DateTime Geboortedatum
    {
        get => _geboortedatum;
        set
        {
            if (value > DateTime.Now.AddYears(-18))
                throw new BedrijfsException("De persoon moet ouder dan 18 zijn");
            else
            {
                _geboortedatum = value;
            }
        }
    }
    
    public string Woonplaats { get; set; }
    
    public string Postcode  { get; set; }
    
    public string Straatnaam { get; set; }
    
    public int Huisnummer { get; set; }
    
    public string Email { get; set; }
}