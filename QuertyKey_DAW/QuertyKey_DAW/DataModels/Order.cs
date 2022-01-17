using System;
using System.Collections.Generic;

namespace QuertyKey_DAW.DataModels
{
    public partial class Order
    {
        public Order()
        {
            Deskmats = new HashSet<Deskmat>();
            Keyboards = new HashSet<Keyboard>();
            Keycaps = new HashSet<Keycap>();
            Merches = new HashSet<Merch>();
            Specialties = new HashSet<Specialty>();
            Switches = new HashSet<Switch>();
        }

        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Deskmat> Deskmats { get; set; }
        public virtual ICollection<Keyboard> Keyboards { get; set; }
        public virtual ICollection<Keycap> Keycaps { get; set; }
        public virtual ICollection<Merch> Merches { get; set; }
        public virtual ICollection<Specialty> Specialties { get; set; }
        public virtual ICollection<Switch> Switches { get; set; }
    }
}
