using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StadontwikkelingGentBL.Domein
{
    public class Faciliteit
    {

        public Faciliteit(string soort, bool vast)
        {
            Soort = soort;
            Vast = vast;
        }

        public Faciliteit(int id, string soort, bool vast)
        {
            Id = id;
            Soort = soort;
            Vast = vast;
        }

        public int Id { get; init; }
        public string Soort { get; set; }
        private bool _vast;
        public bool Vast
        {
            get => _vast;
            set
            {
                if (value == null) _vast = false;
                else _vast = true;
            }
        }
    }
}
