using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NouveauSellix.Application.Users.Services.RefreshToken.IO
{
    public class RefreshTokenServiceInput
    {
        [Required]
        public required string OldToken { get; set; }
    }
}
