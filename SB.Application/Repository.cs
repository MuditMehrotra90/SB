using Microsoft.EntityFrameworkCore;
using SB.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SB.Application
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDBContext context;
		private DbSet<T> DbSet;

		public Repository(ApplicationDBContext _context)
		{
			this.context = _context;
			DbSet = context.Set<T>();
		}
		public IQueryable<T> GetAll()
		{
			return DbSet.AsQueryable();
		}
		public async Task<long> Add(T entity)
		{
			await DbSet.AddAsync(entity);
			await context.SaveChangesAsync();
			var IdProperty = entity.GetType().GetProperty("ID").GetValue(entity, null);
			return (long)IdProperty;
		}
		public async Task Update(T entity)
		{
			DbSet.Attach(entity);
			context.Entry(entity).State = EntityState.Modified;
			await context.SaveChangesAsync();
		}
		public async Task Delete(T entity)
		{
			DbSet.Remove(entity);
			await context.SaveChangesAsync();
		}
		public async Task<T> FindById(long id)
		{
			return await DbSet.FindAsync(id);
		}
	}
}
