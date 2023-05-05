using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new EFBlogRepository());
        public IActionResult Index()
        {
            var values = blogManager.GetBlogListWithCategory(); 
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.id = id;
            var values = blogManager.GetBlogByID(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var values= blogManager.GetBlogListByWriter(1);
            return View(values);
        }


		[HttpGet]
        public IActionResult BlogAdd()
		{
            CategoryManager categoryManager = new CategoryManager(new EFCategoryRepository());
            List<SelectListItem> categoryvalues = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text=x.CategoryName,
                                                       Value=x.CategoryID.ToString()
                                                   }).ToList();
            
            ViewBag.cv = categoryvalues;
            return View();
                                                
		}

		[HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
			BlogValidator writerValidator = new BlogValidator();
			ValidationResult results = writerValidator.Validate(blog);
			if (results.IsValid) //eğer sonuçlar geçerliyse
			{
				blog.BlogStatus = true;
                blog.BlogCreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterID = 1;
                blogManager.TAdd(blog);
				return RedirectToAction("BlogListByWriter", "Blog");
				//Blogcontrollerdaki Index action'una git
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
        }
    }
}
