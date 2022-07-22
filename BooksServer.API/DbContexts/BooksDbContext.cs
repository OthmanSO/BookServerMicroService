using System.Reflection;
using Microsoft.EntityFrameworkCore;
using BooksServer.API.Entities;

namespace BooksServer.API.DbContexts
{
    public partial class BooksDbcontexst : DbContext
    {
        private const string ConnectionString = "Filename=Books.db";
        public virtual DbSet<Books>? books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString, options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(e =>
            {
                e.HasIndex(en => en.bookId);
            });
        } 
    }
}