using ApplicationService.Services.UserExam;
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
    }
}
