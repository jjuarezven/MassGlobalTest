using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MassGlobalTest.BLL.Tests
{
	[TestClass()]
	public class MasGlobalTests
	{
		[TestMethod()]
		public void ListsAreEqual()
		{
			var rules = new Rules();			
			var listFromRules = rules.GetEmployees().ToList();
			Assert.AreEqual(2, listFromRules.Count);
		}
	}
}
