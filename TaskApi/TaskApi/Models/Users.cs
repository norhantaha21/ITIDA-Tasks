namespace TaskApi.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Navigation property
        public ICollection<Tasks> Task { get; set; }=new List<Tasks>();

    }
}
