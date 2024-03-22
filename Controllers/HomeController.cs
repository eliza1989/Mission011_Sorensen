using Microsoft.AspNetCore.Mvc;
using Mission011_Sorensen.Models;
using System.Diagnostics;
using Mission011_Sorensen.Models.ViewModels;

namespace Mission011_Sorensen.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;

        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;
            var bookinfo = new ProjectListViewModel
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

