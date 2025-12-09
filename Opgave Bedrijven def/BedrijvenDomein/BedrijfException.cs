using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedrijvenDomein
{
    public class BedrijfException : Exception
    {
        public List<string> Errors { get; set; }
        public BedrijfException()
        {
        }

        public BedrijfException(string? message) : base(message)
        {
        }

        public BedrijfException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
