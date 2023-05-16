using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.IO;

namespace CoreDemo.Controllers
{
	public class WriterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EFWriterRepository());

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult WriterProfile()
		{
			return View();
		}

		public IActionResult WriterMail()
		{
			return View();
		}

		[AllowAnonymous]
		public IActionResult Test()
		{
			return View();
		}

		[AllowAnonymous]
		public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}

		[AllowAnonymous]
		public PartialViewResult WriterFooterPartial()
		{
			return PartialView();
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterEditProfile()
		{
			var writervalues = writerManager.TGetById(1);
			return View(writervalues);
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult WriterEditProfile(Writer writer)
		{
			//Güncelleme yapabilmek için önce validasyondan geçmek gerek
			WriterValidator validationRules = new WriterValidator();
			ValidationResult validationResult = validationRules.Validate(writer);
			if (validationResult.IsValid) //sonuçlar geçerliyse
			{
				writerManager.TUpdate(writer);
				return RedirectToAction("Index", "Dashboard");
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}

		[AllowAnonymous]
		[HttpGet]
		public IActionResult WriterProfileAdd()
		{
			return View();
		}

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterProfileAdd(AddProfileImage photo)
        {
			Writer writer = new Writer();
			if (photo.WriterImage!=null) //resim boş değilse
			{
				//klasörün içine kopyalama işlemi gerçekleştiricez
				var extension=Path.GetExtension(photo.WriterImage.FileName);
				var newimagename = Guid.NewGuid()+extension;
				var location=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/WriterImageFiles/", newimagename);
				var stream = new FileStream(location, FileMode.Create);
				photo.WriterImage.CopyTo(stream);
				writer.WriterImage = newimagename;

			}
			writer.WriterMail=photo.WriterMail;
			writer.WriterName=photo.WriterName;
			writer.WriterPassword=photo.WriterPassword;
			writer.WriterAbout=photo.WriterAbout;
			writer.WriterStatus = true;
            writerManager.TUpdate(writer);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
