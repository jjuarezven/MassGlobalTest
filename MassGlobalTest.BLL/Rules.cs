using MassGlobalTest.DAL;
using MassGlobalTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace MassGlobalTest.BLL
{
	public class Rules
    {
		public List<Employee> GetEmployees()
		{
			var list = Repository.GetEmployees();
			if (list.Any())
			{
				IEmployeeFactory employeeFactory = null;
				var salary = 0D;
				foreach (var employee in list)
				{
					switch (employee.ContractTypeName)
					{
						case "HourlySalaryEmployee":
							employeeFactory = new HourlyEmployeeFactory();
							salary = employee.HourlySalary;
							break;
						case "MonthlySalaryEmployee":
							employeeFactory = new MonthlyEmployeeFactory();
							salary = employee.MonthlySalary;
							break;
						default:
							break;
					}
					if (employeeFactory != null)
					{
						employee.AnnualSalary = employeeFactory.GetEmployee().CalculateAnnualSalary(salary); 
					}
				}
			}
			return list;
		}
    }
}
