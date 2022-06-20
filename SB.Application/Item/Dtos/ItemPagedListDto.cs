using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Application.Item.Dtos
{
	public class ItemPagedListDto
	{
		public List<ItemListDto> ItemListDto { get; set; }
		public int MaxResultCount { get; set; }
	}
}
