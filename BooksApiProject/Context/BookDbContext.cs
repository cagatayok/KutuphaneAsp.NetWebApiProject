using BooksApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApiProject.Context
{
	public class BookDbContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-3U9KI3T\\SQLEXPRESS; database=BookApiProject; User Id=sa; Password=1; TrustServerCertificate=True");
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<RentedBook> RentedBooks { get; set; }
	}
}
