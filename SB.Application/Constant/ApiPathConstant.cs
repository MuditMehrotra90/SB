using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SB.Application.Constant
{
	public static class ApiPathConstant
	{
		public static HttpClient WebApiClient = new HttpClient();
        static ApiPathConstant()
        {
            WebApiClient.Timeout = TimeSpan.FromMinutes(30);
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
