using MassGlobalTest.BLL;
using System.Linq;
using System.Web.Http;

namespace MassGlobalTest.Controllers
{
	public class EmployeeController : ApiController
	{
		// GET api/<controller>
		public IHttpActionResult Get(int? employeeId = 0)
		{
			var rules = new Rules();
			var employees = rules.GetEmployees(employeeId.Value);
			if (!employees.Any())
			{
				return NotFound();

			}
			return Ok(employees);
		}
	}
}