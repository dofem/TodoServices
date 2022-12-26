namespace TodoServices.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Active { get; set; } = 1;
        public List<Tasks> Tasks { get; set; }

    }
}
