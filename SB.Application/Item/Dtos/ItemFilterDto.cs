using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Application.Item.Dtos
{
	public class ItemFilterDto : FilterListDto
	{
		public ItemFilterDto()
		{
			if(string.IsNullOrEmpty(OrderBy))
				OrderBy = "ID Desc";
		}
	}
}
