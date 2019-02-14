using MassGlobalTest.Models;
using MassGlobalTest.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace MassGlobalTest.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult GetEmployees(int? employeeId)
		{
			var employeesList = GetEmployeesFromApi(employeeId);

			var viewModelEmployeesList = new List<EmployeeViewModel>();
			foreach (var item in employeesList)
			{
				viewModelEmployeesList.Add(new EmployeeViewModel
				{
					AnnualSalary = item.AnnualSalary,
					ContractTypeName = item.ContractTypeName,
					HourlySalary = item.HourlySalary,
					MonthlySalary = item.MonthlySalary,
					Name = item.Name,
					RoleDescription = item.RoleDescription,
					RoleId = item.RoleId,
					RoleName = item.RoleName
				});
			}
			return View(viewModelEmployeesList);
		}

		private IEnumerable<Employee> GetEmployeesFromApi(int? employeeId)
		{
			IEnumerable<Employee> employeesList = null;
			var client = new HttpClient();
			var uri = @"http://localhost:7557/api/Employee?employeeId=";
			uri = employeeId.HasValue ? uri + employeeId.ToString() : uri = uri + "0";
			var result = client.GetAsync(uri).Result;
			if (result.IsSuccessStatusCode)
			{
				employeesList = result.Content.ReadAsAsync<List<Employee>>().Result;
			}
			else
			{
				employeesList = Enumerable.Empty<Employee>();
				ModelState.AddModelError(string.Empty, "This Employee is not registered, please try with a valid Employee Id");
			}
			return employeesList;
		}
	}
}

