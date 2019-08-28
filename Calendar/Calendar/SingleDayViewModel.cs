using Calendar.DataAccess;
using System;
using System.Collections.Generic;

namespace Calendar
{
    public class SingleDayViewModel
    {

        private DateTime date;
        //public string BackgroundColor => isHoliday ? ( Active? "LightPink" : "IndianRed") : Active? "AliceBlue" : "SlateGray";
        public string BackgroundColor => isHoliday ? (Active ? "LightPink" : "LightPink") : Active ? "AliceBlue" : "AliceBlue";
        public string DateDayNumber=> date.ToString("dd");
        public string DateDay => date.ToString("dddd");
        private bool isHoliday => (int)date.DayOfWeek == 0;


        public List<Note> NotesForDay { get; }
        public bool Active { get; }

        public List<Note> Notes => NotesForDay;

        public SingleDayViewModel(List<Note> notesForDay, DateTime date, bool active)
        {
            NotesForDay = notesForDay;
            this.date = date;
            Active = active;
        }

    }
}
