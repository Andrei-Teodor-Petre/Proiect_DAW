namespace QuertyKey_DAW.Models
{
    public class Specialty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AddedOn { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
