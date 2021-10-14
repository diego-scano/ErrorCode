using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILibraryBL mainBL;
        public BooksController(ILibraryBL mainBL)
        {
            this.mainBL = mainBL;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var result = this.mainBL.FetchBooks();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Book Id");

            var book = this.mainBL.FetchBookById(id);

            if (book == null)
                return NotFound("Book not found");

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateNewBook(Book newBook)
        {
            if (newBook == null)
                return BadRequest("Invalid data received");

            var result = this.mainBL.CreateBook(newBook);

            if (!result)
                return StatusCode(500, "Cannot add new Book");

            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            if (id <= 0)
                return BadRequest("Invalid Book Id");

            if (id != updatedBook.Id)
                return BadRequest("Book IDs not matching");

            var result = this.mainBL.EditBook(updatedBook);

            if (!result)
                return StatusCode(500, "Cannot update new Book");

            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Book Id");

            var result = this.mainBL.DeleteBookById(id);

            if (!result)
                return StatusCode(500, "Cannot delete the Book");

            return Ok();
        }
    }
}
