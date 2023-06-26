using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.BLL.Utility
{
	public class DateUtility
	{
		public static DateTime GetCurrentDate()
		{
			return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.Local);
		}
	}
}
