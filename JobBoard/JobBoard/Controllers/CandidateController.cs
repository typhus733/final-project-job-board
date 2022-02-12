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
                result = result.Where(c => c.ID.StartsWith(candidateId, StringComparison.InvariantCultureIgnoreCase));
            }

            return Ok(result
                .OrderBy(c => c.ID)
                .Take(15));
        }
    }
}
