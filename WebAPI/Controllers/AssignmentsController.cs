using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class AssignmentsController : ControllerBase
    {
        IAssignmentService _assignmentService;

        public AssignmentsController()
        {
            _assignmentService = new AssignmentManager();
        }

        [HttpGet("getall")]
        public IActionResult GetAll(int userId)
        {
            var result = _assignmentService.GetAll(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Assignment assignment)
        {
            var result = _assignmentService.Add(assignment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(Assignment assignment)
        {
            var result = _assignmentService.Update(assignment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Assignment assignment)
        {
            var result = _assignmentService.Delete(assignment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
