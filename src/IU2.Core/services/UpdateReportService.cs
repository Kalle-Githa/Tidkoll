using IU2.Core.helpers;
using IU2.Core.models;
using IU2.Core.services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IU2.Core.services
{
    public class UpdateReportService : IUpdateReportService
    {

        private List<TimeReport> _reports = new()
    {
        new TimeReport { Id = 1, Kund = "Acme AB", Datum = new DateOnly(2026, 9, 8), Timmar = 4.0m, Beskrivning = "Utveckling av ny funktion" },
        new TimeReport { Id = 2, Kund = "Globex Solutions", Datum = new DateOnly(2026, 9, 8), Timmar = 2.5m, Beskrivning = "Bugfixar och testning" },
        new TimeReport { Id = 3, Kund = "Initech", Datum = new DateOnly(2026, 9, 8), Timmar = 1.0m, Beskrivning = "Möte med kund" }
    };

        public List<TimeReport> GetReportsForCurrentMonth()
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            return _reports.Where(r => r.Datum.Year == today.Year && r.Datum.Month == today.Month).ToList();
        }

        public bool UpdateHours(int id, decimal newHours) // Kommer behövas till "Skapa TimeReport", kanske räcker det med en metod. (DRY)
        {
            var report = _reports.FirstOrDefault(r => r.Id == id);
            if (report is null) return false;

            if (!TimeReportValidator.IsValidHours(newHours)) return false;

            report.Timmar = newHours;
            return true;
        }
    }
}
