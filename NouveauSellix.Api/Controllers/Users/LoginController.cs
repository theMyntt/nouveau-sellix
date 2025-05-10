using Microsoft.AspNetCore.Mvc;
using NouveauSellix.Application.Users.Services.Login;
using NouveauSellix.Application.Users.Services.Login.IO;

namespace NouveauSellix.Api.Controllers.Users
{
    [ApiController]
    [Route("/api")]
    [Tags("User Auth", "User")]
    public class LoginController : ControllerBase
    {
        [HttpPost("v1/auth")]
        [EndpointSummary("Generate JWT Token for Auth")]
        public async Task<IActionResult> PerformV1(
            [FromBody] LoginServiceInput input,
            [FromServices] ILoginService service)
        {
            var result = await service.ExecuteAsync(input);

            return StatusCode(result.StatusCode, result);
        }
    }
}
