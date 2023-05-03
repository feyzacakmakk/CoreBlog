using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
	public class ContactController : Controller
	{
		ContactManager contactManager = new ContactManager(new EFContactRepository());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			contact.ContactStatus = true;
			contactManager.ContactAdd(contact);
			return RedirectToAction("Index", "Blog");
			//işlem bittikten sonra BlogControllerdaki Index Action'ına yönlendir
		}
	}
}
