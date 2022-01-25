namespace QuertyKey_DAW.FrontendModels
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Keyboard> keyboards { get; set; }
        public List<Deskmat> deskmats { get; set; }
        public List<Switch> switches { get; set; }
        public List<Keycap> keycaps { get; set; }
        public List<Merch> merch { get; set; }
        public List<Accessory> accessories { get; set; }
        public List<Specialty> specialties { get; set; }
        public decimal Price { get; set; }
    }
}
