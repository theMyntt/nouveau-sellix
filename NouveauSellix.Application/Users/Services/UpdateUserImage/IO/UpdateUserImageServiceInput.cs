using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NouveauSellix.Application.Users.Services.UpdateUserImage.IO
{
    public class UpdateUserImageServiceInput
    {
        [Required]
        public required IFormFile Image { get; set; }

        [Required]
        public required string Email { get; set; }
    }
}
