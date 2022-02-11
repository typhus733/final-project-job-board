﻿using JobBoard.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class DataSeed
    {
        public static void InitData(LocationContext context)
        {
            Location returnLocation = new Location()
            {
                LocationID = "123",
                CompanyName = "Taco Bell",
                Address = "1 Taco Bell Ave",
                PositionList = new List<Position>(),
                InterviewList = new List<Interview>()
            };
            Candidate seedCandidate = new Candidate()
            {
                ID = "567",
                Name = "Chihuahua",
                Phone = "8675309",
                Email = "test@candidateemail.com"
            };

            Position seedPosition = new Position()
            {
                PositionID = "345",
                Title = "Cashier",
                Description = "Tough Job",
                PositionInterviews = new List<Interview>()
            };

            Interview seedInterview = new Interview()
            {
                Id = seedCandidate.ID,
                //InterviewPosition = seedPosition,
                //InterviewLocation = returnLocation,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now

            };

            returnLocation.InterviewList.Add(seedInterview);
            returnLocation.PositionList.Add(seedPosition);
            seedPosition.PositionInterviews.Add(seedInterview);
            context.Locations.Add(returnLocation);

            //context.Locations.Add(new Location
            //{
            //    LocationID = "123",
            //    CompanyName = "Taco Bell",
            //    Address = "1 Taco Bell Ave",
            //    PositionList = locationPositions,
            //    InterviewList = locationInterviews

            //});


            //return new Location
            //{
            //    LocationID = "123",
            //    CompanyName = "Taco Bell",
            //    Address = "1 Taco Bell Ave",
            //    PositionList = locationPositions,
            //    InterviewList = locationInterviews

            //};

            context.SaveChanges();
        }
        
    }
}
