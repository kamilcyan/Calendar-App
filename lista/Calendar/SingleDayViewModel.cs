using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Calendar.Classes;

namespace Calendar
{
    public class SingleDayViewModel
    {

        private DateTime date;
        public string BackgroundColor => isHoliday ? "LightPink" : "AliceBlue";
        public string DateDayNumber=> date.ToString("dd");
        public string DateDay => date.ToString("dddd");
        private bool isHoliday => (int)date.DayOfWeek == 0;


        public List<Note> NotesForDay { get; }

        public string Notes => string.Join("\r\n", NotesForDay.Select(x => x.Body));

        public SingleDayViewModel(List<Note> notesForDay, DateTime date)
        {
            NotesForDay = notesForDay;
            this.date = date;
        }
    }
}
