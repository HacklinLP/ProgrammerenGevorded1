using JobInterviewBL.Interfaces;
using JobInterviewDL;

namespace JobinterviewUtils
{
    public static class JobinterviewRepositoryFactory
    {
        public static IJobInterviewRepository GetJobinterviewRepository(string repoType)
        {
            switch (repoType)
            {
                case "memory": return new JobInterviewRepositoryMemory();
                default: return null;
            }
        }
    }
}
