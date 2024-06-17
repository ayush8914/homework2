using Homework2.Data;
using Homework2.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Repositories
{
    public interface IClassroomRepository
    {
        Classroom GetClassroom(int ID);
        IEnumerable<Classroom> GetAllClassrooms();
        Classroom Add(Classroom classroom);
        Classroom Update(Classroom classroomChanges);
        Classroom Delete(int ID);
    }

    public class SQLClassroomRepository : IClassroomRepository
    {
        private readonly ApplicationDbContext context;
        public SQLClassroomRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        Classroom IClassroomRepository.Add(Classroom classroom)
        {
            try
            {
            context.Classrooms.Add(classroom);
            context.SaveChanges();
            return classroom;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        Classroom IClassroomRepository.Delete(int Id)
        {
            Classroom Classroom = context.Classrooms.Find(Id);
            if (Classroom != null)
            {
                context.Classrooms.Remove(Classroom);
                context.SaveChanges();
            }
            return Classroom;
        }
        IEnumerable<Classroom> IClassroomRepository.GetAllClassrooms()
        {    
            return context.Classrooms.Include(s => s.AppUser);
        }
        Classroom IClassroomRepository.GetClassroom(int Id)
        {   
            Classroom cr= context.Classrooms.Find(Id);
            if(cr != null)
            {
                return cr;
            }
            return null;
        }
        Classroom IClassroomRepository.Update(Classroom classroomChanges)
        {
            try
            {
            var Classroom = context.Classrooms.Attach(classroomChanges);
            Classroom.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return classroomChanges;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
