namespace Homework2.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int? BlackBoardId { get; set; }
        public BlackBoard? BlackBoard { get; set; }
        public string? Content { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
