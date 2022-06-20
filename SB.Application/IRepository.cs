using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Application
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> GetAll();
		Task<long> Add(T entity);
		Task Delete(T entity);
		Task Update(T entity);
		Task<T> FindById(long Id);
	}
}
