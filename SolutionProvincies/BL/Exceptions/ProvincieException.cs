using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Exceptions {
    public class ProvincieException : Exception {
        public ProvincieException() {
        }

        public ProvincieException(string? message) : base(message) {
        }

        public ProvincieException(string? message, Exception? innerException) : base(message, innerException) {
        }
    }
}
