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
        /// <summary>
        /// Get all Interviews
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("interviews")]
        public async Task<IActionResult> GetInterviews()
        {
            try
            {
                var interviews = await _interviewDao.GetInterviews();
                if (interviews.Count() == 0)
                {
                    return StatusCode(404);
                }
                return Ok(interviews);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// Get Interviews by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("interviews/{id}")]
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

        /// <summary>
        /// Post new Interview
        /// </summary>
        /// <param name="insertRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("interviews")]
        public async Task<IActionResult> CreateInterview([FromBody] Interview insertRequest)
        {
            try
            {
                await _interviewDao.CreateInterview(insertRequest);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// Update Interview
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("interviews")]
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
        /// <summary>
        /// Delete Interview
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("interviews/{id}")]
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
        /// <summary>
        /// Get Interview by CandidateId
        /// </summary>
        /// <param name="candidateid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("interviews/candidates/{candidateid}")]
        public async Task<IActionResult> GetInterviewsbyCandidateID([FromRoute] int candidateid)
        {
            try
            {
                var interviews = await _interviewDao.GetInterviewsbyCandidateId(candidateid);
                if (interviews.Count() == 0)
                {
                    return StatusCode(404);
                }
                return Ok(interviews);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// Get Interview by PositionId
        /// </summary>
        /// <param name="positionid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("interviews/positions/{positionid}")]
        public async Task<IActionResult> GetInterviewsbyPositionId([FromRoute] int positionid)
        {
            try
            {
                var interviews = await _interviewDao.GetInterviewsbyPositionId(positionid);
                if (interviews.Count() == 0)
                {
                    return StatusCode(404);
                }
                return Ok(interviews);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// Get Interview by LocationId
        /// </summary>
        /// <param name="locationid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("interviews/locations/{locationid}")]
        public async Task<IActionResult> GetInterviewsbyLocationId([FromRoute] int locationid)
        {
            try
            {
                var interviews = await _interviewDao.GetInterviewsbyLocationId(locationid);
                if (interviews.Count() == 0)
                {
                    return StatusCode(404);
                }
                return Ok(interviews);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// Get Interview by Date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("interviews/date")]
        public async Task<IActionResult> GetInterviewsbyDate([FromQuery] DateTime date)
        {
            try
            {
                var interview = await _interviewDao.GetInterviewsbyDate(date);
                if (interview.Count() == 0)
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

    }
}

