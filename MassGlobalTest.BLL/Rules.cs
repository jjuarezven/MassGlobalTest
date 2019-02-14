using MassGlobalTest.DAL;
using MassGlobalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MassGlobalTest.BLL
{
	public class Rules
    {
		/// <summary>
		/// This method calls the repository GetEmployees method, with an optional employeeId paramter to fetch a single employee by Id, if employeeId = 0, returns all employees
		/// </summary>
		/// <param name="employeeId">optionail int id</param>
		/// <returns>IEnumerable<Employee></returns>
		public IEnumerable<Employee> GetEmployees(int employeeId = 0)
		{
			var list = Repository.GetEmployees(employeeId);
			if (list.Any())
			{				
				foreach (var employee in list)
				{
					ProcessEmployee(employee);
				}
			}
			return list;
		}

		/// <summary>
		/// Here we use the factory method pattern to calculate the employee's AnnualSalary 
		/// </summary>
		/// <param name="employee">Employee</param>
		private static void ProcessEmployee(Employee employee)
		{
			IEmployeeFactory employeeFactory = null;
			var salary = 0D;
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
}
