using booksManagementSystem.Models;
//using booksManagementSystem.Models.In_Memory_Repository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Book>> Get() => BookRepository.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Book> Get(int id)
    {
        var book = BookRepository.GetById(id);
        if (book == null) return NotFound();
        return book;
    }

    [HttpPost]
    public IActionResult Post(Book book)
    {
        BookRepository.Add(book);
        return CreatedAtAction(nameof(Get), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Book updatedBook)
    {
        var existingBook = BookRepository.GetById(id);
        if (existingBook == null)
        {
            return NotFound();
        }

        // Update properties
        existingBook.Title = updatedBook.Title;
        existingBook.Author = updatedBook.Author;
        existingBook.ISBN = updatedBook.ISBN;
        existingBook.PublicationDate = updatedBook.PublicationDate;

        BookRepository.Update(existingBook); // Ensure Update() exists in repository
        return NoContent();
    }



    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        BookRepository.Delete(id);
        return NoContent();
    }
}
