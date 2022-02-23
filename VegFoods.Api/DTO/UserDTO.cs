using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegFoods.Api.DTO
{
    public class UserDTO
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
