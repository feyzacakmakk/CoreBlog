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
	public class CommentManager : ICommentService
	{
		ICommentDal _commentDal;

		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}

		public void CommentAdd(Comment comment)
		{
			_commentDal.Insert(comment); //IGenericDal'daki Insert metodu
			
		}

		public List<Comment> GetList(int id)
		{
			return _commentDal.GetAllList(x=>x.BlogID==id); 
			//BlogId si benim gönderdiğim id'ye eşit olana göre yorumları listele
			//IGenericDal'dan gelen GenericRepository'deki GetAllList(Expression) metodu
		}
	}
}
