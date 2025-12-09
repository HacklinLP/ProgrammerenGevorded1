using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresLINQ
{
    public class AdresInfo
    {
        private string _source;
        private List<Data> _adressen;

        public AdresInfo(string source)
        {
            this._source = source;
            _adressen = new List<Data>();
        }
        public void readData()
        {
            using (StreamReader sr = new StreamReader(_source))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] x = line.Trim().Split(',');
                    _adressen.Add(new Data(x[0], x[1], x[2]));
                }
            }
            
        }

        public List<string> getProvincies()
        {
            return _adressen.Select(a=>a.Provincie).Distinct().OrderBy(x=>x).ToList(); // duidelijk
        }

        public List<string> getStraatnamen(string gemeente)
        {
            return _adressen.Where(x=>x.Gemeente==gemeente).Select(x=>x.Straatnaam).OrderBy(x=>x.Length).ToList();
        }

        public string langsteStraatnaam()
        {
            return _adressen.Select(x => x.Straatnaam).Max(x => x.Length).First
        }


    }
}
