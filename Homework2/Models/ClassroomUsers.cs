using Homework2.CustomAttributes;

namespace Homework2.Models
{
    public class ClassroomUsers
    {
        public int ClassroomId { get; set; }
        public Classroom? Classroom { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        [StringValueIn(new string[] { "Mentor", "Student" })]
        public string? Role { get; set; }

        public ICollection<BlackBoard> BlackBoards { get; set; }
    }
}
