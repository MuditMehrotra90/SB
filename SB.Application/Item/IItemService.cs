using SB.Application.Item.Dtos;
using SB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Application.Item
{
	public interface IItemService
	{
		Task<ItemPagedListDto> GetAllItems(ItemFilterDto input);
		Task<CreateOrEditInputDto> GetItem(long id);
		Task<long> CreateOrEdit(CreateOrEditInputDto input);
		Task DeleteItem(long id);
	}
}
