using homework2_BooksApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace homework2_BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // GET: api/books/getAll
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            try
            {
                return Ok(BookDb.Books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Server error. Contact the admin. {ex.Message}");
            }
        }

        // GET: api/books/getByIndex?index=0
        [HttpGet("getByIndex")]
        public ActionResult<Book> GetBookByIndex(int? index)
        {
            try
            {
                if (index == null || index < 0)
                {
                    return BadRequest("Index is required and cannot be negative.");
                }

                if (index >= BookDb.Books.Count)
                {
                    return NotFound($"No book found at index {index}");
                }

                return Ok(BookDb.Books[index.Value]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Server error. Contact the admin. {ex.Message}");
            }
        }

        // GET: api/books/filter?author=Bob+Bobsky&title=Python+Beginner+Guide
        [HttpGet("filter")]
        public ActionResult<Book> GetBookByAuthorAndTitle(string? author, string? title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) || string.IsNullOrEmpty(title))
                {
                    return BadRequest("Both author and title are required.");
                }

                var book = BookDb.Books.FirstOrDefault
                    (b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase) && b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                // Since To.Lower() creates unnecessary memory allocations

                if (book == null)
                {
                    return NotFound("Book not found.");
                }

                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Server error. Contact the admin. {ex.Message}");
            }
        }

        // POST: api/books/
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            try
            {
                if (string.IsNullOrEmpty(newBook.Author) || string.IsNullOrEmpty(newBook.Title))
                {
                    return BadRequest("Author and Title cannot be empty.");
                }

                BookDb.Books.Add(newBook);
                return StatusCode(StatusCodes.Status201Created, "Book added successfully.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Server error. Contact the admin. {e.Message}");
            }
        }

        // Bonus requiement;
        // POST: api/books/titles
        [HttpPost("titles")]
        public ActionResult<List<string>> GetTitlesFromBooks([FromBody] List<Book> books)
        {
            try
            {
                if (books == null || books.Count == 0)
                {
                    return BadRequest("The list of books cannot be empty.");
                }

                List<string> titles = books.Select(b => b.Title).ToList();
                return Ok(titles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Server error. Contact the admin. {ex.Message}");
            }
        }
    }
}