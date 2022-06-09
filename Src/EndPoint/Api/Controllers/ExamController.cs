using ApplicationService.Services.UserExam;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        protected readonly IUserExamService _service;

        public ExamController(IUserExamService service)
        {
            _service = service;
        }

        public IActionResult Post( )
        {
            return Ok();
        }
    }
}
