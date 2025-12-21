using Domein;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistentie
{
    public class OnderhoudRepository : IOnderhoudRepository
    {
        private OnderhoudMapper _onderhoudMapper = new OnderhoudMapper();

        public List<Onderhoud> GeefOnderhoudVanAutos() => _onderhoudMapper.GeefOnderhoudVanAutos();
    }
}
