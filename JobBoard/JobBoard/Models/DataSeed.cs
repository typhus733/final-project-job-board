using JobBoard.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class DataSeed
    {
        public static void InitData(JobBoardContext context)
        {
            Location returnLocation = new Location()
            {
                LocationID = "123",
                LocationName = "Taco Bell",
                Address = "1 Taco Bell Ave" 
            };
            Candidate seedCandidate = new Candidate()
            {
                CandidateID = "567",
                Name = "Chihuahua",
                Phone = "8675309",
                Email = "test@candidateemail.com"                
            };

            Position seedPosition = new Position()
            {
                PositionID = "345",
                Title = "Cashier",
                Description = "Tough Job",
                LocationID = returnLocation.LocationID
            };

            Interview seedInterview = new Interview()
            {
                InterviewID = "102",
                CandidateID = seedCandidate.CandidateID,
                PositionID = seedPosition.PositionID,
                LocationID = returnLocation.LocationID,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };           
           
            Location returnLocation2 = new Location()
            {
                LocationID = "321",
                LocationName = "Burger King",
                Address = "1 Burger King Ave"
            };

            Candidate seedCandidate2 = new Candidate()
            {
                CandidateID = "765",
                Name = "The King",
                Phone = "0987654321",
                Email = "test@candidateemail.com"
            };

            Position seedPosition2 = new Position()
            {
                PositionID = "543",
                Title = "Flipper",
                Description = "Worst job ever",
                LocationID = returnLocation2.LocationID
            };

            Interview seedInterview2 = new Interview()
            {
                InterviewID = "103",
                CandidateID = seedCandidate2.CandidateID,
                PositionID = seedPosition2.PositionID,
                LocationID = returnLocation2.LocationID,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now
            };

            context.Locations.Add(returnLocation);
            context.Positions.Add(seedPosition);
            context.Interviews.Add(seedInterview);
            context.Candidates.Add(seedCandidate);

            context.Locations.Add(returnLocation2);
            context.Positions.Add(seedPosition2);
            context.Interviews.Add(seedInterview2);
            context.Candidates.Add(seedCandidate2);

            context.SaveChanges();
        }

    }
}