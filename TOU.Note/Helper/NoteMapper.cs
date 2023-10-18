using TOU.Note.Models.Notes;
using TOU.Note.Services;

namespace TOU.Note.Helper
{
    public static class NoteMapper
    {
        public static NoteDto ToNoteDto(Entities.Notes.Note note)
        {
            return new NoteDto{Title=note.Title,Body= note.Body};
        }
        public static NoteViewModel NoteDtoToNoteVM(NoteDto dto)
        {
            return new NoteViewModel { Body = dto.Body, Title = dto.Title };
        }
        #region Create
        public static CreateNoteDto CreateNoteVMToDto(CreateNoteViewModel vm)
        {
            return new CreateNoteDto { Title = vm.Title, Body = vm.Body };
        }

        public static Entities.Notes.Note CreateNoteDtoToNote(CreateNoteDto dto)
        {
            return new Entities.Notes.Note
            {
                Body = dto.Body,
                Title = dto.Title
            };
        }

        #endregion
    }
}
