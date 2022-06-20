using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SB.Application;
using SB.Application.Item;
using SB.Application.Item.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemController : ControllerBase
	{
		private readonly IItemService _itemService;
		public ItemController(IItemService itemService)
		{
			_itemService = itemService;
		}

        /// <summary>
        /// Retrieves all items from database
        /// </summary>
        // GET api/values
        [Route("getItems")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ItemFilterDto input)
		{
            try
            {
                var items = await _itemService.GetAllItems(input);
                if(items.ItemListDto.Count > 0)
                    return Ok(new ApiResponse(StatusCodes.Status200OK, true, items, "Items returned successfully"));
                return Ok(new ApiResponse(StatusCodes.Status204NoContent, true, null, "No records found"));
            }

            catch (Exception ex)
            {
                return Ok(new ApiResponse(StatusCodes.Status500InternalServerError, false, null, "Some issue in processing", ex.Message));
            }
		}

        /// <summary>
        /// Retrieves a specific item by id from database
        /// </summary>
        // GET api/values
        [Route("getItem")]
        [HttpGet]
        public async Task<IActionResult> GetItem(long id)
        {
            try
            {
                var items = await _itemService.GetItem(id);
                if (items != null)
                    return Ok(new ApiResponse(StatusCodes.Status200OK, true, items, "Item returned successfully"));
                return Ok(new ApiResponse(StatusCodes.Status204NoContent, true, null, "No records found"));
            }

            catch (Exception ex)
            {
                return Ok(new ApiResponse(StatusCodes.Status500InternalServerError, false, null, "Some issue in processing", ex.Message));
            }
        }

        /// <summary>
        /// Add new item in database
        /// </summary>
        //POST: api/AddItem
        [Route("addItem")]
        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] CreateOrEditInputDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _itemService.CreateOrEdit(input);
                return Ok(new ApiResponse(StatusCodes.Status200OK, true, null, "Item added successfully"));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(StatusCodes.Status500InternalServerError, false, null, "Some issue in processing", ex.Message));
            }
        }


        //Post: api/EditItem
        /// <summary>
        /// Update item by id in database
        /// </summary>
        [Route("editItem")]
        [HttpPost]
        public async Task<IActionResult> EditItem([FromBody] CreateOrEditInputDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _itemService.CreateOrEdit(input);
                return Ok(new ApiResponse(StatusCodes.Status200OK, true, null, "Item updated successfully"));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(StatusCodes.Status500InternalServerError, false, null, "Some issue in processing", ex.Message));
            }
        }


        //Delete: api/DeleteItem
        /// <summary>
        /// Delete an item from database
        /// </summary>
        [Route("deleteItem")]
        [HttpDelete]
        public async Task<IActionResult> DeleteItem(long id)
        {
            try
            {
                await _itemService.DeleteItem(id);
                return Ok(new ApiResponse(StatusCodes.Status200OK, true, null, "Item deleted Successfully"));
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(StatusCodes.Status500InternalServerError, false, null, "Some issue in processing", ex.Message));
            }
        }

    }
}
