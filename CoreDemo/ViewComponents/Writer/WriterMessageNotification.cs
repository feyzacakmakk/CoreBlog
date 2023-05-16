using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
	public class WriterMessageNotification:ViewComponent
	{
		MessageManager messageManager = new MessageManager(new EFMessageRepository());

		public IViewComponentResult Invoke()
		{
			string mail;
			mail = "deneme@gmail.com"; //burası ileride Session'dan gelen değerden gelecek
			var values = messageManager.GetInboxListByWriter(mail);
			return View(values);
		}
	}
}
