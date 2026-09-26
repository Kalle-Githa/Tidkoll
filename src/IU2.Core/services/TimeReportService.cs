using IU2.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IU2.Core.services
{
    public class TimeReportService
    {
        //Static list of customers
        public List<Customer> Customers { get; } = new()
        {
            new Customer { Id = 1, Name = "Acme AB" },
            new Customer { Id = 2, Name = "Globex Solutions" },
            new Customer { Id = 3, Name = "Initech" },
            new Customer { Id = 4, Name = "Umbrella Corp" },
        };

        private readonly List<TimeReport> _reports = new();
        private int _nextId = 1;

        private IReadOnlyList<TimeReport> GetAllReports() => _reports;

        public IEnumerable<TimeReport> GetReportsForDate(DateTime date) =>
            _reports.Where(r => r.Date.Date == date.Date).OrderBy(r => r.Id);

        public decimal GetTotalHoursForDate(DateTime date) =>
            GetReportsForDate(date).Sum(r => r.Hours);


        /// <summary>
        /// Saves a time report. Validates that the hours are between 0 and 24
        /// and that the total hours for the day do not exceed 24.
        /// </summary>
        public (bool Success, string? ErrorMessage) AddReport(DateTime date, int customerId, decimal hours, string? description)
        {
            if (hours <= 0)
            {
                return (false, "Timmar måste vara större än 0.");
            }

            var existingTotal = GetTotalHoursForDate(date);
            if (existingTotal + hours > 24)
            {
                return (false, $"Timmar för dagen får max vara 24 (redan rapporterat: {existingTotal:0.0} h).");
            }

            _reports.Add(new TimeReport
            {
                Id = _nextId++,
                Date = date.Date,
                CustomerId = customerId,
                Hours = hours,
                Description = description
            });

            return (true, null);
        }

        public void DeleteReport(int id)
        {
            var report = _reports.FirstOrDefault(r => r.Id == id);
            if (report != null)
            {
                _reports.Remove(report);
            }
        }
    }
}
