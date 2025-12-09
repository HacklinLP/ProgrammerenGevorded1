using LegoBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoUtil
{
    public class FileReaderFactory
    {
        public static IFileReader GetFileReader()
        {
            return new FileReader();
        }
    }
}
