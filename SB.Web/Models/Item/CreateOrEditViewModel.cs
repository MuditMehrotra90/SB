using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SB.Application.Category;
using SB.Application.Item.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB.Web.Models.Item
{
	public class CreateOrEditViewModel
	{
		public CreateOrEditInputDto CreateOrEditInputDto { get; set; }
		public IEnumerable<SelectListItem> Categories { get; set; }
	}
}
