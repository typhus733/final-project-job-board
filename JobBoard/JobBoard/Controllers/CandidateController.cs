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

        [HttpGet]
        [Route("candidates")]
        public async Task<IActionResult> GetCandidates()
        {
            try
            {
                var candidates = await _candidateDao.GetCandidates();
                return Ok(candidates);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

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


        [HttpPost]
        [Route("candidates")]
        public async Task<IActionResult> CreateCandidate([FromBody] Candidate insertRequest)
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

        [HttpPut]
        [Route("candidates")]
        public async Task<IActionResult> UpdateCandidateById([FromBody] Candidate updateRequest)
        {
            try
            {
                var candidate = await _candidateDao.GetCandidateById(updateRequest.Id);
                if (candidate == null)
                {
                    return StatusCode(404);
                }

                await _candidateDao.UpdateCandidateById(updateRequest);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

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

        [HttpGet]
        [Route("candidates/positions/{id}")]
        public async Task<IActionResult> GetPositionsByCandidateId([FromRoute] int id)
        {
            try
            {
                var candidate = await _candidateDao.GetPositionsByCandidateId(id);
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

    }
}
