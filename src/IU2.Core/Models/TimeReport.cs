using System;
using System.Collections.Generic;
using System.Text;

namespace IU2.Core.Models
{
    public class TimeReport
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }
        public string? Description { get; set; }
    }
}
