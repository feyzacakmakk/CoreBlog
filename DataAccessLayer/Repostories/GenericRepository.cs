using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repostories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T entity)
        {
            using var context = new Context();
            context.Remove(entity);
            context.SaveChanges();
        }

        public List<T> GetAllList()
        {
            using var context = new Context();
            return context.Set<T>().ToList(); //EntityFramework'ten gelen listeleme metodu
            //bir entity olmadığı için dışarıdan entity alacak şekilde Set<> kullandık
        }

        public T GetByID(int id)
        {
            using var context = new Context();
            return context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            using var context = new Context();
            context.Add(entity);
            context.SaveChanges();
        }

        //GenericRepository
		public List<T> GetAllList(Expression<Func<T, bool>> filter)
		{
			using var context = new Context();
            return context.Set<T>().Where(filter).ToList(); //gelen filtreye göre listelencek
		}

		public void Update(T entity)
        {
            using var context = new Context();
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
