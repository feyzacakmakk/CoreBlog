using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
	public class CommentController : Controller
	{
		CommentManager commentManager = new CommentManager(new EFCommentRepository());
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public PartialViewResult PartialAddComment()
		{
			return PartialView();
		}


		[HttpPost]
		public PartialViewResult PartialAddComment(Comment comment)
		{
			comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			comment.CommentStatus = true; //yorum yayında olacak
			comment.BlogID = 1;
			commentManager.CommentAdd(comment);
			return PartialView();
		}

		public PartialViewResult CommentListByBlog(int id)
		{

			var values = commentManager.GetList(id); //ICommentService'den kalıtım alan ComManagerdan geliyo
			return PartialView(values);
		}
	}
}
