using MassGlobalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
			IEnumerable<Employee> employeesList = null;
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:7557/api/");


				Task<HttpResponseMessage> responseTask = null;
				if (!employeeId.HasValue)
				{
					responseTask = client.GetAsync("Employee");
				}
				else
				{
					responseTask = client.GetAsync("Employee/" + "?employeeId=" + employeeId.ToString());
				}
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<IList<Employee>>();
					readTask.Wait();

					employeesList = readTask.Result;
				}
				else
					employeesList = Enumerable.Empty<Employee>();

				ModelState.AddModelError(string.Empty, "This Employee is not registered, please try with a valid Employee Id");
			}
			return View(employeesList);
		}

	}
}

