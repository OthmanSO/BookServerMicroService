using System.Reflection;
using Microsoft.EntityFrameworkCore;
using BooksServer.API.Entities;

namespace BooksServer.API.DbContexts
{
    public partial class BooksDbcontexst : DbContext 
    {
        private const string ConnectionString = "Filename=Books.db";
        private virtual DbSet<Books> books { get; set; }
        protected void OnConfiuring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString, options => 
            {
                options.MigrationsAssembly( Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiuring(optionsBuilder);
        }
    }
}