using Dapper;
using JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.DAO
{
    public class PositionDao
    {
        private readonly DapperContext _context;

        public PositionDao(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Position>> GetPositions()
        {
            var query = $"SELECT * FROM Position";
            using (var connection = _context.CreateConnection())
            {
                var positions = await connection.QueryAsync<Position>(query);

                return positions.ToList();
            }
        }

        public async Task<Position> GetPositionById(int id)
        {
            var query = $"SELECT * FROM Position WHERE Id = {id}";

            using (var connection = _context.CreateConnection())
            {
                var position = await connection.QueryFirstOrDefaultAsync<Position>(query);
                return position;
            }
        }

        public async Task DeletePositionById(int id)
        {
            var query = $"DELETE FROM Position WHERE Id = {id}";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async Task UpdatePositionById(Position updateRequest)
        {
            var query = $"UPDATE Position SET Title= '{updateRequest.Title}', Description='{updateRequest.Description}', LocationId='{updateRequest.LocationID}'," +
                        $"IsFullTime='{updateRequest.IsFulltime}' WHERE Id='{updateRequest.Id}'";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }

        }

        public async Task CreatePosition(Position insertRequest)
        {
            var query = $"SET Identity_INSERT Position ON INSERT INTO Position " +
                $"(Id, Title, Description, LocationId, IsFullTime) VALUES ({insertRequest.Id}, '{insertRequest.Title}', " +
                $"'{insertRequest.Description}', '{insertRequest.LocationID}', '{insertRequest.IsFulltime}')";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

    }
}
