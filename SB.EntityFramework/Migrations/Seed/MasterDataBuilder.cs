using Microsoft.EntityFrameworkCore;
using SB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.EntityFramework.Migrations.Seed
{
	public class MasterDataBuilder
	{
		private readonly Ap _context;
		public MasterDataBuilder(DbContext context)
		{
			_context = context;
		}
		public void Create()
		{
			AddCategories();
		}
		private void AddCategories()
		{

			bool anyAdded = false;

			string name = "Table";
			Entity_Category dbRecord = _context.E.FirstOrDefault(e => e.Name == name);
			if (dbRecord == null)
			{
				dbRecord = new Entity_Category
				{
					Name = name
				};



				_context.Categories.Add(dbRecord);
				anyAdded = true;
			}
			name = "Chairs";
			dbRecord = _context.Categories.FirstOrDefault(e => e.Name == name);
			if (dbRecord == null)
			{
				dbRecord = new Entity_Category
				{
					Name = name,
				};


				_context.Categories.Add(dbRecord);
				anyAdded = true;

			}
			name = "Wardroabs";
			dbRecord = _context.Categories.FirstOrDefault(e => e.Name == name);
			if (dbRecord == null)
			{
				dbRecord = new Entity_Category
				{
					Name = name,
				};


				_context.Categories.Add(dbRecord);
				anyAdded = true;

			}
			name = "Beds";
			dbRecord = _context.Categories.FirstOrDefault(e => e.Name == name);
			if (dbRecord == null)
			{
				dbRecord = new Entity_Category
				{
					Name = name,
				};


				_context.Categories.Add(dbRecord);
				anyAdded = true;

			}
			name = "Sofas";
			dbRecord = _context.Categories.FirstOrDefault(e => e.Name == name);
			if (dbRecord == null)
			{
				dbRecord = new Entity_Category
				{
					Name = name,
				};


				_context.Categories.Add(dbRecord);
				anyAdded = true;

			}

			if (anyAdded)
			{
				_context.SaveChanges();
			}
		}

	}
}
