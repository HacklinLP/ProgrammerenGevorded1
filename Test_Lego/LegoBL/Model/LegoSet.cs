using LegoBL.Exceptions;

public class LegoSet
{
    public LegoSet(string id, string name, int year, int pieces, int miniFigs, int? minAge, string imageUrl, double? retailPrice)
    {
        Id = id;
        Name = name;
        Year = year;
        Pieces = pieces;
        MiniFigs = miniFigs;
        MinAge = minAge;
        ImageUrl = imageUrl;
        RetailPrice = retailPrice;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public int Pieces { get; set; }
    public int MiniFigs { get; set; }
    public int MinAge { get; set; }
    public string ImageUrl { get; set; }
    private double retailPrice {  get; set; }
    public double RetailPrice
    {
        get { return RetailPrice; }
        set
        {
            if (retailPrice < 0)
            {
                throw new LegoException("De prijs moet groter dan 0 zijn");
            }
            RetailPrice = retailPrice;
        }
    }

    public override string ToString()
    {
        return $"{Id},{Name},{Year},{Pieces},{MiniFigs},{MinAge},{RetailPrice?.ToString(CultureInfo.InvariantCulture) ?? "null"},{ImageUrl}";
    }
}