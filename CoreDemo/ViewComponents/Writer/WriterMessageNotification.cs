using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
	public class WriterMessageNotification:ViewComponent
	{
		WriterManager WriterManager = new WriterManager(new EFWriterRepository());

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
