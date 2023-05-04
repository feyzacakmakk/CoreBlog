using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
	public class LoginController : Controller
	{
		[HttpGet]
		[AllowAnonymous] //proje seviyesinde koyduğum bütün kurallardan muaf ol demek 
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Index(Writer writer)
		{
			Context context = new Context();
			var datavalue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail &&
			x.WriterPassword == writer.WriterPassword);
			//tek değer getirmek, tek değer üzerinde işlem yapmak ve üzerinden sorgulama yapmak için kullanılır
			if (datavalue != null) //boş değilse
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name,writer.WriterMail)
				};
				var useridentity = new ClaimsIdentity(claims, "a");
				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(useridentity);
				await HttpContext.SignInAsync(claimsPrincipal);
				return RedirectToAction("Index", "Writer");
			}
			else
			{
				return View();
			}	
				
		}
	}
}
//Context context = new Context();
//var datavalue = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail &&
//x.WriterPassword == writer.WriterPassword);
////tek değer getirmek, tek değer üzerinde işlem yapmak ve üzerinden sorgulama yapmak için kullanılır
//if (datavalue != null) //boş değilse
//{                                   //key,value
//	HttpContext.Session.SetString("username", writer.WriterMail);
//	//username'e göre işlem yap
//	return RedirectToAction("Index", "Writer");