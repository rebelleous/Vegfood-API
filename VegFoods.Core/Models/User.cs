﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VegFoods.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public List<UserRole> UserRoles { get; set; }
        public List<Recipe> Recipes { get; set; }

    }
}
