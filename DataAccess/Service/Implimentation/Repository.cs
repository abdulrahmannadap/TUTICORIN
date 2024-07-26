using DataAccess.DbAccess;
using DataAccess.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;

namespace DataAccess.Service.Implimentation
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _context;
        public DbSet<T> _dbset;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public void Add(T Entity)
        {
            _dbset.Add(Entity);
        }

		public void Delete(int id)
        {
            var IdFromDb = _dbset.Find(id)!;
            _dbset.Remove(IdFromDb);
        }

		//public T FindById(Func<T, bool> func)
		//{
  //          if (func == null)
		//	_dbset.Find(func);
  //          else if (func == _context.EquipmentDetails.FirstOrDefault()) 
		//}

		public T Get(Expression<Func<T, bool>> expression, string? InnerProperty = null)
        {
            IQueryable<T> query = _dbset;
            if (!string.IsNullOrEmpty(InnerProperty))
            {
                foreach (var innerEntity in InnerProperty.Split(new char[] { ',', '-' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(innerEntity);
                }

            }

            return query.SingleOrDefault(expression)!;
        }

        public IEnumerable<T> GetAll(string? InnerProperty = null)
        {
            if (_dbset == null)
            {
                throw new InvalidOperationException("The DbSet is null.");
            }
            var datafrom = _dbset.Distinct();

            IQueryable<T> query = _dbset;

            if (!string.IsNullOrEmpty(InnerProperty))
            {
                foreach (var innerEntity in InnerProperty.Split(new char[] { ',', '-' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (innerEntity == null)
                    {
                        throw new ArgumentNullException(nameof(innerEntity), "One of the inner entities is null.");
                    }
                    query = query.Include(innerEntity);
                }
            }

            var result = query.ToList();

            if (result == null)
            {
                throw new InvalidOperationException("The result of the query is null.");
            }

            return result;
        }


        public T GetById(int id)
        {
            return _dbset.Find(id)!;
        }

        public void Update(T Entity)
        {
            _dbset.Update(Entity);
        }

	
	}
}
