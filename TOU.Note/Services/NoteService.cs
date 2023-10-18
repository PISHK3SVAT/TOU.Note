using Microsoft.EntityFrameworkCore;

using TOU.Note.DbContexts;
using TOU.Note.Helper;

namespace TOU.Note.Services
{
    public class NoteService
    {
        private readonly DatabaseContext _db;

        public NoteService(DatabaseContext db)
        {
            _db = db;
        }

        public List<NoteDto> GetAll(int page=1,int size=10)
        {
            var notes=_db.Notes
                .ToPage(page,size)
                .Select(n => NoteMapper.ToNoteDto(n))
                .ToList();
            return notes;
        }

        public async Task<NoteServiceResult<NoteDto>> GetAsync(Guid id)
        {
            var note =await _db.Notes.FirstOrDefaultAsync(n => n.Id==id);
            if (note is null)
                return new NoteServiceResult<NoteDto>
                {
                    IsSuccess = false,
                    StatusCode = ServiceResultStatusCode.NotFound,
                };

            return new NoteServiceResult<NoteDto>
            {
                IsSuccess = true,
                StatusCode = ServiceResultStatusCode.Ok,
                Data = NoteMapper.ToNoteDto(note)
            };
        }

        public async Task<NoteServiceResult> Create(CreateNoteDto dto)
        {
            //validation
            var newNote = NoteMapper.CreateNoteDtoToNote(dto);
            try
            {
                await _db.Notes.AddAsync(newNote);
                var saveRes =await _db.SaveChangesAsync();
                if (saveRes==0)
                {
                    return new NoteServiceResult
                    {
                        IsSuccess = false,
                        StatusCode = ServiceResultStatusCode.NotSavedError,
                    };
                }
                return new NoteServiceResult
                {
                    IsSuccess = true,
                    StatusCode = ServiceResultStatusCode.Ok,
                };

            }
            catch (Exception)
            {
                return new NoteServiceResult
                {
                    IsSuccess = false,
                    StatusCode = ServiceResultStatusCode.UnknownExceptionError,
                };
            }
        }
    }

    public class NoteDto
    {

        public required string Title { get; set; }
        public required string Body { get; set; }
    }

    public class CreateNoteDto
    {
        public required string Title { get; set; }
        public required string Body { get; set; }
    }

    public class NoteServiceResult
    {
        public bool IsSuccess { get; set; }
        public ServiceResultStatusCode StatusCode { get; set; }
    }

    public class NoteServiceResult<T>: NoteServiceResult
    {
        public T? Data { get; set; }
    }

    public enum ServiceResultStatusCode
    {
        Ok=0,
        NotFound=-1,
        NotSavedError=-60,
        UnknownExceptionError=-100,
    }
}
