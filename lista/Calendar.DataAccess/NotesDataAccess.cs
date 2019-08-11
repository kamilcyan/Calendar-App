using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.DataAccess
{
    public class NotesDataAccess
    {
        public void AddOrUpdate(Note note)
        {
            using (CalendarDbContext db = new CalendarDbContext())
            {
                var n = db.Notes.FirstOrDefault(x => x.Id.Equals(note.Id));
                if (n != null)
                {
                    n.DateOfPosting = note.DateOfPosting;
                    n.Body = note.Body;
                }
                else
                {
                    db.Notes.Add(note);
                }
                db.SaveChanges();
            }
        }

        public List<Note> GetNotesForDay(DateTime date)
        {
            using (CalendarDbContext context = new CalendarDbContext())
            {
                var tomorrow = date.AddDays(1);
                return context.Notes.Where(x => x.DateOfPosting >= date && x.DateOfPosting < tomorrow).OrderBy(x => x.DateOfPosting).ToList();
            }
        }

        public void Remove(Note note)
        {
            using (CalendarDbContext context = new CalendarDbContext())
            {
                var n = context.Notes.FirstOrDefault(x => x.Id.Equals(note.Id));
                if (n != null)
                {
                    context.Notes.Remove(n);
                    context.SaveChanges();
                }
            }
        }
    }
}
