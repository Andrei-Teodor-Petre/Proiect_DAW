namespace QuertyKey_DAW.Models
{
    public class Keyboard
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AddedOn { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsHotswap { get; set; }
        public string Size  { get; set; }
        
        
        public Guid SwitchId { get; set; }
        public Guid KeycapId { get; set; }


        public virtual Switch Switch { get; set; } = null!;
        public virtual Keycap Keycap { get; set; } = null!;

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
