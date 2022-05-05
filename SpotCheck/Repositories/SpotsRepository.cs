using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        internal List<Spot> GetAll()
        {
            string sql = @"SELECT s.*, a.* FROM spots s JOIN accounts a ON s.creatorId = a.id;";
            return _db.Query<Spot, Account, Spot>(sql, (spot, account) =>
            {
                spot.Creator = account;
                return spot;
            }).ToList();
        }
    }
}