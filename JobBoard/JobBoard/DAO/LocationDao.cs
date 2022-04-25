using Dapper;
using JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.DAO
{
    public class LocationDao
    {
        private readonly DapperContext _context;

        public LocationDao(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LocationResponse>> GetLocations(LocationRequest locationParams)
        {
            var query = $"SELECT * FROM Location WHERE 1= 1 ";

            if (!string.IsNullOrEmpty(locationParams.Name))
            {
                query += "AND Name = @Name ";
            }
            if (!string.IsNullOrEmpty(locationParams.Street))
            {
                query += "AND Street = @Street ";
            }
            if (!string.IsNullOrEmpty(locationParams.City))
            {
                query += "AND City = @City ";
            }
            if (!string.IsNullOrEmpty(locationParams.State))
            {
                query += "AND State = @State ";
            }
            if (!string.IsNullOrEmpty(locationParams.Zip.ToString()))
            {
                query += "AND Zip = @Zip ";
            }

            var parameters = new DynamicParameters();
            parameters.Add("Name", locationParams.Name, DbType.String);
            parameters.Add("Street", locationParams.Street, DbType.String);
            parameters.Add("City", locationParams.City, DbType.String);
            parameters.Add("State", locationParams.State, DbType.String);
            parameters.Add("Zip", locationParams.Zip, DbType.Int32);


            using (var connection = _context.CreateConnection())
            {
                var locations = await connection.QueryAsync<LocationResponse>(query, parameters);
                return locations.ToList();
            }
        }

        public async Task<LocationResponse> GetLocationById(int id)
        {
            var query = $"SELECT * FROM Location WHERE Id = {id}";

            using (var connection = _context.CreateConnection())
            {
                var location = await connection.QueryFirstOrDefaultAsync<LocationResponse>(query);
                return location;
            }
        }

        public async Task DeleteLocationById(int id)
        {
            var query = $"DELETE FROM Location WHERE Id = {id}";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }
        
        public async Task UpdateLocationById(LocationRequest updateRequest, int Id, LocationResponse existingLocation)
        {
            var query = $"UPDATE Location SET Name= '{updateRequest.Name ?? existingLocation.Name}', Street='{updateRequest.Street ?? existingLocation.Street}', " +
                        $"City='{updateRequest.City ?? existingLocation.City}', State='{updateRequest.State ?? existingLocation.State}', " +
                        $"Zip='{updateRequest.Zip ?? existingLocation.Zip}' WHERE Id='{Id}'";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }

        }

        public async Task CreateLocation (LocationRequest insertRequest)
        {
            var query = $"INSERT INTO Location (Name, Street, City, State, Zip) VALUES ('{insertRequest.Name}', '{insertRequest.Street}', '{insertRequest.City}', '{insertRequest.Street}',  {insertRequest.Zip}) ";


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }


    }
}
