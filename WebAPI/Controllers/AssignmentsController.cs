using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public IActionResult GetAll()
        {
            var result = _assignmentService.GetAll(UserId());
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(AddUpdateRequestDto addUpdateRequestDto)
        {
            var assignment = new Assignment
            {
                AssignmentId = addUpdateRequestDto.AssignmentId,
                AssignmentName = addUpdateRequestDto.AssignmentName,
                AssignmentStatus = addUpdateRequestDto.AssignmentStatus,
                UserId = UserId(),
                UserComment = addUpdateRequestDto.UserComment
            };
            var result = _assignmentService.Add(assignment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(AddUpdateRequestDto addUpdateRequestDto)
        {
            var assignment = new Assignment
            {
                AssignmentId = addUpdateRequestDto.AssignmentId,
                AssignmentName = addUpdateRequestDto.AssignmentName,
                AssignmentStatus = addUpdateRequestDto.AssignmentStatus,
                UserId = UserId(),
                UserComment = addUpdateRequestDto.UserComment
            };

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

        private int UserId()
        {
            string userIdStr = User.FindFirst(ClaimTypes.Name)?.Value;
            int userId = 0;
           Int32.TryParse(userIdStr, out userId);
            return userId;
        }
    }
}
