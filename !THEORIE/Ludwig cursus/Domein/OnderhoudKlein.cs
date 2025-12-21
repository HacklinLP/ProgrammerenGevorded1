using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein
{
    public class OnderhoudKlein : Onderhoud
    {
        public OnderhoudKlein(DateTime begindatum, string nummerplaat) : base(begindatum, begindatum, nummerplaat)
        {

        }
    }
}
