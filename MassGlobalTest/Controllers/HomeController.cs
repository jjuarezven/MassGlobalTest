using MassGlobalTest.BLL;
using MassGlobalTest.Models;
using System.Collections.Generic;
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
			if (employeeId.HasValue)
			{
				var rules = new Rules();
				var employees = rules.GetEmployees(employeeId.Value);
				return View(employees);
			}
			return View();
		}
	}
}
