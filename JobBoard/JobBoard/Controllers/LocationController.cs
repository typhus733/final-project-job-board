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
    
    public class LocationController : ControllerBase
    {
        private readonly LocationDao _locationDao;

        public LocationController(LocationDao locationDao)
        {
            _locationDao = locationDao;
        }

        [HttpGet]
        [Route("locations")]
        public async Task<IActionResult> GetLocations()
        {
            try
            {
                var locations = await _locationDao.GetLocations();
                return Ok(locations);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("locations/{id}")]
        public async Task<IActionResult> GetLocationById([FromRoute]int id)
        {
            try
            {
                var location = await _locationDao.GetLocationById(id);
                if (location == null)
                {
                    return StatusCode(404);
                }
                return Ok(location);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        [Route("locations")]
        public async Task<IActionResult> CreateLocation([FromBody] Location insertRequest)
        {
            try
            {
                await _locationDao.CreateLocation(insertRequest);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("locations")]
        public async Task<IActionResult> UpdateLocationById ([FromBody]Location updateRequest)
        {
            try
            {
                var location = await _locationDao.GetLocationById(updateRequest.Id);
                if (location == null)
                {
                    return StatusCode(404);
                }

                await _locationDao.UpdateLocationById(updateRequest);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("locations/{id}")]
        public async Task<IActionResult> DeleteLocationById([FromRoute] int id)
        {
            try
            {
                var location = await _locationDao.GetLocationById(id);
                if (location == null)
                {
                    return StatusCode(404);
                }

                await _locationDao.DeleteLocationById(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);            
            }
        }
    }
}
