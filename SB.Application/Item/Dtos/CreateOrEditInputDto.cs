using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Application.Item.Dtos
{
	public class CreateOrEditInputDto
	{
		public long Id { get; set; }
		[Required]
		[DisplayName("Category")]
		public int Category_ID_FK { get; set; }
		[DisplayName("Item Name")]
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		[Required]
		public decimal? Price { get; set; }
		[DisplayName("Item Code")]
		[Required]
		public string ItemCode { get; set; }
	}
}
