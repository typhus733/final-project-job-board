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
    public class InterviewController : ControllerBase
    {
        //    private readonly InterviewDao _interviewDao;

        //    public InterviewController(InterviewDao interviewDao)
        //    {
        //        _interviewDao = interviewDao;
        //    }

        //    [HttpGet]
        //    [Route("")]
        //    [ProducesResponseType(StatusCodes.Status200OK)]


        //    [HttpPost]
        //    [ProducesResponseType(StatusCodes.Status201Created)]
        //    [ProducesResponseType(StatusCodes.Status400BadRequest)]


        //    [HttpPatch]
        //    [Route("{interviewID}")]
        //    [ProducesResponseType(StatusCodes.Status201Created)]
        //    [ProducesResponseType(StatusCodes.Status400BadRequest)]


        //    [HttpDelete]
        //    [Route("{interviewID}")]
        //    [ProducesResponseType(StatusCodes.Status201Created)]
        //    [ProducesResponseType(StatusCodes.Status400BadRequest)]

        //}
    }
}

