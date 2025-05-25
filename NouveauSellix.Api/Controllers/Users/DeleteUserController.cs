using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NouveauSellix.Application.Users.Services.DeleteUser;
using NouveauSellix.Application.Users.Services.DeleteUser.IO;

namespace NouveauSellix.Api.Controllers.Users
{
    [Authorize]
    [ApiController]
    [Route("/api")]
    [Tags("Delete User", "User")]
    public class DeleteUserController : ControllerBase
    {
        [HttpDelete("v1/user")]
        public async Task<IActionResult> PerformV1(
            [FromHeader(Name = "Authorization")] string token,
            [FromServices] IDeleteUserService service)
        {
            var input = new DeleteUserServiceInput
            {
                Token = token
            };
            
            await service.ExecuteAsync(input);

            return NoContent();
        }
    }
}
