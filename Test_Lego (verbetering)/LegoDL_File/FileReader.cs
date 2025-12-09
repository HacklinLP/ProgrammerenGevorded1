using LegoBL.Interfaces;
using LegoDL_File.Model;
using System.IO;

public class FileReader : IFileReader
{
    public List<LegoSet> ReadFile(string path)
    {
        Dictionary<int, LegoSetDL> legoSets = new();
        Dictionary<string, LegoTheme> themes = new();

        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                string[] ss = line.Split('|');
                // if (string.IsNullOrWhiteSpace(ss[7])) continue;
                string Id = ss[0];
                string Name = ss[1];
                int Year = int.Parse(ss[2]);
                int Pieces = string.IsNullOrWhiteSpace(ss[7]) ? 0 : int.Parse(ss[7]);
                if (Pieces ==0) continue;
                int MiniFigs = string.IsNullOrWhiteSpace(ss[8]) ? 0 : int.Parse(ss[8]);
                int? MinAge = string.IsNullOrWhiteSpace(ss[9]) ? null : int.Parse(ss[9]);
                string ImageUrl = ss[13];
                double? RetailPrice = string.IsNullOrWhiteSpace(ss[10]) ? null : double.Parse(ss[10]);
                string Thema = ss[3];

                LegoSet legoSet = new LegoSet(Id, Name, Year, Pieces, MiniFigs, MinAge, ImageUrl, RetailPrice);

                if (!themes.ContainsKey(Thema)) themes.Add(Thema, new LegoTheme(Thema));
                themes[Thema].AddLegoSet(legoSet);

            }
            return Converteer(legoSets.Values.ToList());
        }
        return themes.Values.ToList();
    }

    private List<LegoSet> Converteer(List<LegoSetDL> data)
    {
        return null;
    }
}