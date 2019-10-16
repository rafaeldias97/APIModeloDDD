using APIModeloDDD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace APIModeloDDD.Infra.Data.Context
{
    public class Context : DbContext
    {
        public DbSet<Person> Person { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(q =>
            {
                q.HasKey(x => x.id);
            });
        }
    }
}
