namespace QuertyKey_DAW.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public User UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public virtual ICollection<Keyboard>? Keyboards { get; set; }

        public virtual ICollection<Keycap>? Keycaps { get; set; }
        public virtual ICollection<Switch>? Switches { get; set; }
        public virtual ICollection<Deskmat>? Deskmats { get; set; }
        public virtual ICollection<Merch>? Merch { get; set; }
        public virtual ICollection<Accessory>? Accessories { get; set; }
        public virtual ICollection<Specialty>? Specialties { get; set; }

    }
}
