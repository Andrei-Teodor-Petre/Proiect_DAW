namespace QuertyKey_DAW.FrontendModels
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
        public string Size { get; set; }
        public Switch Switch { get; set; }
        public Keycap Keycap { get; set; }


    }
}
