using RogovTRPO8.Models;

namespace RogovTRPO8.Services

{
    public class DBService
    {
        private RogovDbContext context;
        public RogovDbContext Context => context;
        private static DBService? instance;
        public static DBService Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBService( );
                return instance;
            }
        }
        private DBService ()
        {
            context = new RogovDbContext( );
        }
    }
}