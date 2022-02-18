using JobBoard.DAO;
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

            var locationList = _context.Locations as IQueryable<Location>;
            var positionList = _context.Positions as IQueryable<Position>;
            var candidateList = _context.Candidates as IQueryable<Candidate>;

            foreach (Interview interview in result)
            {
                foreach (Location location in locationList)
                { 
                    if (interview.LocationID == location.LocationID)
                    interview.LocationID = location.LocationName; 
                }
                foreach (Position position in positionList)
                {
                    if (interview.PositionID == position.PositionID)
                        interview.PositionID =position.Title;
                }
                foreach (Candidate candidate in candidateList)
                {
                    if (interview.CandidateID == candidate.CandidateID)
                        interview.CandidateID = candidate.Name;
                }
            }

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
        [Route("{interviewID}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Interview> PatchInterview([FromRoute] string interviewID, [FromBody] InterviewPatch newInterview)
        {
            try
            {
                var interviewList = _context.Interviews as IQueryable<Interview>;
                var interview = interviewList.First(p => p.InterviewID.Equals(interviewID));

                interview.CandidateID = newInterview.CandidateID ?? interview.CandidateID;
                interview.PositionID = newInterview.PositionID ?? interview.PositionID;
                interview.LocationID = newInterview.LocationID ?? interview.LocationID;
                interview.StartTime = newInterview.StartTime ?? interview.StartTime;
                interview.EndTime = newInterview.EndTime ?? interview.EndTime;

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
        [Route("{interviewID}")]
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

