using MassGlobalTest.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MassGlobalTest.DAL
{
    public class Repository
    {
		public List<Employee> GetEmployees()
		{
			var list = new List<Employee>();
			HttpClient client = new HttpClient();
			var result = client.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees").Result;
			if (result.IsSuccessStatusCode)
			{
				list = result.Content.ReadAsAsync<List<Employee>>().Result;
			}
			return list;
		}
	}
}
