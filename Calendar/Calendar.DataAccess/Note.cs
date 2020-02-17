using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.DataAccess
{
    public class Note
    {
        public int Id { get; set; }
        public DateTime DateOfPosting { get; set; }
        public string Hour => DateOfPosting.ToString("HH:mm");
        public string Body { get; set; }
    }
}

