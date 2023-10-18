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
    }

    public class NoteDto
    {
        public NoteDto(string title, string body)
        {
            Title = title;
            Body = body;
        }

        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class NoteServiceResult<T>
    {
        public bool IsSuccess { get; set; }
        public ServiceResultStatusCode StatusCode { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public T Data { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }

    public enum ServiceResultStatusCode
    {
        Ok=0,
        NotFound=-1,
    }
}
