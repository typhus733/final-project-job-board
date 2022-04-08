using Dapper;
using JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.DAO
{
    public class CandidateDao
    {
        private readonly DapperContext _context;

        public CandidateDao(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            var query = $"SELECT * FROM Candidate";
            using (var connection = _context.CreateConnection())
            {
                var locations = await connection.QueryAsync<Candidate>(query);

                return locations.ToList();
            }
        }

        public async Task<Candidate> GetCandidateById(int id)
        {
            var query = $"SELECT * FROM Candidate WHERE Id = {id}";

            using (var connection = _context.CreateConnection())
            {
                var candidate = await connection.QueryFirstOrDefaultAsync<Candidate>(query);
                return candidate;
            }
        }

        public async Task DeleteCandidateById(int id)
        {
            var query = $"DELETE FROM Candidate WHERE Id = {id}";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async Task UpdateCandidateById(Candidate updateRequest)
        {
            var query = $"UPDATE Candidate SET Name= '{updateRequest.Name}', PhoneNumber='{updateRequest.PhoneNumber}', Email='{updateRequest.Email}' WHERE Id='{updateRequest.Id}'";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }

        }

        public async Task CreateCandidate(Candidate insertRequest)
        {


            var query = $"INSERT INTO Candidate (Name, PhoneNumber, Email) VALUES (@Name, @PhoneNumber, @Email)";

            var parameters = new DynamicParameters();
            parameters.Add("Id", insertRequest.Id, DbType.Int32);
            parameters.Add("Name", insertRequest.Name, DbType.String);
            parameters.Add("PhoneNumber", insertRequest.PhoneNumber, DbType.String);
            parameters.Add("Email", insertRequest.Email, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

    }
}
