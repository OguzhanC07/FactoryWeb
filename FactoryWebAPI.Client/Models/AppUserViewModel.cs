using System.Collections.Generic;

namespace FactoryWebAPI.Client.Models
{
    public class AppUserViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}