using Microsoft.AspNetCore.Mvc;

namespace TOU.Note.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {

            return View();
        }
    }
}
