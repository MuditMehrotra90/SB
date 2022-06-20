using SB.Core.Entities;
using SB.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Test
{
	public class TestDbInitializer
	{
        public static void Initialize(ApplicationDBContext context)
        {
            if (context.Items.Any())
            {
                return;
            }
            Seed(context);
        }
        private static void Seed(ApplicationDBContext context)
        {
			CreateCategory(context);
			CreateItem(context);
        }

		private static void CreateCategory(ApplicationDBContext context)
		{
			var category = new List<Entity_Category>
			{
				new Entity_Category()
				{
					Id = 1,
					Name = "Test Category 1",
					CreatedOn = DateTime.Now,
					UpdatedOn = DateTime.Now,
					IsDeleted = false
				},
				new Entity_Category()
				{
					Id = 2,
					Name = "Test Category 2",
					CreatedOn = DateTime.Now,
					UpdatedOn = DateTime.Now,
					IsDeleted = false
				},
				new Entity_Category()
				{
					Id = 3,
					Name = "Test Category 3",
					CreatedOn = DateTime.Now,
					UpdatedOn = DateTime.Now,
					IsDeleted = false
				}
			};
			context.Categories.AddRange(category);
			context.SaveChanges();
		}
		private static void CreateItem(ApplicationDBContext context)
		{
			var items = new List<Entity_Item>
			{
				new Entity_Item()
				{
					ID = 1,
					Category_ID_FK = 1,
					Description = "Test Item 1 Description",
					ItemCode = "0001",
					Price = 100,
					Name = "Test Item 1",
					CreatedOn = DateTime.Now,
					UpdatedOn = DateTime.Now,
					IsDeleted = false
				},
				new Entity_Item()
				{
					ID = 2,
					Category_ID_FK = 1,
					Description = "Test Item 2 Description",
					ItemCode = "0001",
					Price = 100,
					Name = "Test Item 2",
					CreatedOn = DateTime.Now,
					UpdatedOn = DateTime.Now,
					IsDeleted = false
				},
				new Entity_Item()
				{
					ID = 3,
					Category_ID_FK = 3,
					Description = "Test Item 3 Description",
					ItemCode = "0001",
					Price = 100,
					Name = "Test Item 3",
					CreatedOn = DateTime.Now,
					UpdatedOn = DateTime.Now,
					IsDeleted = false
				}
			};
			context.Items.AddRange(items);
			context.SaveChanges();
		}
	}
}
