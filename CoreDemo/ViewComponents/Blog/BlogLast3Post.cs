using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
	public class BlogLast3Post : ViewComponent
	{
		BlogManager blogManager = new BlogManager(new EFBlogRepository());
		public IViewComponentResult Invoke()
		{
			var values = blogManager.GetLast3Blog();
			return View(values);
		}
	}
}
