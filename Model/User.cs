namespace TodoServices.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }
        public List<Task> Tasks { get; set; }

    }
}
