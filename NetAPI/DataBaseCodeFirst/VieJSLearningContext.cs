using Microsoft.EntityFrameworkCore;
using VieJSLearning.Dal.Entities;

namespace VieJSLearning.Dal
{
    public class VieJSLearningContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=d:\Sample.db");
        }
    }
}
