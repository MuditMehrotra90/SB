using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SB.Application.Category
{
	public class CategoryService : ICategoryService
	{
		private readonly IRepository<Entity_Category> _categoryRepository;

		public CategoryService(IRepository<Entity_Category> categoryRepository)
		{
			_categoryRepository = categoryRepository;

		}

		public async Task<IEnumerable<SelectListItem>> GetCategoriesForDropDown()
		{
			var query = _categoryRepository.GetAll().Where(x=>x.IsDeleted == false);
			return await query.Select(x=> new SelectListItem {
				Text = x.Name,
				Value = x.Id.ToString()
			}).ToListAsync();
		}
	}
}
