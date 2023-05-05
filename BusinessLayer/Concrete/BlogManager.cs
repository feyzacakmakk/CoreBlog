using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBLogDal _blogDal;

		public BlogManager(IBLogDal blogDal)
		{
			_blogDal = blogDal;
		}
	
		public List<Blog> GetBlogByID(int id)
		{
			return _blogDal.GetAllList(x => x.BlogID == id);
			//benim dışarıdan gönderdiğim id^ye eşit olan değerleri listele demek
		}

        //BlogManager

		public List<Blog> GetLast3Blog()
		{
			return _blogDal.GetAllList().Take(3).ToList();
		}
		
        public List<Blog> GetBlogListByWriter(int id)
        {
			return _blogDal.GetAllList(x => x.WriterID == id);
        }

        public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}

		public Blog GetById(int id)
		{
			throw new NotImplementedException();
		}

		//BlogManager
		public List<Blog> GetList()
		{
			return _blogDal.GetAllList(); //Igenericdal'dan kalıtım alan
										  //genericRepo'daki getAllList kullanıyoruz
		}

		public void TAdd(Blog t)
		{
			_blogDal.Insert(t);
		}

		public void TDelete(Blog t)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Blog t)
		{
			throw new NotImplementedException();
		}
	}
}
