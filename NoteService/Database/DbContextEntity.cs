using Microsoft.EntityFrameworkCore;
using NoteService.Models;

namespace NoteService.Database
{
    public class DbContextEntity : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public DbContextEntity(DbContextOptions<DbContextEntity> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Note>();
        } 
    }
}