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
    public class InterviewController : ControllerBase
    {
        private readonly InterviewDao _interviewDao;

        public InterviewController(InterviewDao interviewDao)
        {
            _interviewDao = interviewDao;
        }

        [HttpGet]
        [Route("interviews")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInterviews()
        {
            try
            {
                var interviews = await _interviewDao.GetInterviews();
                return Ok(interviews);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("interviews/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInterviewById([FromRoute] int id)
        {
            try
            {
                var interview = await _interviewDao.GetInterviewById(id);
                if (interview == null)
                {
                    return StatusCode(404);
                }
                return Ok(interview);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        [Route("interviews")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertInterview([FromBody] Interview insertRequest)
        {
            try
            {
                await _interviewDao.CreateInterview(insertRequest);
                return Ok(insertRequest);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("interviews")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateInterviewById([FromBody] Interview updateRequest)
        {
            try
            {
                var interview = await _interviewDao.GetInterviewById(updateRequest.Id);
                if (interview == null)
                {
                    return StatusCode(404);
                }

                await _interviewDao.UpdateInterviewById(updateRequest);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("interviews/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteInterviewById([FromRoute] int id)
        {
            try
            {
                var interview = await _interviewDao.GetInterviewById(id);
                if (interview == null)
                {
                    return StatusCode(404);
                }

                await _interviewDao.DeleteInterviewById(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

