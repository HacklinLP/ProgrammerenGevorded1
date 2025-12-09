using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvinciesDL_SQL;

namespace ProvinciesUtil.Factories {
    public class ProvincieRepositoryFactory {
        public static IProvincieRepository GeefRepository(string? connectionString)
        {
            throw new NotImplementedException();
        }

        public static IProvincieRepository GetRepository(string connectionString) {
            return new ProvincieRepository();
        }
    }
}
