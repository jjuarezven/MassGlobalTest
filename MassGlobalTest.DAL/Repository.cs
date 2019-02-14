using MassGlobalTest.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace MassGlobalTest.DAL
{
	public static class Repository
    {
		public static List<Employee> GetEmployees()
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
