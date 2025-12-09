using ProvinciesBL.Exceptions;

namespace ProvinciesBL.Model
{
    public class Provincie
    {
        public int? Id { get; set; }
        public string Naam { get; set; }

        public Provincie(string naam, List<Gemeente> data)
        {
            Naam = naam;
            if (data == null || data.Count == 0)
                throw new ProvincieException("Gemeentes niet ok");
            else
                gemeentes = data;

        }

        private List<Gemeente> gemeentes = new();
        public IReadOnlyList<Gemeente> Gemeentes => gemeentes;
        public void VoegGemeentesToe(Gemeente gemeente)
        {
            if (gemeentes == null)
                throw new ProvincieException("gemeente is null");
            else
                gemeentes.Add(gemeente);
        }
        
    }
}
