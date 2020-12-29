using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DTO.DTOs.ForgotPasswordDtos
{
    public class ForgotPasswordDto
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }
}
