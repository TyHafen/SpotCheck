using System.Data;
using Dapper;
using SpotCheck.Models;

namespace SpotCheck.Repositories
{
    public class SpotsRepository
    {
        private readonly IDbConnection _db;

        public SpotsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Spot Create(Spot data)
        {
            string sql = @"INSERT INTO
	    spots (name, address, description, creatorId, price)
        VALUES (@Name, @Address, @Description, @CreatorId, @Price);
        SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, data);
            data.Id = id;
            return data;
        }
    }
}