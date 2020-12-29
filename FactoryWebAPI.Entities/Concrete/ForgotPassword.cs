using FactoryWebAPI.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryWebAPI.Entities.Concrete
{
    public class ForgotPassword : ITable
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool isActive { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
