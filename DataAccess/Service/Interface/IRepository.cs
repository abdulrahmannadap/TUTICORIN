using Models;
using System.Linq.Expressions;

namespace DataAccess.Service.Interface
{
	public interface IRepository<T> where T : class
	{
		public void Add(T Entity);
		public void Update(T Entity);
		public void Delete(int id);
		public T GetById(int id);
		public IEnumerable<T> GetAll(string? InnerProperty = null);
		public T Get(Expression<Func<T, bool>> expression, string? InnerProperty = null);
		//public T FindById(Func<T,bool> func);
	}
}
