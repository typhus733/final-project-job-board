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
    public class LocationController : ControllerBase
    {
        private readonly LocationContext _context;

        public LocationController(LocationContext context)
        {
            _context = context;

            if (_context.Locations.Any()) return;

            DataSeed.InitData(context);
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Location>> GetLocation([FromQuery] string locationId)
        {
            var result = _context.Locations as IQueryable<Location>;

            if (!string.IsNullOrEmpty(locationId))
            {
                result = result.Where(p => p.LocationID.StartsWith(locationId, StringComparison.InvariantCultureIgnoreCase));
            }

            return Ok(result
                .OrderBy(p => p.LocationID)
                .Take(15));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Location> PostLocation([FromBody] Location location)
        {
            try
            {

                _context.Locations.Add(location);
                _context.SaveChanges();

                return new CreatedResult($"/locations/{location.LocationID.ToLower()}", location);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }
        [HttpPatch]
        [Route("{locationId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Location> PatchLocation([FromRoute] string locationId, [FromBody] LocationPatch newLocation)
        {
            try
            {
                var locationList = _context.Locations as IQueryable<Location>;
                var location = locationList.First(p => p.LocationID.Equals(locationId));

                location.CompanyName = newLocation.CompanyName ?? location.CompanyName;
                location.Address = newLocation.Address ?? location.Address;
                location.PositionList = newLocation.PositionList ?? location.PositionList;
                location.InterviewList = newLocation.InterviewList ?? location.InterviewList;
               

                _context.Locations.Update(location);
                _context.SaveChanges();

                return new CreatedResult($"/locations/{location.LocationID.ToLower()}", location);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }

        [HttpDelete]
        [Route("{locationID}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Location> DeleteLocation([FromRoute] string locationID)
        {
            try
            {
                var locationList = _context.Locations as IQueryable<Location>;
                var location = locationList.First(p => p.LocationID.Equals(locationID));

                _context.Locations.Remove(location);
                _context.SaveChanges();

                return new CreatedResult($"/locations/{location.LocationID.ToLower()}", location);
            }
            catch (Exception e)
            {
                // Typically an error log is produced here
                return ValidationProblem(e.Message);
            }
        }
    }
}
