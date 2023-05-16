using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFDashboardRepository : IDashboardDal
    {
        public int GetBlogByWriterId()
        {
            using (var context = new Context())
            {
                return context.Blogs.Where(x=>x.WriterID==1).Count();
            }
        }

        public int GetTotalBlog()
        {
            using (var context = new Context())
            {                
               return context.Blogs.Count();
            }
        }

        public int GetTotalCategories()
        {
            using (var context = new Context())
            {
                return context.Categories.Count();
            }
        }
    }
}
