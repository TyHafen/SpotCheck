using System.Data;

namespace SpotCheck.Repositories
{
    public class SpotsRepository
    {
        private readonly IDbConnection _db;

        public SpotsRepository(IDbConnection db)
        {
            _db = db;
        }


    }
}