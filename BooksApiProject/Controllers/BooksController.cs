using BooksApiProject.Context;
using BooksApiProject.Models;
using BooksApiProject.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BooksApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _dbContext;

        public BooksController(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("getAllBooks")]
        public IActionResult GetAllBooks()
        {
            var books = _dbContext.Books.ToList();
            return Ok(books);
        }

        [HttpPost("createBook")]

        public IActionResult CreateBook(CreateBookViewModel model)
        {
            if(model.Title==null || model.Title=="" || model.Title.IsNullOrEmpty())
            {
                return BadRequest("Başlik Alani Boş Geçilemez");
            }
			if (model.Author == null || model.Author == "" || model.Author.IsNullOrEmpty())
			{
				return BadRequest("Yazar Alani Boş Geçilemez");
			}
            var newmodel = new Book()
            {
                Author=model.Author,
                Title=model.Title,
                Stock=model.Stock,
            };
            _dbContext.Books.Add(newmodel);
            _dbContext.SaveChanges();
            return Ok("Kitap Oluşturuldu");
        }
        [HttpGet("getByIdBook")]
        public IActionResult GetByIdBook(int id)
        {
            var book = _dbContext.Books.Where(x => x.Id == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound("Kitap Bulunamadi");
            }
            return Ok(book); 
        }
        [HttpPut("updateBook")]
        public IActionResult UpdateBook(Book model)
        {
            var book = _dbContext.Books.Where(x => x.Id == model.Id).FirstOrDefault();
            if (book == null)
            {
                return NotFound("Kitap Bulunamadi");
            }
            book.Title = model.Title;
            book.Author = model.Author;
            book.Stock = model.Stock;
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();
            return Ok("Kitap Guncellendi");
        }

        [HttpDelete("deleteBook")]
        public IActionResult DeleteBook(int id)
        {
            var book = _dbContext.Books.Where(x => x.Id == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound("Kitap Bulunamadi");
            }
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
            return Ok("Kitap Silindi");
        }

    }
}
