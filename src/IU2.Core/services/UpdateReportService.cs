using IU2.Core.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IU2.Core.services
{
    internal class UpdateReportService
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

        public void UpdateHours(int id, decimal newHours)
        {
            var report = _reports.FirstOrDefault(r => r.Id == id);
            if (report != null)
            {
                report.Timmar = newHours;
            }
        }
    }
}
