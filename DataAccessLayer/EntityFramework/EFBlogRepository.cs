using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EFBlogRepository : GenericRepository<Blog>, IBLogDal
	{
		public List<Blog> GetListWithCategory()
		{
			using (var context=new Context())
			{					//Hangi Entity bunun içine dahil edilecekse onu yazıyoruz
				return context.Blogs.Include(x => x.Category).ToList();
			}
		}
	}
}
