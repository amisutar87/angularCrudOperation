using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCrud.Model
{
    public class StudentContext:DbContext
    {
        public IConfiguration Configuration { get; }
      
        public StudentContext(DbContextOptions<StudentContext> options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(
            entity =>
            {
                entity.ToTable("AS_Student");            
            });
        }
    }
}