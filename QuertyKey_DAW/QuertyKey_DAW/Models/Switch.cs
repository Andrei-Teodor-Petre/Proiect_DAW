namespace QuertyKey_DAW.Models
{
    public class Switch
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AddedOn { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Keyboard> Keyboards { get; set; } = null!;

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
