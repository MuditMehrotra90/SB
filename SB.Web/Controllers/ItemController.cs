using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SB.Application.Category;
using SB.Application.Constant;
using SB.Application.Item.Dtos;
using SB.Web.Models;
using SB.Web.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SB.Web.Controllers
{
	public class ItemController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly IConfiguration _configuration;

		public ItemController(IConfiguration configuration, ICategoryService categoryService)
		{
            _configuration = configuration;
			_categoryService = categoryService;
		}
		public IActionResult Index()
		{
			return View();
        }
		[HttpPost]
		public async Task<IActionResult> LoadItems()
		{
			string search = Request.Form["search[value]"];
			var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
			int start = Convert.ToInt32(Request.Form["start"]);
			int length = Convert.ToInt32(Request.Form["length"]);
			string sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"] + "][name]"];
			string sortDirection = Request.Form["order[0][dir]"];
			ItemListViewModel itemPagedList = new ItemListViewModel();
			string orderBy = sortColumn + " " + sortDirection;
			int pageNumber = start / length + 1;
			string path = _configuration["AppSettings:ServiceAPIURL"] + "Item/getItems?PageSize=" + length + "&PageNumber=" + pageNumber  + "&OrderBy=" + orderBy + "&filter=" +search;

			HttpResponseMessage response = ApiPathConstant.WebApiClient.GetAsync(path).Result;
			var result = JsonConvert.DeserializeObject<ApiResponse>(response.Content.ReadAsStringAsync().Result);

			if (result.Result != null)
			{
				dynamic response1 = JsonConvert.DeserializeObject(result.Result.ToString());
				itemPagedList = response1.ToObject<ItemListViewModel>();
			}

			return Json(new { draw = draw, recordsFiltered = itemPagedList.MaxResultCount, recordsTotal = itemPagedList.MaxResultCount, data = itemPagedList.ItemListDto });
		}

		public async Task<IActionResult> Create(long? id)
		{
			CreateOrEditInputDto createOrEditInputDto = new CreateOrEditInputDto();
			if(id.HasValue && id.Value > 0)
			{
				string path = _configuration["AppSettings:ServiceAPIURL"] + "Item/getItem?id=" + id.ToString();
				HttpResponseMessage response = ApiPathConstant.WebApiClient.GetAsync(path).Result;
				var result = JsonConvert.DeserializeObject<ApiResponse>(response.Content.ReadAsStringAsync().Result);
				if (result.Result != null)
				{
					dynamic response1 = JsonConvert.DeserializeObject(result.Result.ToString());
					createOrEditInputDto = response1.ToObject<CreateOrEditInputDto>();
				}
			}
			CreateOrEditViewModel model = new CreateOrEditViewModel() {
				Categories = await _categoryService.GetCategoriesForDropDown(),
				CreateOrEditInputDto = createOrEditInputDto
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateOrEditViewModel input)
		{
			string path = _configuration["AppSettings:ServiceAPIURL"] + "Item/" + (input.CreateOrEditInputDto?.Id > 0 ? "editItem" : "addItem");
			HttpResponseMessage response = ApiPathConstant.WebApiClient.PostAsJsonAsync(path, input.CreateOrEditInputDto).Result;
			var result = JsonConvert.DeserializeObject<ApiResponse>(response.Content.ReadAsStringAsync().Result);
			TempData["StatusCode"] = result.StatusCode;
			TempData["Message"] = result.Message;
			return RedirectToAction("Index", "Item");
		}

		public async Task<IActionResult> Delete(long id)
		{
			string path = _configuration["AppSettings:ServiceAPIURL"] + "Item/deleteItem?id="+id.ToString();
			HttpResponseMessage response = ApiPathConstant.WebApiClient.DeleteAsync(path).Result;
			var result = JsonConvert.DeserializeObject<ApiResponse>(response.Content.ReadAsStringAsync().Result);
			return Json(new { result });
		}

		public async Task<IActionResult> Edit(long id)
		{
			return RedirectToAction("Create", new { id = id });
		}
	}
}
