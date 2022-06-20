using Microsoft.AspNetCore.Mvc.Rendering;
using SB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Application.Category
{
	public interface ICategoryService
	{
		Task<IEnumerable<SelectListItem>> GetCategoriesForDropDown();
	}
}
