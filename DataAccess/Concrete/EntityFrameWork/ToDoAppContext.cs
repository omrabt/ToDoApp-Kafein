using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class ToDoAppContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ToDoApp;Trusted_Connection=true");
        }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
