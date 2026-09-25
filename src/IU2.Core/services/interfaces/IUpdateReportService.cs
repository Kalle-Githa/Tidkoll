using IU2.Core.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IU2.Core.services.interfaces
{
    public interface IUpdateReportService
    {
        List<TimeReport> GetReportsForCurrentMonth();
        bool UpdateHours(int id, decimal newHours);
    }
}
