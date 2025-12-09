using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvinciesDL_File;

namespace ProvinciesUtil.Factories {
    public static class ProvincieBestandLezerFactory 
    {
        public static IProvincieBestandLezer GetBestandLezer() 
        {
            return new ProvincieBestandLezer();
        }
    }
}
