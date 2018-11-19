using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace demo2.Domain.AggregatesModel
{
    public class User : IdentityUser<string>
    {
        public string Name { get; set; }
        public IList<UserRole> Roles { get; set; } = new List<UserRole>();
    }
}
