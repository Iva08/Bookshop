using BookshopApplication.Data;
using BookshopApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookshopApplication.Controllers
{
	public class BookController : Controller
	{
		private readonly ApplicationDbContext _db;

		public BookController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<Book> objBookList = _db.Books;
			return View(objBookList);
		}

		//GET
		public IActionResult Add()
		{

			return View();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(Book obj)
		{
			if (ModelState.IsValid)
			{
				_db.Books.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		//GET
		public IActionResult Update(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var bookFromDb = _db.Books.Find(id);
			//var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
			//var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

			if (bookFromDb == null)
			{
				return NotFound();
			}

			return View(bookFromDb);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Book obj)
		{

			if (ModelState.IsValid)
			{
				_db.Books.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		//GET
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var bookFromDb = _db.Books.Find(id);
			//var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
			//var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

			if (bookFromDb == null)
			{
				return NotFound();
			}

			return View(bookFromDb);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{
			var obj = _db.Books.Find(id);
			if (obj == null)
			{
				return NotFound();
			}


			_db.Books.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
