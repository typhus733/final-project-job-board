using JobBoard.DAO;
using JobBoard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Controllers
{
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly CandidateDao _candidateDao;

        public CandidateController(CandidateDao candidateDao)
        {
            _candidateDao = candidateDao;
        }

        /// <summary>
        /// Filter Candidates
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("candidates/search")]
        public async Task<IActionResult> GetCandidates([FromQuery] CandidateRequest candidateParams)
        {
            try
            {
                var candidates = await _candidateDao.GetCandidates(candidateParams);
                if (candidates.Count() == 0)
                {
                    return StatusCode(404);
                }
                return Ok(candidates);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Get Candidates by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("candidates/{id}")]
        public async Task<IActionResult> GetCandidateById([FromRoute] int id)
        {
            try
            {
                var candidate = await _candidateDao.GetCandidateById(id);
                if (candidate == null)
                {
                    return StatusCode(404);
                }
                return Ok(candidate);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Post new Candidate
        /// </summary>
        /// <param name="insertRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("candidates")]
        public async Task<IActionResult> CreateCandidate([FromBody] CandidateRequest insertRequest)
        {
            try
            {
                await _candidateDao.CreateCandidate(insertRequest);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// Update Candidate By ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateRequest"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("candidates/{id}")]
        public async Task<IActionResult> UpdateCandidateById([FromRoute] int id, [FromBody] CandidateRequest updateRequest)
        {
            try
            {
                var candidate = await _candidateDao.GetCandidateById(id);
                if (candidate == null)
                {
                    return StatusCode(404);
                }

                await _candidateDao.UpdateCandidateById(updateRequest, id, candidate);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        /// <summary>
        /// Delete Candidate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("candidates/{id}")]
        public async Task<IActionResult> DeleteCandidateById([FromRoute] int id)
        {
            try
            {
                var candidate = await _candidateDao.GetCandidateById(id);
                if (candidate == null)
                {
                    return StatusCode(404);
                }

                await _candidateDao.DeleteCandidateById(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Get Candidates by PositionId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("candidates/positions/{id}")]
        public async Task<IActionResult> GetPositionsByCandidateId([FromRoute] int id)
        {
            try
            {
                var positions = await _candidateDao.GetPositionsByCandidateId(id);
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
