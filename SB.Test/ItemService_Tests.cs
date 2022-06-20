using SB.Application.Item;
using SB.Core.Entities;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using SB.API.Controllers;
using System.Net.Http;
using SB.Application.Item.Dtos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SB.Application;
using SB.API;

namespace SB.Test
{
	public class ItemService_Tests : TestAppDbContext
	{
		private readonly Mock<IRepository<Entity_Item>> _mockItemRepository;
		private static IMapper _mapper;
		public ItemService_Tests()
		{
			_mockItemRepository = new Mock<IRepository<Entity_Item>>();
			if (_mapper == null)
			{
				// Auto Mapper Configurations
				var mapperConfig = new MapperConfiguration(mc =>
				{
					mc.AddProfile(new CustomDtoMapper());
				});

				IMapper mapper = mapperConfig.CreateMapper();
				_mapper = mapper;
			}
		}
		[Fact]
		public async Task Test_GetAllItems()
		{
			//Arrange
			var fakeData = context.Items.AsQueryable();
			_mockItemRepository.Setup(x => x.GetAll()).Returns(fakeData);
			ItemService itemService = new ItemService(_mockItemRepository.Object, _mapper);
			var input = new ItemFilterDto { PageNumber = 1, PageSize = 2 };

			//Act
			var items = await itemService.GetAllItems(input);
			CleanData();

			//Assert
			items.ItemListDto.Count.ShouldBe(2);
			items.MaxResultCount.ShouldBe(3);
		}

		[Fact]
		public async Task Should_Not_Create_Item()
		{
			//Arrange
			var fakeData = context.Items.AsQueryable();
			_mockItemRepository.Setup(x => x.GetAll()).Returns(fakeData);
			ItemService itemService = new ItemService(_mockItemRepository.Object, _mapper);
			CreateOrEditInputDto input = new CreateOrEditInputDto
			{
				Category_ID_FK = 1,
				Description = "Lorem Ipsum",
				Id = 0,
				ItemCode = "12304",
				Name = "Should Create Item",
				Price = 100
			};

			//Act
			var id = await itemService.CreateOrEdit(input);
			var item = await context.Items.FirstOrDefaultAsync(x => x.Name == "Should Create Item");
			CleanData();

			//Assert
			id.ShouldBe(0);
			item.ShouldBe(null);


		}

		[Fact]
		public async Task Should_Edit_Item()
		{
			//Arrange
			var fakeData = context.Items.AsQueryable();
			_mockItemRepository.Setup(x => x.GetAll()).Returns(fakeData);
			ItemService itemService = new ItemService(_mockItemRepository.Object, _mapper);
			CreateOrEditInputDto input = new CreateOrEditInputDto
			{
				Category_ID_FK = 1,
				Description = "Lorem Ipsum",
				Id = 1,
				ItemCode = "12304",
				Name = "Should Edit Item",
				Price = 100
			};

			//Act
			await itemService.CreateOrEdit(input);
			var item = await context.Items.FirstOrDefaultAsync(x=>x.ID == 1);
			CleanData();
			//Assert
			item.ShouldNotBe(null);
			item.Name.ShouldBe("Should Edit Item");
			item.ItemCode.ShouldBe("12304");
		}

		[Fact]
		public async Task Should_Not_Edit_Item()
		{
			//Arrange
			var fakeData = context.Items.AsQueryable();
			_mockItemRepository.Setup(x => x.GetAll()).Returns(fakeData);
			ItemService itemService = new ItemService(_mockItemRepository.Object, _mapper);
			CreateOrEditInputDto input = new CreateOrEditInputDto
			{
				Category_ID_FK = 1,
				Description = "Lorem Ipsum",
				Id = 0,
				ItemCode = "12304",
				Name = "Should Edit Item",
				Price = 100
			};

			//Act
			await itemService.CreateOrEdit(input);
			var item = await context.Items.FirstOrDefaultAsync(x => x.ID == 1);
			CleanData();

			//Assert
			item.ShouldNotBe(null);
			item.Name.ShouldNotBe("Should Edit Item");
			item.ItemCode.ShouldNotBe("12304");
		}

		[Fact]
		public async Task Should_Throw_No_Record_Found()
		{
			//Arrange
			var fakeData = context.Items.AsQueryable();
			_mockItemRepository.Setup(x => x.GetAll()).Returns(fakeData);
			ItemService itemService = new ItemService(_mockItemRepository.Object, _mapper);
			CreateOrEditInputDto input = new CreateOrEditInputDto
			{
				Category_ID_FK = 1,
				Description = "Lorem Ipsum",
				Id = 4,
				ItemCode = "12304",
				Name = "Should Edit Item",
				Price = 100
			};
			//Act
			var item = await context.Items.FirstOrDefaultAsync(x => x.ID == 4);
			Exception exception = await Assert.ThrowsAsync<Exception>(async () => await itemService.CreateOrEdit(input));
			CleanData();
			//Assert
			item.ShouldBe(null);
			Assert.Equal("No record found", exception.Message);
		}
	}
}
