using Homework2.Data;
using Homework2.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Repositories
{
    public interface IClassroomUserRepository
    {
        ClassroomUsers Add(ClassroomUsers classroomUser);
        ClassroomUsers GetClassroomUser(int classId, string userId);
        IEnumerable<ClassroomUsers> GetClassroomMentors(int id);
        IEnumerable<ClassroomUsers> GetClassroomStudents(int id);
        IEnumerable<ClassroomUsers> GetUserClassrooms(string userId);
        ClassroomUsers Delete(int classId, string userId);
    }

    public class SQLClassroomUserRepository : IClassroomUserRepository
    {
        private readonly ApplicationDbContext context;
        public SQLClassroomUserRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        ClassroomUsers IClassroomUserRepository.Add(ClassroomUsers classroomUser)
        {
            context.ClassroomUsers.Add(classroomUser);
            context.SaveChanges();
            return classroomUser;
        }
        ClassroomUsers IClassroomUserRepository.GetClassroomUser(int classId, string userId)
        {
            return context.ClassroomUsers.Find(classId, userId);
        }
        IEnumerable<ClassroomUsers> IClassroomUserRepository.GetClassroomMentors(int id)
        {
            return context.ClassroomUsers.Where(cu => cu.Role == "Mentor" && cu.ClassroomId == id).Include(au => au.AppUser);
        }
        IEnumerable<ClassroomUsers> IClassroomUserRepository.GetClassroomStudents(int id)
        {
            return context.ClassroomUsers.Where(cu => cu.Role == "Student" && cu.ClassroomId == id).Include(au => au.AppUser);
        }
        IEnumerable<ClassroomUsers> IClassroomUserRepository.GetUserClassrooms(string userId)
        {
            return context.ClassroomUsers.Where(cu => cu.AppUserId == userId).Include(cu => cu.Classroom).Include(cu => cu.AppUser);
        }
        ClassroomUsers IClassroomUserRepository.Delete(int classId, string userId)
        {
            ClassroomUsers ClassroomUser = context.ClassroomUsers.Find(classId, userId);
            if (ClassroomUser != null)
            {
                context.ClassroomUsers.Remove(ClassroomUser);
                context.SaveChanges();
            }
            return ClassroomUser;
        }
    }
}
