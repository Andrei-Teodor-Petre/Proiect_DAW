using System;
using System.Collections.Generic;

namespace QuertyKey_DAW.DataModels
{
    public partial class Keyboard
    {
        public Keyboard()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime AddedOn { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsHotswap { get; set; }
        public string Size { get; set; } = null!;
        public Guid SwitchId { get; set; }
        public Guid KeycapId { get; set; }

        public virtual Keycap Keycap { get; set; } = null!;
        public virtual Switch Switch { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
