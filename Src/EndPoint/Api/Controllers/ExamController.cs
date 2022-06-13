using ApplicationService.Models.UserExam;
using ApplicationService.Services.UserExam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IUserExamService _service;
        public ExamController(IUserExamService service)
        {
            _service = service;
        }


        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] AddUserExamDto addModel)
        {
            var result = _service.MakeExam(addModel, getCurrentUserMobile());
            return StatusCode(201, result.Id);
        }


        [HttpGet]
        [Authorize]
        public IActionResult GetAll([FromQuery] int pageNumber = 1, int pageSize = 5)
        {
            var result = _service.GetExam(pageNumber, pageSize, getCurrentUserMobile());
            return Ok(result);
        }


        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] EditUserExamDto editModel)
        {
            var result = _service.Edit(editModel, getCurrentUserMobile());
            return Ok(result.Id);
        }


        [HttpDelete]
        [Authorize]
        public IActionResult Delete([FromQuery] int id)
        {
            var result = _service.Delete(id, getCurrentUserMobile());
            return Ok(result);
        }

        private string? getCurrentUserMobile()
        {
            if (HttpContext.User.Claims.Any())
                return HttpContext.User.Claims.First().Value;
            return null;
        }
    }
}
