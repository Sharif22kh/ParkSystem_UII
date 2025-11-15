using System;
using Microsoft.Data.SqlClient;

namespace ParkSystem_UI
{
    public class Event
    {
        // These are "properties" that match the columns in our Events table.
        public int EventID { get; set; }
        public string EventDetails { get; set; }
        public DateTime EventDate { get; set; }

        // This makes it easy to display the event in a list.
        public override string ToString()
        {
            return $"[{EventDate.ToShortDateString()}] - {EventDetails}";
        }
    }
}