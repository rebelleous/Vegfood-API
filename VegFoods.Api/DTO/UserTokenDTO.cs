using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegFoods.Api.DTO
{
    public class UserTokenDTO : UserDTO
    {
        public string Token { get; set; }
    }
}
