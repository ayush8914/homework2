using Homework2.Models;

namespace Homework2.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Invite> Invites { get; set; }
        public IEnumerable<ClassroomUsers> UserClassrooms { get; set; }
    }
}
