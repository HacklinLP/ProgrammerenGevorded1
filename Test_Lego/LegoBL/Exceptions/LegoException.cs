using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBL.Exceptions
{
    public class LegoException : Exception
    {
        public LegoException()
        {
        }

        public LegoException(string? message) : base(message)
        {
        }

        public LegoException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
