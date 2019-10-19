using System.Collections.Generic;
using Bikeshop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Domain
{
    public class Customer : IdentityUser
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public List<ShoppingBag> Bags { get; set; }
    }
}
