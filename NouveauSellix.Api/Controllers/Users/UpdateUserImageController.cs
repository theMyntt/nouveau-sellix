using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NouveauSellix.Application.Users.Services.UpdateUserImage;
using NouveauSellix.Application.Users.Services.UpdateUserImage.IO;

namespace NouveauSellix.Api.Controllers.Users
{
    [Authorize]
    [ApiController]
    [Route("/api")]
    [Tags("Image", "User")]
    public class UpdateUserImageController : ControllerBase
    {
        [HttpPut("v1/user/image/")]
        [EndpointSummary("Update user image")]
        public async Task<IActionResult> PerformV1(
            [FromForm] UpdateUserImageServiceInput input,
            [FromServices] IUpdateUserImageService service)
        {
            await service.ExecuteAsync(input);

            return NoContent();
        }
    }
}
