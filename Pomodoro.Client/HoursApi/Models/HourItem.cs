using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoursApi.Models
{
    public class HourItem
    {
        public int Id { get; set; }
        public string PomodoroGoal { get; set; }
        public bool PomodoroComplete { get; set; }
        public string Description { get; set; }
        public DateTime TimeOfDay { get; set; }
    }
}
