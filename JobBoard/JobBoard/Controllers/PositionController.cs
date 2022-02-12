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
    public class PositionController : ControllerBase
    {
        private readonly JobBoardContext _context;

        public PositionController(JobBoardContext context)
        {
            _context = context;

            if (_context.Positions.Any()) return;

            DataSeed.InitData(context);
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Position>> GetPositions([FromQuery] string positionId)
        {
            var result = _context.Positions as IQueryable<Position>;

            if (!string.IsNullOrEmpty(positionId))
            {
                result = result.Where(p => p.PositionID.StartsWith(positionId, StringComparison.InvariantCultureIgnoreCase));
            }

            return Ok(result
                .OrderBy(p => p.PositionID)
                .Take(15));
        }
    }
}
