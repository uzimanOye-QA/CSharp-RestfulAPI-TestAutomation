using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulAPITestAutomationFramework.Model
{
    public class BookingModel
    {
       
        public string? firstname { get; set; }
        public string? lastname { get; set; }
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public string? additionalneeds { get; set; }
        public BookingDates? bookingdates { get; set; }  

        public class BookingDates
        {
            public string? checkin { get; set; }
            public string? checkout { get; set; }
        }
    }
}
