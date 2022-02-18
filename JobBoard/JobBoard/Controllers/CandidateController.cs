using JobBoard.DAO;
using JobBoard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace JobBoard.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class CandidateController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public CandidateController(JobBoardContext context)
        {
            _context = context;

            if (_context.Candidates.Any()) return;

            DataSeed.InitData(context);
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Candidate>> GetCandidate([FromQuery] string candidateId)
        {
            var result = _context.Candidates as IQueryable<Candidate>;

            if (!string.IsNullOrEmpty(candidateId))
            {
                result = result.Where(c => c.CandidateID.StartsWith(candidateId, StringComparison.InvariantCultureIgnoreCase));
            }

            return Ok(result
                .OrderBy(c => c.CandidateID)
                .Take(15));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Location> PostCandidate([FromBody] Candidate candidate)
        {
            try
            {

                _context.Candidates.Add(candidate);
                _context.SaveChanges();

                return new CreatedResult($"/candidates/{candidate.CandidateID.ToLower()}", candidate);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }
        
        [HttpPatch]
        [Route("{candidateID}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Location> PatchCandidate([FromRoute] string candidateID, [FromBody] CandidatePatch newCandidate)
        {
            try
            {
                var candidateList = _context.Candidates as IQueryable<Candidate>;
                var candidate = candidateList.First(p => p.CandidateID.Equals(candidateID));

                candidate.Name = newCandidate.Name ?? candidate.Name;
                candidate.Phone = newCandidate.Phone ?? candidate.Phone;
                candidate.Email = newCandidate.Email ?? candidate.Email;
                


                _context.Candidates.Update(candidate);
                _context.SaveChanges();

                return new CreatedResult($"/candidates/{candidate.CandidateID.ToLower()}", candidate);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{candidateID}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Candidate> DeleteCandidate([FromRoute] string candidateID)
        {
            try
            {
                var candidateList = _context.Candidates as IQueryable<Candidate>;
                var candidate = candidateList.First(p => p.CandidateID.Equals(candidateID));

                _context.Candidates.Remove(candidate);
                _context.SaveChanges();

                return new CreatedResult($"/candidates/{candidate.CandidateID.ToLower()}", candidate);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }
    }
}
