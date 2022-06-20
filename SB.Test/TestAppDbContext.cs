using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SB.Application.Item.Dtos;
using SB.Core.Entities;
using SB.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Test
{
	public class TestAppDbContext : DbContext
	{
		private static DbContextOptions<ApplicationDBContext> contextOptions =
			new DbContextOptionsBuilder<ApplicationDBContext>()
			.UseInMemoryDatabase(databaseName: "DbShopBridge").Options;

		public ApplicationDBContext context;

		public TestAppDbContext()
		{
			Setup();
		}

		[OneTimeSetUp]
		public void Setup()
		{
			context = new ApplicationDBContext(contextOptions);
			context.Database.EnsureCreated();
			SeedData();
		}

		[OneTimeTearDown]
		public void CleanData()
		{
			context.Database.EnsureDeleted();
		}

		private void SeedData()
		{
			CreateItem();
		}
		private void CreateItem()
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
