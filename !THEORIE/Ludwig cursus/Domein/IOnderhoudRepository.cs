using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domein
{
    public interface IOnderhoudRepository
    {
        List<Onderhoud> GeefOnderhoudVanAutos();
    }
}