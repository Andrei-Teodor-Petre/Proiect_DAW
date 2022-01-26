namespace QuertyKey_DAW.FrontendModels
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Keyboard> Keyboards { get; set; }
        public List<Deskmat> Deskmats { get; set; }
        public List<Switch> Switches { get; set; }
        public List<Keycap> Keycaps { get; set; }
        public List<Merch> Merches { get; set; }
        public List<Accessory> Accessories { get; set; }
        public List<Specialty> Specialties { get; set; }
        public decimal Price { get; set; }
    }
}
