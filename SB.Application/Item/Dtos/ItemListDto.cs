using SB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Application.Item.Dtos
{
	public class ItemListDto
	{
		public long ID { get; set; }
		public Entity_Category Entity_Category { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string ItemCode { get; set; }
	}
}
