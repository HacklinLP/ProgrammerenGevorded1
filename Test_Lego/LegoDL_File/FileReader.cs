using LegoBL.Interfaces;
using LegoDL_File.Model;
using System.IO;

public class FileReader : IFileReader
{
    public List<LegoSet> ReadFile(string path)
    {
        Dictionary<int, LegoSetDL> legoSets = new();

        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] ss = line.Split('|');
                int set_Id = int.Parse(ss[0]);
                string naam = ss[1];
                int jaar = int.Parse(ss[2]);
                string thema = ss[3];
                int aantalBlokjes = int.Parse(ss[8]);
                int aantalMinifigs = int.Parse(ss[9]);
                int minimumLeeftijd = int.Parse(ss[10]);
                int verkoopsprijs = int.Parse(ss[11]);
                string imageURL = ss[14];

            }
            return Converteer(legoSets.Values.ToList());
        }
    }

    private List<LegoSet> Converteer(List<LegoSetDL> data)
    {
        List<LegoSet> legoSets = new();
        foreach (LegoSetDL legoSet in data)
        {
            legoSets.Add(new LegoSet(legoSet.Naam));
        }
        return legoSets;
    }
}