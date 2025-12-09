using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Model;

namespace BL.Interfaces 
{
    public interface IProvincieRepository
    {
        void UploadToDatabase(List<Provincie> data);
        
    }
}
