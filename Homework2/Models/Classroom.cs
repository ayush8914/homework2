using System.ComponentModel.DataAnnotations;

namespace Homework2.Models
{
    public class Classroom
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string title { get; set; }
        public string description { get; set; }
        public DateTime time_created { get; set; }
        public string? AppUserID { get; set; }
        public AppUser? AppUser { get; set; }

        
        public ICollection<ClassroomUsers>? ClassroomUsers { get; set; }
    }
}
