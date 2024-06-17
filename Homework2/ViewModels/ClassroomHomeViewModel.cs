using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework2.Models;
namespace Homework2.ViewModels
{
    public class ClassroomHomeViewModel
    {
        public int ClassId { get; set; }
        public Classroom Classroom { get; set; }
        public string ClassroomUserRole { get; set; }
        public IEnumerable<BlackBoard> BlackBoards { get; set; }
        public IEnumerable<ClassroomUsers> ClassroomMentors { get; set; }
        public IEnumerable<ClassroomUsers> ClassroomStudents { get; set; }
        public IEnumerable<Invite> StudentInvites { get; set; } 
        public IEnumerable<Assignment> Assignments { get; set; }
        public BlackBoardViewModel BlackBoardViewModel { get; set; }
        public AssignmentViewModel AssignmentViewModel { get; set; }
        public Comment Comment { get; set; }
        public List<List<Comment>> Comments { get; set; }
    }
}
