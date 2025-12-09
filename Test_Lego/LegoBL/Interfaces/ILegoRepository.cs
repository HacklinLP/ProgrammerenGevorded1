using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LegoBL.Interfaces
{
    public interface ILegoRepository
    {
        void WriteLegoThemes(List<LegoSet> data);
    }
}
