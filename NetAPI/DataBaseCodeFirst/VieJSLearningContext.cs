using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using VieJSLearning.Dal.Entities;

namespace VieJSLearning.Dal
{
    public class VieJSLearningContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var dbPath = Path.Combine(basePath, "DB");
            if (!Directory.Exists(dbPath))
            {
                Directory.CreateDirectory(dbPath);
            }
            var sourcePart = Path.Combine(dbPath, "Sample.db");
            optionbuilder.UseSqlite($@"Data Source={sourcePart}");
        }
    }
}
