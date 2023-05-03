using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class AboutController : Controller
	{
		AboutManager aboutManager = new AboutManager(new EFAboutRepository());
		public IActionResult Index()
		{
			var values = aboutManager.GetList();
			return View(values);
		}

		public PartialViewResult SocialMediaAbout()
		{
			
			return PartialView();
		}
	}
}
