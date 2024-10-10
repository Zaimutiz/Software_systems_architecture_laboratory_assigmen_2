using Microsoft.AspNetCore.Mvc;
using BooksAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BooksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "The Midnight Library", Author = "Matt Haig", Year = 2020, Genre = "Fiction" },
            new Book { Id = 2, Title = "The Vanishing Half", Author = "Brit Bennett", Year = 2020, Genre = "Fiction" },
            new Book { Id = 3, Title = "Project Hail Mary", Author = "Andy Weir", Year = 2021, Genre = "Thriller" }
        };

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            return Ok(books);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public ActionResult<Book> CreateBook(Book book)
        { 
            book.Id = books.Max(b => b.Id) + 1;
            books.Add(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Book updatedBook)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.Year = updatedBook.Year;
            existingBook.Genre = updatedBook.Genre;

            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            books.Remove(book);
            return NoContent();
        }
    }
}
