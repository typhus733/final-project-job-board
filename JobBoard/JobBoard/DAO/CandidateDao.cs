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


            var query = $"INSERT INTO Candidate (Name, PhoneNumber, Email) VALUES ('{insertRequest.Name}', '{insertRequest.PhoneNumber}', '{insertRequest.Email}')";


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async Task<IEnumerable<Position>> GetPositionsByCandidateId(int id)
        {
            var query = $"Select Interview.Id, PositionId, Position.Title, CandidateId, Candidate.Name, Position.Department, Position.LocationId, Position.isFullTime from Interview JOIN Position ON Interview.PositionId = Position.Id " +
            $"JOIN Candidate ON Interview.CandidateId = Candidate.Id WHERE Candidate.Id = { id}";
            using (var connection = _context.CreateConnection())
            {
                var positions = await connection.QueryAsync<Position>(query);
                return positions.ToList();
            }
        }        
    }
}
