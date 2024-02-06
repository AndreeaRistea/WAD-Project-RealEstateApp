using AgentieImobiliarWeb.Data;
using AgentieImobiliarWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AgentieImobiliarWeb.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		protected EstateContext _context { get; set; }

		public RepositoryBase(EstateContext context)
		{
			_context = context;
		}

		public IQueryable<T> FindAll()
		{
			return _context.Set<T>().AsNoTracking();
		}

		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
		{
			return _context.Set<T>().Where(expression).AsNoTracking();
		}

		public void Create(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
		}
	}
}
