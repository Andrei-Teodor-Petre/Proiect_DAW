namespace QuertyKey_DAW.FrontendModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Age { get; set; }
        public int Role { get; set; }
    }
}
