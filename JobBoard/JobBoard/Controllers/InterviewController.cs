﻿using JobBoard.DAO;
using JobBoard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class InterviewController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public InterviewController(JobBoardContext context)
        {
            _context = context;

            if (_context.Interviews.Any()) return;

            DataSeed.InitData(context);
        }

        
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Interview>> GetInterview([FromQuery] string interviewId)
        {
            var result = _context.Interviews as IQueryable<Interview>;

            if (!string.IsNullOrEmpty(interviewId))
            {
                result = result.Where(i => i.InterviewID.StartsWith(interviewId, StringComparison.InvariantCultureIgnoreCase));
            }

            return Ok(result
                .OrderBy(i => i.InterviewID)
                .Take(15));
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Interview> PostInterview([FromBody] Interview interviewId)
        {
            try
            {

                _context.Interviews.Add(interviewId);
                _context.SaveChanges();

                return new CreatedResult($"/interviews/{interviewId.InterviewID.ToLower()}", interviewId);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }

        [HttpPatch]
        [Route("{interviewId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Location> PatchInterview([FromRoute] string interviewId, [FromBody] InterviewPatch newInterview)
        {
            try
            {
                var interviewList = _context.Interviews as IQueryable<Interview>;
                var interview = interviewList.First(p => p.InterviewID.Equals(interviewId));

                interview.CandidateID = newInterview.CandidateId ?? interview.CandidateID;
                interview.PositionID = newInterview.PositionID ?? interview.PositionID;
                interview.LocationID = newInterview.LocationID ?? interview.LocationID;



                _context.Interviews.Update(interview);
                _context.SaveChanges();

                return new CreatedResult($"/interviews/{interview.InterviewID.ToLower()}", interview);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }

        [HttpDelete]
        [Route("{interviewId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Interview> DeleteInterview([FromRoute] string interviewId)
        {
            try
            {
                var interviewList = _context.Interviews as IQueryable<Interview>;
                var interview = interviewList.First(p => p.InterviewID.Equals(interviewId));

                _context.Interviews.Remove(interview);
                _context.SaveChanges();

                return new CreatedResult($"/interview/{interview.InterviewID.ToLower()}", interview);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }
    }
}

