namespace Homework2.Models
{
    public class Invite
    {
        public int Id { get; set; }
        public int? ClassroomId { get; set; }
        public Classroom? Classroom { get; set; }
        public string? Email { get; set; }
    }
}
