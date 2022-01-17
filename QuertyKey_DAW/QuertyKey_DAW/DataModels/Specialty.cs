﻿using System;
using System.Collections.Generic;

namespace QuertyKey_DAW.DataModels
{
    public partial class Specialty
    {
        public Specialty()
        {
            Orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateOnly AddedOn { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
