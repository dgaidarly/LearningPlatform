using Microsoft.EntityFrameworkCore;
using VieJSLearning.Dal.Entities;

namespace VieJSLearning.Dal
{
    internal class VieJSLearningContext : DbContext
    {
        public virtual DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=d:\Sample.db");
        }
    }
}
