using golden_snitch.DTOs.Tenants;
using golden_snitch.Services.Tenants;
using Microsoft.AspNetCore.Mvc;

namespace golden_snitch.Controllers.Tenants
{
    [ApiController]
    [Route("golden-snitch/tenant/{tenantid}/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<ResponseUser>> GetAll()
        {
            var apiResponse = _userService.GetAll();

            if (apiResponse.IsSuccessful == false)
            {
                ModelState.AddModelError(apiResponse.ErrorDetails.ErrorCode, apiResponse.ErrorDetails.ErrorMessage);
                return StatusCode(500, ModelState);
            }

            return Ok(apiResponse);
        }
    }
}
