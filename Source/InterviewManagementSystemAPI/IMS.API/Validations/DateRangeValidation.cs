using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using IMS.Models;

namespace IMS.Validations
{
    public static class DateRangeValidaation
    {
        public static void IsDateValid(DateRange dateRange)
        {
            if(String.IsNullOrEmpty(dateRange.From) && String.IsNullOrEmpty(dateRange.To))
            {
                dateRange.FromDate=System.DateTime.Now.AddMonths(-1);
                dateRange.ToDate=System.DateTime.Now;    
            }
            else if(String.IsNullOrEmpty(dateRange.From))
            {
                dateRange.FromDate=System.DateTime.Now.AddMonths(-1);
                dateRange.ToDate=Convert.ToDateTime(dateRange.To);
            }
            else if(String.IsNullOrEmpty(dateRange.To))
            {
                dateRange.FromDate=Convert.ToDateTime(dateRange.From);
                dateRange.ToDate=System.DateTime.Now;
            }
            else
            {
                dateRange.FromDate=Convert.ToDateTime(dateRange.From);
                dateRange.ToDate=Convert.ToDateTime(dateRange.To);
            }
            
        }
    }
}



//             if(!(String.IsNullOrEmpty(dateRange.From) && String.IsNullOrEmpty(dateRange.To)))
//             {
//                 dateRange.FromDate=Convert.ToDateTime(dateRange.From);
//                 dateRange.ToDate=Convert.ToDateTime(dateRange.To);
//             }
//             else if(String.IsNullOrEmpty(dateRange.From)&& !String.IsNullOrEmpty(dateRange.To))
//             {
//                 dateRange.FromDate=System.DateTime.Now.AddMonths(-1);
//                 dateRange.ToDate=Convert.ToDateTime(dateRange.To);
//             }
//             else if(String.IsNullOrEmpty(dateRange.To) && !String.IsNullOrEmpty(dateRange.From))
//             {
//                 dateRange.FromDate=Convert.ToDateTime(dateRange.From);
//                 dateRange.ToDate=System.DateTime.Now;
//             }
//             else
//             {
//                 dateRange.FromDate=System.DateTime.Now.AddMonths(-1);
//                 dateRange.ToDate=System.DateTime.Now;
//             }
