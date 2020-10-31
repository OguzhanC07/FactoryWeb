using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.DTO.DTOs.AppUserDtos
{
    public class AppUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
