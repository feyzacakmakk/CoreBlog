using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DashboardManager:IDashboardService
    {
        IDashboardDal _dashboardDal;

        public DashboardManager(IDashboardDal dashboardDal)
        {
            _dashboardDal = dashboardDal;
        }

        public int GetTotalBlog()
        {
            return _dashboardDal.GetTotalBlog();
        }

        public int GetTotalBlogByWriterId()
        {
            return _dashboardDal.GetBlogByWriterId();
        }

        public int GetTotalCategories()
        {
            return _dashboardDal.GetTotalCategories();
        }
    }
}
