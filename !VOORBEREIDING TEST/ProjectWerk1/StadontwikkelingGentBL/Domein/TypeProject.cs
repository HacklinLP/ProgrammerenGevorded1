using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Domein
{
    public abstract class TypeProject
    {
        protected TypeProject(int iD)
        {
            ID = iD;
        }

        protected TypeProject() { }

        public int ID { get; init; }
    }
}
