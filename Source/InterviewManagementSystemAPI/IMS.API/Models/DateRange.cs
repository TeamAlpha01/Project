using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Models
{
    [NotMapped]
    public class DateRange
    {
        public string? From { get; set; }
        public string? To { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}