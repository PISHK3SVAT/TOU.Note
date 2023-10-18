using Microsoft.EntityFrameworkCore;

using TOU.Note.DbContexts.Configs.Notes;

namespace TOU.Note.DbContexts
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Entities.Notes.Note> Notes { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Entities.Notes.Note>(new NoteConfig());
            
        }
    }
}
