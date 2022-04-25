using Dapper;
using JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.DAO
{
    public class InterviewDao
    {
        private readonly DapperContext _context;

        public InterviewDao(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<InterviewResponse>> GetInterviews()
        {
            var query = $"SELECT * FROM Interview";
            using (var connection = _context.CreateConnection())
            {
                var interviews = await connection.QueryAsync<InterviewResponse>(query);

                return interviews.ToList();
            }
        }

        public async Task<InterviewResponse> GetInterviewById(int id)
        {
            var query = $"SELECT * FROM Interview WHERE Id = {id}";

            using (var connection = _context.CreateConnection())
            {
                var interview = await connection.QueryFirstOrDefaultAsync<InterviewResponse>(query);
                return interview;
            }
        }

        public async Task DeleteInterviewById(int id)
        {
            var query = $"DELETE FROM Interview WHERE Id = {id}";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async Task UpdateInterviewById(InterviewResponse updateRequest)
        {
            var query = $"UPDATE Interview SET PositionId= {updateRequest.PositionID}, CandidateId={updateRequest.CandidateID}," +
                        $"StartTime='{updateRequest.StartTime}', EndTime='{updateRequest.EndTime}' WHERE Id='{updateRequest.Id}'";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }

        }
        
        public async Task CreateInterview(InterviewResponse insertRequest)
        {
            var query = $"INSERT INTO Interview (PositionID, CandidateID, StartTime, EndTime) VALUES ({insertRequest.PositionID}, {insertRequest.CandidateID}, '{insertRequest.StartTime}', '{insertRequest.EndTime}')";

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async Task<IEnumerable<InterviewResponse>> GetInterviewsbyCandidateId(int id)
        {
            var query = $"SELECT * FROM Interview WHERE CandidateID = {id}";

            using (var connection = _context.CreateConnection())
            {
                var interviews = await connection.QueryAsync<InterviewResponse>(query);
                return interviews.ToList();
            }
        }

        public async Task<IEnumerable<InterviewResponse>> GetInterviewsbyPositionId(int id)
        {
            var query = $"SELECT * FROM Interview WHERE PositionID = {id}";

            using (var connection = _context.CreateConnection())
            {
                var interviews = await connection.QueryAsync<InterviewResponse>(query);
                return interviews.ToList();
            }
        }

        public async Task<IEnumerable<InterviewResponse>> GetInterviewsbyLocationId(int id)
        {
            var query = $"SELECT Interview.Id, Interview.PositionId, Interview.CandidateId, Interview.StartTime, Interview.EndTime, Position.LocationId " +
            $"From Interview Join Position ON Interview.PositionId = Position.Id Join Location on Position.LocationId = Location.Id " +
            $"Where Location.Id = { id}";

            using (var connection = _context.CreateConnection())
            {
                var interviews = await connection.QueryAsync<InterviewResponse>(query);
                return interviews.ToList();
            }
        }

        public async Task<IEnumerable<InterviewResponse>> GetInterviewsbyDate(DateTime date)
        {
            var query = $"SELECT * FROM Interview WHERE StartTime BETWEEN '{date.ToString("MM'-'dd'-'yyyy")}' and '{date.ToString("MM'-'dd'-'yyyy")} 23:59:59'";

            using (var connection = _context.CreateConnection())
            {
                var interviews = await connection.QueryAsync<InterviewResponse>(query);
                return interviews.ToList();
            }
        }

    }
}
