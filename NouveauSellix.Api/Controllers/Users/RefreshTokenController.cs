using Microsoft.AspNetCore.Mvc;
using NouveauSellix.Application.Users.Services.RefreshToken;
using NouveauSellix.Application.Users.Services.RefreshToken.IO;

namespace NouveauSellix.Api.Controllers.Users
{
    [ApiController]
    [Route("/api")]
    [Tags("Auth", "User")]
    public class RefreshTokenController : ControllerBase
    {
        [HttpPost("v1/auth/refresh")]
        [EndpointSummary("Refresh your old jwt token")]
        public async Task<IActionResult> PerformV1(
            [FromBody] RefreshTokenServiceInput input,
            [FromServices] IRefreshTokenService service)
        {
            var result = await service.ExecuteAsync(input);

            return StatusCode(result.StatusCode, result);
        }
    }
}
