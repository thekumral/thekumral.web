using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thekumral.Core.DTOs;

namespace thekumral.Api.Controllers.Bases
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)

                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                };
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
