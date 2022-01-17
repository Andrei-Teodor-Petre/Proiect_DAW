using System;
using System.Collections.Generic;

namespace QuertyKey_DAW.DataModels
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateOnly CreatedOn { get; set; }
        public int Age { get; set; }
        public int Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
