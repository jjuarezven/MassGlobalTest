using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MassGlobalTest.ViewModels
{
	public class EmployeeViewModel
	{
		public string Name { get; set; }
		[Display(Name ="Contract type")]
		public string ContractTypeName { get; set; }
		[Display(Name = "Role Id")]
		public int RoleId { get; set; }
		[Display(Name = "Role Name")]
		public string RoleName { get; set; }
		[Display(Name = "Role Description")]
		public string RoleDescription { get; set; }
		[Display(Name = "Hour Salary")]
		[DataType(DataType.Currency)]
		public decimal HourlySalary { get; set; }
		[DataType(DataType.Currency)]
		[Display(Name = "Monthly Salary")]
		public decimal MonthlySalary { get; set; }
		[Display(Name = "Annual Salary")]
		[DataType(DataType.Currency)]
		public decimal AnnualSalary { get; set; }
	}
}