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

        //No ID for interviews but this filters interviews by location
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Interview>> GetInterview([FromQuery] string locationId)
        {
            var result = _context.Interviews as IQueryable<Interview>;

            if (!string.IsNullOrEmpty(locationId))
            {
                result = result.Where(i => i.LocationID.StartsWith(locationId, StringComparison.InvariantCultureIgnoreCase));
            }

            return Ok(result
                .OrderBy(i => i.CandidateId)
                .Take(15));
        }
    }
}

