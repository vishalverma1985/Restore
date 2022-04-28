using System;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        [HttpGet("not-found")]
        public ActionResult GetNotFound()
        {
            return NotFound();
        }
        
        [HttpGet("bad-request")]
        public ActionResult GetBadRequestFound()
        {
            return BadRequest(new ProblemDetails{Title = "This is a bad request"});
        }
        
        [HttpGet("unauthorized")]
        public ActionResult GetUnauthorized()
        {
            return Unauthorized();
        }
        
        [HttpGet("validation-error")]
        public ActionResult GetValidationError()
        {
            ModelState.AddModelError("Problem1","This is first error");
            ModelState.AddModelError("Problem2","This is second error");
            
            return ValidationProblem();
        }
        
        [HttpGet("server-error")]
        public ActionResult GeServerError()
        {
            throw new Exception("This is a server error");
        }
    }
}