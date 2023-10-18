using System.Security.Principal;

using Microsoft.AspNetCore.Mvc;

using TOU.Note.Helper;
using TOU.Note.Models.Notes;
using TOU.Note.Services;

namespace TOU.Note.Controllers
{
    public class NoteController : Controller
    {
        private NoteService _noteService;

        public NoteController(NoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _noteService.GetAll();
            var vm = result
                .Select(n => NoteMapper.NoteDtoToNoteVM(n));
            return View(vm);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result =await _noteService.GetAsync(id);
            if (result.StatusCode == ServiceResultStatusCode.NotFound)
            {
                return NotFound();
            }
            var vm = NoteMapper.NoteDtoToNoteVM(result.Data!);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //validate token
        public async Task<IActionResult> Create(CreateNoteViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = NoteMapper.CreateNoteVMToDto(vm);
                var result =await _noteService.Create(dto);
                if (result.IsSuccess)
                    return RedirectToAction(nameof(Index));
                // send error to view
            }
            return View(vm);
        }
    }
}
