using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class RegisterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EFWriterRepository());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Writer writer)
		{
			WriterValidator writerValidator = new WriterValidator();
			ValidationResult results = writerValidator.Validate(writer);
			//writer'dan gelen verileri writerVal. içindeki değerleri Validate yani kontrol edeceksin
			if (results.IsValid) //eğer sonuçlar geçerliyse
			{
				writer.WriterAbout = "Deneme yazar kaydı";
				writer.WriterStatus = true;
				writerManager.WriterAdd(writer);
				return RedirectToAction("Index", "Blog");
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
