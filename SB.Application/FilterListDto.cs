using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Application
{
	public class FilterListDto
	{
		public int PageSize { get; set; }
		public int PageNumber { get; set; }
		public string OrderBy { get; set; }
		public string Filter { get; set; }
	}
}
