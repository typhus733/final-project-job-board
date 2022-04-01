using Dapper;
using JobBoard.Models;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Location>> GetLocations()
        {
            var query = $"SELECT * FROM Location";
            using (var connection = _context.CreateConnection())
            {
                var locations = await connection.QueryAsync<Location>(query);

                return locations.ToList();
            }
        }

        public async Task<Location> GetLocationById(int id)
        {
            var query = $"SELECT * FROM Location WHERE Id = {id}";

            using (var connection = _context.CreateConnection())
            {
                var location = await connection.QueryFirstOrDefaultAsync<Location>(query);
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
        
        public async Task UpdateLocationById(Location updateRequest)
        {
            var query = $"UPDATE Location SET LocationName= '{updateRequest.LocationName}', StreetAddress='{updateRequest.StreetAddress}', City='{updateRequest.City}',"+
                        $"State='{updateRequest.State}', Zip='{updateRequest.Zip}' WHERE Id='{updateRequest.Id}'";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }

        }

        public async Task CreateLocation (Location insertRequest)
        {
            var query = $"SET Identity_INSERT Location ON INSERT INTO Location " +
                $"(Id, LocationName, StreetAddress, City, State, Zip) VALUES ({insertRequest.Id}, '{insertRequest.LocationName}', " +
                $"'{insertRequest.StreetAddress}', '{insertRequest.City}', '{insertRequest.State}', '{insertRequest.Zip}')";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }


    }
}
