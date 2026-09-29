using IU2.Core.helpers;
using IU2.Core.Models;
using IU2.Core.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IU2.Core.services
{
    public class UpdateReportService : IUpdateReportService
    {
        private readonly TimeReportService _timeReportService;

        public UpdateReportService(TimeReportService timeReportService)
        {
            _timeReportService = timeReportService;
        }

        //    private List<TimeReports> _reports = new()
        //{
        //    new TimeReports { Id = 1, Kund = "Acme AB", Datum = new DateOnly(2026, 9, 8), Timmar = 4.0m, Beskrivning = "Utveckling av ny funktion" },
        //    new TimeReports { Id = 2, Kund = "Globex Solutions", Datum = new DateOnly(2026, 9, 8), Timmar = 2.5m, Beskrivning = "Bugfixar och testning" },
        //    new TimeReports { Id = 3, Kund = "Initech", Datum = new DateOnly(2026, 9, 8), Timmar = 1.0m, Beskrivning = "Möte med kund" }
        //};

        public List<TimeReport> GetReportsForCurrentMonth()
        {
            var today = DateTime.Now;
            return _timeReportService.GetReportsForMonth(today).ToList();
        }

        public bool UpdateHours(int id, decimal newHours)
        {
            if (!TimeReportValidator.IsValidHours(newHours)) return false;

            return _timeReportService.UpdateHours(id, newHours);
        }
    }
}
