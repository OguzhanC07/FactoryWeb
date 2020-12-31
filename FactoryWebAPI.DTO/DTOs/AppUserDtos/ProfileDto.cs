using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DTO.DTOs.AppUserDtos
{
    public class ProfileDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string ImagePath { get; set; }
    }
}
