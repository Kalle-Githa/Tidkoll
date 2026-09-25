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
            new Customer { Id = 1, Name = "Volvo AB" },
            new Customer { Id = 2, Name = "Ericsson" },
            new Customer { Id = 3, Name = "IKEA" },
            new Customer { Id = 4, Name = "H&M" },
        };

        private readonly List<TimeReport> _reports = new();

        private IReadOnlyList<TimeReport> GetAllReports() => _reports;

        public IEnumerable<TimeReport> GetReportsForDate(DateTime date) =>
            _reports.Where(r => r.Date.Date == date.Date);


        /// <summary>
        /// Saves a time report. Validates that the hours are between 0 and 24,
        /// and that there is no existing report for the same date and customer.
        /// </summary>
        public (bool Success, string? ErrorMessage) AddReport(DateTime date, int customerId, decimal hours)
        {
            if (hours <= 0)
            {
                return (false, "Timmar måste vara större än 0.");
            }

            if (hours > 24)
            {
                return (false, "Timmar måste vara mellan 0 och 24.");
            }

            var existing = _reports.FirstOrDefault(r => r.Date.Date == date.Date && r.CustomerId == customerId);
            if (existing != null)
            {
                return (false, "En rapport för denna datum och kund finns redan.");
            }
            else
            {
                _reports.Add(new TimeReport
                {
                    Date = date,
                    CustomerId = customerId,
                    Hours = hours
                });
            }

            return (true, null);
        }
    }
}
