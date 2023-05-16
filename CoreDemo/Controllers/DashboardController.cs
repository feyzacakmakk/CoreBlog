using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        DashboardManager dashboardManager = new DashboardManager(new EFDashboardRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewBag.totalBlog = dashboardManager.GetTotalBlog();
            ViewBag.totalCategories=dashboardManager.GetTotalCategories();
            ViewBag.totalWriterBlog=dashboardManager.GetTotalBlogByWriterId();
            return View();
        }
    }
}
