using LegoBL.Interfaces;

namespace LegoUtil
{
    public class LegoRepositoryFactory
    {
        public static ILegoRepository GetRepository(string connectionString)
        {
            return new LegoRepository(connectionString);
        }

    }
}
