using BooksApiProject.Context;
using BooksApiProject.Models;
using BooksApiProject.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentedBooksController : ControllerBase
    {
        private readonly BookDbContext _dbContext;

		public RentedBooksController(BookDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		[HttpGet("getAllRentedBooks")]
		public IActionResult GetAllRentedBooks()
		{
			var rentedBooks = _dbContext.RentedBooks.ToList();
			foreach (var book in rentedBooks)
			{
				book.User = _dbContext.Users.Find(book.UserId);
				book.Book = _dbContext.Books.Find(book.BookId);
			}
			return Ok(rentedBooks);
		}
		[HttpGet("getByIdRentedBook")]
		public IActionResult GetByIdRentedBook(int id)
		{
			var rentedBook = _dbContext.RentedBooks.Find(id);
			rentedBook.User = _dbContext.Users.Find(rentedBook.UserId);
			rentedBook.Book = _dbContext.Books.Find(rentedBook.BookId);
			return Ok(rentedBook);
		}

		//kiralama oluştuğunda kitap stoğundan düşsün istiyoruz
		[HttpPost("createRentedBook")]
		public IActionResult CreateRentedBook(CreateRentedBookViewModel model)
		{
			
			//stok azaltma
			var book = _dbContext.Books.Find(model.BookId);
			if(book.Stock>0)
			{
				//ekleme işlemi
				var newmodel = new RentedBook()
				{
					UserId = model.UserId,
					User=null,
					BookId=model.BookId,
					Book=null,
					StartDate=DateTime.Now,
					EndDate=null,
				};
				
				_dbContext.RentedBooks.Add(newmodel);
				book.Stock--;
				_dbContext.SaveChanges();
			}
			else
			{
				return BadRequest("Bu kitap elimizde mevcut degil");
			}

			return Ok("Kitap Kiralandi");
		}
		[HttpPut("updateRentedBook")]
		public IActionResult UpdateRentedBook(UpdateRentedBookViewModel model)
		{
			var rentedBook = _dbContext.RentedBooks.Find(model.Id);
			rentedBook.UserId = model.UserId;
			// kitap değiştiğinde karşılıklı olarak stock güncellenme işlemi
			if(rentedBook.BookId!=model.BookId)
			{
				var bookdata = _dbContext.Books.Find(rentedBook.BookId);
				bookdata.Stock++;
				var bookmodel = _dbContext.Books.Find(model.BookId);
				bookmodel.Stock--;
			}
			
			rentedBook.BookId = model.BookId;
			rentedBook.StartDate = DateTime.Now;
			_dbContext.RentedBooks.Update(rentedBook);
			_dbContext.SaveChanges();
			return Ok("Kiralanmis kitap guncellendi");
		}
		[HttpDelete("deleteRentedBook")]
		public IActionResult DeleteRentedBook(int id)
		{
			var rentedBook = _dbContext.RentedBooks.Find(id);
			if (rentedBook == null)
			{
				return NotFound("Kayit Bulunamadi");
			}
			_dbContext.RentedBooks.Remove(rentedBook);
			_dbContext.SaveChanges();
			return Ok("Kiralik Kitap Kayiti Silindi");
		}
	}
}
