using System;
using System.Collections.Generic;
using System.Text;

namespace IU2.Core.helpers
{
    internal class TimeReportValidator
    {
        private const decimal MaxHoursPerDay = 24m;
        private const decimal MinHours = 0m;

        public static bool IsValidHours(decimal hours)
        {
            return hours > MinHours && hours <= MaxHoursPerDay;
        }
    }
}
