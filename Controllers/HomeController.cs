using Microsoft.AspNetCore.Mvc;
using Mission011_Sorensen.Models;
using System.Diagnostics;
using Mission011_Sorensen.Models.ViewModels;


namespace Mission011_Sorensen.Controllers
{
    public class HomeController : Controller
    {

        //Create a instance of IBookRepository
        private IBookRepository _repo;


        //Create a Temp instance of IBookRepository
        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }


        //For the index set the number of items per page  and grab the book info from the database
        ///and count how many books exist  aand return it to the view
        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;
            var bookinfo = new BookListViewModel
            {


                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip(pageSize * (pageNum - 1))
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = 10,
                    TotalItems = _repo.Books.Count()
                }
            };
             return View(bookinfo);
        }

    }
}

