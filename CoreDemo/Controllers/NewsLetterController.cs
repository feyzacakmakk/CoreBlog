﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class NewsLetterController : Controller
	{
		//mail bültenine abone olma işlemini buradan gerçekleştiricez

		NewsLetterManager newsLetterManager = new NewsLetterManager(new EFNewsLetterRepository());

		[HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult SubscribeMail(NewsLetter newsLetter)
		{
			newsLetter.MailStatus = true;
			newsLetterManager.AddNewsLetter(newsLetter);
			return PartialView();
		}
	}
}
