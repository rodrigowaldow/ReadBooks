using Microsoft.AspNetCore.Mvc;
using ReadBooks.Application.InputModels;
using ReadBooks.Application.Services.Interfaces;

namespace ReadBooks.API.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var books = _bookService.GetAll(query);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewBookInputModel inputModel)
        {
            var id = _bookService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateBookInputModel inputModel)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Update(inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookService.GetById(id);

            if (book == null)
            {
                return NotFound();
            }

            _bookService.Delete(id);

            return NoContent();
        }

        [HttpPost("{id}/notes")]
        public IActionResult PostNotes(int id, [FromBody] NewNoteInputModel inputModel)
        {
            _bookService.CreateNote(inputModel);

            return CreatedAtAction(nameof(GetById), new { id }, inputModel);
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _bookService.Start(id);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _bookService.Finish(id);

            return NoContent();
        }
    }
}
