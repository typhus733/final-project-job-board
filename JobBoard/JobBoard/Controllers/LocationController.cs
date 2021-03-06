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

        /// <summary>
        /// Get Location by Filter
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("locations/search")]
        public async Task<IActionResult> GetLocations([FromQuery] LocationRequest locationParams)
        {
            try
            {
                var locations = await _locationDao.GetLocations(locationParams);
                if (locations.Count() == 0)
                {
                    return StatusCode(404);
                }
                return Ok(locations);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Get Location by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Post new Location
        /// </summary>
        /// <param name="insertRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("locations")]
        public async Task<IActionResult> CreateLocation([FromBody] LocationRequest insertRequest)
        {
            try
            {
                await _locationDao.CreateLocation(insertRequest);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Update Location by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("locations/{id}")]
        public async Task<IActionResult> UpdateLocationById([FromRoute] int id, [FromBody]LocationRequest updateRequest)
        {
            try
            {
                var location = await _locationDao.GetLocationById(id);
                if (location == null)
                {
                    return StatusCode(404);
                }

                await _locationDao.UpdateLocationById(updateRequest, id, location);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Delete Location 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
