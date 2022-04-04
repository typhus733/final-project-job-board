﻿using JobBoard.DAO;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertPosition([FromBody] Position insertRequest)
        {
            try
            {
                await _positionDao.CreatePosition(insertRequest);
                return Ok(insertRequest);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("positions")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    }
}
