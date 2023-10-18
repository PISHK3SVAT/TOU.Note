using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TOU.Note.DbContexts.Configs.Notes
{
    public class NoteConfig : IEntityTypeConfiguration<Entities.Notes.Note>
    {
        void IEntityTypeConfiguration<Entities.Notes.Note>.Configure(EntityTypeBuilder<Entities.Notes.Note> builder)
        {
            builder.Property(n => n.Title)
                .HasMaxLength(50);
        }
    }
}
