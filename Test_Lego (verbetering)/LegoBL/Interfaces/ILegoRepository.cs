using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LegoBL.Interfaces
{
    public interface ILegoRepository
    {
        public void WriteLegoThemes(List<LegoSet> data);
    }
}
