using Microsoft.EntityFrameworkCore;

namespace TODOList.Database.Model
{
    public class TasksDatabaseContext : DbContext
    {
        private const string ConnectionString = "Server=DESKTOP-8HR6Q76\\OPTIMA;Database=TODOList;Trusted_Connection=True;";
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
