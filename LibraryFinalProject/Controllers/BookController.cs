using LibraryFinalProject.IRepository;
using LibraryFinalProject.Models;
using LibraryFinalProject.Models.DbContext;
using LibraryFinalProject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryFinalProject.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        IBookRepo BookRepository;

        public BookController(IBookRepo BookRepo)
        {
            BookRepository = BookRepo;
        }

        public IActionResult Index(string search)
        {
            List<BookAndGenreViewModel> BookList;
            if (string.IsNullOrEmpty(search))
            {
                BookList = BookRepository.AllBookAndGenre(); 
            }
            else
            {
                BookList = BookRepository.SearchBooks(search);
                ViewData["SearchQuery"] = search;
            }
            return View(BookList);
        }

        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult IndexForManagers(string search)
        {
            List<BookAndGenreViewModel> BookList;
            if (string.IsNullOrEmpty(search))
            {
                BookList = BookRepository.AllBookAndGenre();
            }
            else
            {
                BookList = BookRepository.SearchBooks(search); 
                ViewData["SearchQuery"] = search;
            }
            return View(BookList);
        }

        public IActionResult Details(int id)
        {
            BookAndGenreViewModel BookViewModel = BookRepository.GetBookAndGenre(id);
            return View(BookViewModel);
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpGet]
        public IActionResult AddBook()
        {
            BookAndGenreViewModel bookViewModel = new BookAndGenreViewModel();
            bookViewModel.genres = BookRepository.GetAllGenre();
            return View(bookViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBook(BookAndGenreViewModel NewBookVM)
        {
            if (ModelState.IsValid)
            {
                BookRepository.Insert(NewBookVM);
                return RedirectToAction("IndexForManagers");
            }
            NewBookVM.genres = BookRepository.GetAllGenre();
            return View(NewBookVM);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Librarian")]
        public IActionResult EditBook(int id)
        {
            if (id == 0)
                return Content("Error Insert id");
            BookAndGenreViewModel BookViewModel = new BookAndGenreViewModel();
            Book Book = BookRepository.GetById(id);
            BookViewModel.Id = Book.Id;
            BookViewModel.Author = Book.Author;
            BookViewModel.Description = Book.Description;
            BookViewModel.ISBN = Book.ISBN;
            BookViewModel.Book_Photo = Book.Book_Photo;
            BookViewModel.Publish_Date = Book.Publish_Date;
            BookViewModel.Availability_Status = Book.Availability_Status;
            BookViewModel.Genre_Id = Book.Genre_Id;
            BookViewModel.Title = Book.Title;
            BookViewModel.PricePerWeek = Book.PricePerWeek;
            BookViewModel.genres = BookRepository.GetAllGenre();
            return View(BookViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditBook(int id, BookAndGenreViewModel BookVM)
        {
            if (ModelState.IsValid)
            {
                BookRepository.Update(id, BookVM);
                return RedirectToAction("IndexForManagers");
            }
            BookVM.genres = BookRepository.GetAllGenre();
            return View(BookVM);
        }

        public IActionResult DeleteBook(int id)
        {
            BookRepository.Delete(id);
            return RedirectToAction("IndexForManagers");
        }
    }
}