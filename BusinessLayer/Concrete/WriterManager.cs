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
	public class WriterManager : IWriterService
	{
		IWriterDal _writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

        //admin panelinde bütün yazarları listelerken kullanıcaz
        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        //gönderdiğim id'ye eşit olan yazarları getirmek için kullanıcaz
        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.GetAllList(x=>x.WriterID==id);
        }

        public void TAdd(Writer t)
        {
            _writerDal.Insert(t); //genericrepo'daki Insert metodu
        }

        public void TDelete(Writer t)
        {
            throw new NotImplementedException();
        }

        public Writer TGetById(int id)
        {
            return _writerDal.GetByID(id);
        }

        public void TUpdate(Writer t)
        {
            _writerDal.Update(t);
        }
    }
}
