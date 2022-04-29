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
        // 
        public async Task<IEnumerable<CandidateResponse>> GetCandidates(CandidateRequest querycandidate)
        {
            var query = $"SELECT * FROM Candidate WHERE 1= 1 ";
                       
            if (!string.IsNullOrEmpty(querycandidate.First_Name))
            {
                query += "AND First_Name = @First_Name ";
            }
            if (!string.IsNullOrEmpty(querycandidate.Last_Name))
            {
                query += "AND Last_Name = @Last_Name ";
            }
            if (!string.IsNullOrEmpty(querycandidate.PhoneNumber))
            {
                query += "AND PhoneNumber = @PhoneNumber ";
            }
            if (!string.IsNullOrEmpty(querycandidate.Email))
            {
                query += "AND Email = @Email ";
            }
           
           
            var parameters = new DynamicParameters();         
            parameters.Add("First_Name", querycandidate.First_Name, DbType.String);
            parameters.Add("Last_Name", querycandidate.Last_Name, DbType.String);
            parameters.Add("PhoneNumber", querycandidate.PhoneNumber, DbType.String);
            parameters.Add("Email", querycandidate.Email, DbType.String);


            using (var connection = _context.CreateConnection())
            {
                var candidates = await connection.QueryAsync<CandidateResponse>(query, parameters);
                return candidates.ToList();
            }
        }

        public async Task<CandidateResponse> GetCandidateById(int id)
        {
            var query = $"SELECT * FROM Candidate WHERE Id = {id}";

            using (var connection = _context.CreateConnection())
            {
                var candidate = await connection.QueryFirstOrDefaultAsync<CandidateResponse>(query);
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

        public async Task UpdateCandidateById(CandidateRequest updateRequest, int Id, CandidateResponse existingCandidate)
        {
            var query = $"UPDATE Candidate SET First_Name= '{updateRequest.First_Name ?? existingCandidate.First_Name}', " + 
                        $"Last_Name= '{updateRequest.Last_Name ?? existingCandidate.Last_Name}', " + 
                        $"PhoneNumber='{updateRequest.PhoneNumber ?? existingCandidate.PhoneNumber}', " +
                        $"Email='{updateRequest.Email ?? existingCandidate.Email}' WHERE Id='{Id}'";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }

        }

        public async Task CreateCandidate(CandidateRequest insertRequest)
        {


            var query = $"INSERT INTO Candidate (First_Name, Last_Name, PhoneNumber, Email) VALUES ('{insertRequest.First_Name}', '{insertRequest.Last_Name}', '{insertRequest.PhoneNumber}', '{insertRequest.Email}')";


            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async Task<IEnumerable<PositionResponse>> GetPositionsByCandidateId(int id)
        {
            var query = $"Select Interview.Id, PositionId, Position.Title, CandidateId, Candidate.First_Name, Candidate.Last_Name, Position.Department, Position.LocationId, Position.isFullTime from Interview JOIN Position ON Interview.PositionId = Position.Id " +
            $"JOIN Candidate ON Interview.CandidateId = Candidate.Id WHERE Candidate.Id = {id}";
            using (var connection = _context.CreateConnection())
            {
                var positions = await connection.QueryAsync<PositionResponse>(query);
                return positions.ToList();
            }
        }        


    }
}
