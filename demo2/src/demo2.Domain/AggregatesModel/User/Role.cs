using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace demo2.Domain.AggregatesModel
{
    public class Role : IdentityRole<string>
    {
        public string Description { get; set; }
        public IList<UserRole> Users { get; set; } = new List<UserRole>();
    }
}
