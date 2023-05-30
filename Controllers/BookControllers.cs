using Microsoft.AspNetCore.Mvc;
using BookstoreManagementSystem.Models;
using System.Collections.Generic;

namespace BookstoreManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static List<Book> _books = new List<Book>();

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return _books;
        }

        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            _books.Add(book);
            return book;
        }

        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook(int id, Book updatedBook)
        {
            var book = _books.Find(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Category = updatedBook.Category;

            return book;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = _books.Find(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            _books.Remove(book);

            return NoContent();
        }
    }
}
