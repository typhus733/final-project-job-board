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
    public class PositionController : ControllerBase
    {
        private readonly PositionDao _positionDao;

        public PositionController(PositionDao positionDao)
        {
            _positionDao = positionDao;
        }

        /// <summary>
        /// Get Position by Filter
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("positions/search")]
        public async Task<IActionResult> GetPositions([FromQuery] PositionRequest positionParams)
        {
            try
            {
                var positions = await _positionDao.GetPositions(positionParams);
                if (positions.Count() == 0)
                {
                    return StatusCode(404);
                }
                return Ok(positions);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Get Position by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("positions/{id}")]
        public async Task<IActionResult> GetPositionById([FromRoute] int id)
        {
            try
            {
                var position = await _positionDao.GetPositionById(id);
                if (position == null)
                {
                    return StatusCode(404);
                }
                return Ok(position);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Post new Position
        /// </summary>
        /// <param name="insertRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("positions")]
        public async Task<IActionResult> CreatePosition([FromBody] PositionRequest insertRequest)
        {
            try
            {
                await _positionDao.CreatePosition(insertRequest);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Update Position by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("positions/{id}")]
        public async Task<IActionResult> UpdatePositionById([FromRoute] int id, [FromBody] PositionRequest updateRequest)
        {
            try
            {
                var position = await _positionDao.GetPositionById(id);
                if (position == null)
                {
                    return StatusCode(404);
                }

                await _positionDao.UpdatePositionById(updateRequest, id, position);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Delete Position
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("positions/{id}")]
        public async Task<IActionResult> DeletePositionById([FromRoute] int id)
        {
            try
            {
                var position = await _positionDao.GetPositionById(id);
                if (position == null)
                {
                    return StatusCode(404);
                }

                await _positionDao.DeletePositionById(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Get Positions by LocationId
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("positions/locations/{locationId}")]
        public async Task<IActionResult> GetPositionsByLocationId([FromRoute] int locationId)
        {
            try
            {
                var positions = await _positionDao.GetPositionsByLocationId(locationId);
                if (positions.Count() == 0)
                {
                    return StatusCode(404);
                }
                return Ok(positions);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
