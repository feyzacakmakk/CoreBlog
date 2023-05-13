using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context context = new Context();
            ViewBag.toplamBlogSayisi=context.Blogs.Count().ToString();
            ViewBag.yazarBlogSayisi=context.Blogs.Where(x=>x.WriterID==1).Count().ToString();
            ViewBag.kategoriSayisi=context.Categories.Count().ToString();
            return View();
        }
    }
}
