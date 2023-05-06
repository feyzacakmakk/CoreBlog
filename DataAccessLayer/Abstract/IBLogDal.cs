using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBLogDal:IGenericDal<Blog>
    {
        List<Blog> GetListWithCategory(); //bu sadece blog için geçerli bir metot
        List<Blog> GetListWithCategoryByWriter(int id);
    }
}
