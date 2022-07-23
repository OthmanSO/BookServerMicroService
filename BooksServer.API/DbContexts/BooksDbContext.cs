using System.Reflection;
using Microsoft.EntityFrameworkCore;
using BooksServer.API.Entities;

namespace BooksServer.API.DbContexts
{
    public partial class BooksDbContexst : DbContext
    {
        public virtual DbSet<Books>? Books { get; set; }
        public BooksDbContexst(DbContextOptions<BooksDbContexst> options):base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        } 
    }
}