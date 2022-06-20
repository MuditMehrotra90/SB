using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SB.Application.Item.Dtos;
using SB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace SB.Application.Item
{
	public class ItemService : IItemService
	{
		private readonly IRepository<Entity_Item> _itemRepository;
		private readonly IMapper _mapper;

		public ItemService(IRepository<Entity_Item> itemRepository, IMapper mapper)
		{
			_itemRepository = itemRepository;
			_mapper = mapper;

		}

		public async Task<ItemPagedListDto> GetAllItems(ItemFilterDto input)
		{
			var query = _itemRepository.GetAll().Include(x => x.Entity_Category).Where(x => x.IsDeleted == false);
			if (!string.IsNullOrWhiteSpace(input.Filter))
			{
				query = query.Where(x => x.Entity_Category.Name.Contains(input.Filter) || x.Name.Contains(input.Filter) || x.ItemCode.Contains(input.Filter));
			}
			var totalCount = await query.CountAsync();
			var result = await query.OrderBy(input.OrderBy).Page(input.PageNumber, input.PageSize).ToListAsync();
			ItemPagedListDto dtResponse = new ItemPagedListDto
			{
				MaxResultCount = totalCount,
				ItemListDto = _mapper.Map<List<ItemListDto>>(result)
			};
			return dtResponse;
		}

		public async Task<CreateOrEditInputDto> GetItem(long id)
		{
			var query = _itemRepository.GetAll().Where(x=>x.ID == id).Include(x => x.Entity_Category).Where(x => x.IsDeleted == false);
			var totalCount = await query.CountAsync();
			var result = await query.FirstOrDefaultAsync();
			return _mapper.Map<CreateOrEditInputDto>(result);
		}

		public async Task<long> CreateOrEdit(CreateOrEditInputDto input)
		{
			long id = 0;
			if(input.Id == 0)
				id = await CreateItem(input);
			else
				id = await EditItem(input);
			return id;
		}

		protected async Task<long> CreateItem(CreateOrEditInputDto input)
		{
			var clonedInput = _mapper.Map<Entity_Item>(input);
			var id = await _itemRepository.Add(clonedInput);
			return id;
		}

		protected async Task<long> EditItem(CreateOrEditInputDto input)
		{
			if (input.Id > 0)
			{
				var item = await _itemRepository.GetAll().Where(x => x.IsDeleted == false && x.ID == input.Id).FirstOrDefaultAsync();
				if (item != null)
				{
					var clonedInput = _mapper.Map(input, item);
					await _itemRepository.Update(clonedInput);
				}
				else
					throw new Exception("No record found");
			}
			return input.Id;
		}

		public async Task DeleteItem(long id)
		{
			var item = await _itemRepository.GetAll().Where(x => x.IsDeleted == false && x.ID == id).FirstOrDefaultAsync();
			if (item != null)
			{
				item.IsDeleted = true;
				await _itemRepository.Update(item);
			}
			else
				throw new Exception("No record found");
		}
	}
}
