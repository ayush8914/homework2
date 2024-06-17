namespace Homework2.Models
{
    public class BlackBoard
    {
        public int Id { get; set; }
        public int? ClassroomId { get; set; }
        public string? AppUserId { get; set; }
        public ClassroomUsers? ClassroomUser { get; set; }
        public string? content { get; set; }
        public string? FilesPaths { get; set; }
    }
}
