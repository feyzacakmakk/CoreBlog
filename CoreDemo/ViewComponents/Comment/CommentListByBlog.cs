﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comment
{
	public class CommentListByBlog:ViewComponent
	{
		CommentManager commentManager = new CommentManager(new EFCommentRepository());
		public IViewComponentResult Invoke(int id)
		{
			var values = commentManager.GetList(id);
			return View(values);
		}
	}
}
