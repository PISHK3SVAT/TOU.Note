using TOU.Note.Models.Notes;
using TOU.Note.Services;

namespace TOU.Note.Helper
{
    public static class NoteMapper
    {
        public static NoteDto ToNoteDto (Entities.Notes.Note note)
        {
            return new NoteDto(note.Title, note.Body);
        }
    }
}
