using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using NouveauSellix.Application.Users.Services.CreateUser;
using NouveauSellix.Application.Users.Services.CreateUser.IO;

namespace NouveauSellix.Api.Controllers.Users
{
    [ApiController]
    [Route("/api")]
    [Tags("Create User", "User")]
    public class CreateUserController : ControllerBase
    {
        [HttpPost("v1/user")]
        [EndpointSummary("Create a new user")]
        public async Task<IActionResult> PerformV1(
            [FromBody] CreateUserServiceInput input,
            [FromServices] ICreateUserService service)
        {
            var result = await service.ExecuteAsync(input);

            return StatusCode(result.StatusCode, result);
        }
    }
}
