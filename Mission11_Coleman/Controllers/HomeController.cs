using Microsoft.AspNetCore.Mvc;
using Mission11_Coleman.Models;
using Mission11_Coleman.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Coleman.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository _repo;

        public HomeController(IBookstoreRepository temp)
        {
            _repo = temp;
        }
        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            //returning one variable to the view
            var blah = new BookListViewModel
            {
                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),


                //Making a pagination object
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }
            };

            return View(blah);
        }


    }
}
