using golden_snitch.DTOs;
using golden_snitch.DTOs.Scheduler;
using golden_snitch.DTOs.Tenants;
using golden_snitch.Services.Scheduler;
using golden_snitch.Services.Tenants;
using Microsoft.AspNetCore.Mvc;

namespace golden_snitch.Controllers.Scheduler
{
    [ApiController]
    [Route("golden-snitch/tenant/{tenantid}/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public ActionResult<List<ResponseProject>> GetAll()
        {
            var apiResponse = _projectService.GetAll();

            if (apiResponse.IsSuccessful == false)
            {
                ModelState.AddModelError(apiResponse.ErrorDetails.ErrorCode, apiResponse.ErrorDetails.ErrorMessage);
                return StatusCode(500, ModelState);
            }

            return Ok(apiResponse);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RequestProject? request)
        {
            if (request is null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var apiResponse = _projectService.Create(request);

            return apiResponse.IsSuccessful == false
                ? ApiResponseErrorResult.Error<ResponseProject>(apiResponse, ModelState)
                : Ok(apiResponse);
        }
    }
}
