using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        public IViewComponentResult Invoke()
        {
            //id'si 1 olan yazara göre işlem yapıyoruz
            var values = writerManager.GetWriterById(1);
            return View(values); //değerleri view'a yolluyoruz
        }
    }
}
