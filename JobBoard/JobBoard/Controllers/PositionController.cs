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

        [HttpGet]
        [Route("positions")]
        public async Task<IActionResult> GetPositions()
        {
            try
            {
                var positions = await _positionDao.GetPositions();
                return Ok(positions);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

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


        [HttpPost]
        [Route("positions")]
        public async Task<IActionResult> CreatePosition([FromBody] Position insertRequest)
        {
            try
            {
                await _positionDao.CreatePosition(insertRequest);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("positions")]
        public async Task<IActionResult> UpdatePositionById([FromBody] Position updateRequest)
        {
            try
            {
                var position = await _positionDao.GetPositionById(updateRequest.Id);
                if (position == null)
                {
                    return StatusCode(404);
                }

                await _positionDao.UpdatePositionById(updateRequest);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

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

        [HttpGet]
        [Route("positions/locations/{id}")]
        public async Task<IActionResult> GetPositionsByLocationId([FromRoute] int id)
        {
            try
            {
                var positions = await _positionDao.GetPositionsByLocationId(id);
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
