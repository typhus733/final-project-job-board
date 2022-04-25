using Dapper;
using JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        public async Task<IEnumerable<PositionResponse>> GetPositions(PositionRequest positionParams)
        {
            var query = $"SELECT * FROM Position WHERE 1= 1 ";

            if (!string.IsNullOrEmpty(positionParams.Title))
            {
                query += "AND Title = @Title ";
            }
            if (!string.IsNullOrEmpty(positionParams.Department))
            {
                query += "AND Department = @Department ";
            }
            if (!string.IsNullOrEmpty(positionParams.LocationID.ToString()))
            {
                query += "AND LocationId = @LocationId ";
            }
            if (positionParams.IsFulltime != null)
            {
                query += "AND IsFullTime = @IsFullTime ";
            }


            var parameters = new DynamicParameters();
            parameters.Add("Title", positionParams.Title, DbType.String);
            parameters.Add("Department", positionParams.Department, DbType.String);
            parameters.Add("LocationId", positionParams.LocationID, DbType.Int32);
            parameters.Add("IsFullTime", positionParams.IsFulltime, DbType.Boolean);
            


            using (var connection = _context.CreateConnection())
            {
                var positions = await connection.QueryAsync<PositionResponse>(query, parameters);
                return positions.ToList();
            }
        }

        public async Task<PositionResponse> GetPositionById(int id)
        {
            var query = $"SELECT * FROM Position WHERE Id = {id}";

            using (var connection = _context.CreateConnection())
            {
                var position = await connection.QueryFirstOrDefaultAsync<PositionResponse>(query);
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

        public async Task UpdatePositionById(PositionResponse updateRequest)
        {
            var query = $"UPDATE Position SET Title= '{updateRequest.Title}', Department='{updateRequest.Department}', LocationId='{updateRequest.LocationID}'," +
                        $"IsFullTime='{updateRequest.IsFulltime}' WHERE Id='{updateRequest.Id}'";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }

        }

        public async Task CreatePosition(PositionResponse insertRequest)
        {
            var query = $"INSERT INTO Position (Title, Department, LocationID, IsFullTime) VALUES ( '{insertRequest.Title}', '{insertRequest.Department}', {insertRequest.LocationID},  '{insertRequest.IsFulltime}')";


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }

        }

        public async Task<IEnumerable<PositionResponse>> GetPositionsByLocationId(int id)
        {
            var query = $"Select * from Position where LocationId = { id}";
            using (var connection = _context.CreateConnection())
            {
                var positions = await connection.QueryAsync<PositionResponse>(query);
                return positions.ToList();
            }
        }
    }
}
