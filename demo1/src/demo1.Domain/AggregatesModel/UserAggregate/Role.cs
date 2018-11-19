using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace demo1.Domain.AggregatesModel.UserAggregate
{
    public class Role : IdentityRole<string>
    {
        public string Description { get; set; }
        public IList<UserRole> Users { get; set; } = new List<UserRole>();
    }
}
