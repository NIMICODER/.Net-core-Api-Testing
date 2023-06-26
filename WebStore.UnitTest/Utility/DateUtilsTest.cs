using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.BLL.Utility;

namespace WebStore.UnitTest.Utility
{
	public class DateUtilsTest
	{
		[Fact]
		public void GetCurrentDate_ReturnsCorrectDate()
		{
			var currentDate = DateUtility.GetCurrentDate();
			Assert.True(currentDate.Year >= 2022);
		}
	}
}
