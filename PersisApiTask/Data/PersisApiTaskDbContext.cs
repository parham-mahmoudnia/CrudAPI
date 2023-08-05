using Microsoft.EntityFrameworkCore;
using PersisApiTask.Models;

namespace PersisApiTask.Data
{
    public class PersisApiTaskDbContext : DbContext
    {
        public PersisApiTaskDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ActivityType> ActivityTypes { get; set; }  
    }
}
