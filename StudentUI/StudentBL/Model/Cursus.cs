namespace StudentBL.Model
{
    public class Cursus
    {
        public int? Id { get; set; }
        public string Naam { get; set; }

        public Cursus(string naam)
        {
            Naam = naam;
        }

        public Cursus(int? id, string naam)
        {
            Id = id;
            Naam = naam;
        }
    }
}
