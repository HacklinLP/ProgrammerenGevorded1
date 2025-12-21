namespace VakantieparkDL.TO
{
    public class VakantieparkTO
    {
        public VakantieparkTO(int? id, string naam, string locatie, int contactpersoonID)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
            ContactpersoonID = contactpersoonID;
        }

        public int? Id { get; set; }
        public string Naam { get; set; }
        public string Locatie { get; set; }
        public int ContactpersoonID { get; set; }
       
    }
}
