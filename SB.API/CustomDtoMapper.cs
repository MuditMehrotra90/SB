using AutoMapper;
using SB.Application.Item.Dtos;
using SB.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.API
{
	public class CustomDtoMapper : Profile
	{
		public CustomDtoMapper()
		{
			CreateMap<CreateOrEditInputDto, Entity_Item>().ReverseMap();
			CreateMap<ItemListDto, Entity_Item>().ReverseMap();
		}
	}
}
