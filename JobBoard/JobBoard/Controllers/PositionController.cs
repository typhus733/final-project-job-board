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


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Location> PostPosition([FromBody] Position position)
        {
            try
            {

                _context.Positions.Add(position);
                _context.SaveChanges();

                return new CreatedResult($"/positions/{position.PositionID.ToLower()}", position);
            }
            
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }

        [HttpPatch]
        [Route("{positionID}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Location> PatchPosition([FromRoute] string positionID, [FromBody] PositionPatch newPosition)
        {
            try
            {
                var positionList = _context.Positions as IQueryable<Position>;
                var position = positionList.First(p => p.PositionID.Equals(positionID));

                position.Title = newPosition.Title ?? position.Title;
                position.Description = newPosition.Description ?? position.Description;

                _context.Positions.Update(position);
                _context.SaveChanges();

                return new CreatedResult($"/positions/{position.PositionID.ToLower()}", position);
            }

            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{positionID}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Position> DeletePosition([FromRoute] string positionID)
        {
            try
            {
                var positionList = _context.Positions as IQueryable<Position>;
                var position = positionList.First(p => p.PositionID.Equals(positionID));

                var interviewList = _context.Interviews as IQueryable<Interview>;

                foreach (Interview i in interviewList)
                {
                    if (i.PositionID == positionID)
                    {
                        _context.Interviews.Remove(i);
                    }
                }

                _context.Positions.Remove(position);
                _context.SaveChanges();

                return new CreatedResult($"/positions/{position.PositionID.ToLower()}", position);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }
    }
}
