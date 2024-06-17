using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace Homework2.Models
{
    public class AppUser : IdentityUser
    {

        [DefaultValue("temp")]
        public string? temp { get; set; }
        public ICollection<Classroom>? Classrooms { get; set; }

        public ICollection<ClassroomUsers>? ClassroomUsers { get; set; }
    }
}

