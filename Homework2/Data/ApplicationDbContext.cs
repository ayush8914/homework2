using Homework2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homework2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ClassroomUsers>().HasKey(cu => new { cu.ClassroomId, cu.AppUserId });
            builder.Entity<ClassroomUsers>()
                .HasOne<Classroom>(cu => cu.Classroom)
                .WithMany(cu => cu.ClassroomUsers)
                .HasForeignKey(cu => cu.ClassroomId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ClassroomUsers>()
                .HasOne<AppUser>(au => au.AppUser)
                .WithMany(cu => cu.ClassroomUsers)
                .HasForeignKey(cu => cu.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
          builder.Entity<BlackBoard>()
    .HasOne<ClassroomUsers>(cu => cu.ClassroomUser)
    .WithMany(bb => bb.BlackBoards)
    .HasForeignKey(bb => new { bb.ClassroomId, bb.AppUserId })
    .OnDelete(DeleteBehavior.Cascade);


        }

       public DbSet<Classroom> Classrooms { get; set; }

        public DbSet<ClassroomUsers> ClassroomUsers { get; set; }

        public DbSet<BlackBoard> BlackBoards { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Invite> Invites { get; set; }

        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<SubmittedAssignment> SubmittedAssignments { get; set; }
    }
}