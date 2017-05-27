using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHC
{
    class Event : IComparable
    {
        private DateTime _time;
        private string _desc;
        public Event(DateTime t, string desc)
        {
            this._time = t;
            this._desc = desc; 
        }

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public String Month
        {
            get { return _time.ToString("MMM", CultureInfo.InvariantCulture); }
        }

        public String Day
        {
            get { return _time.Day.ToString(); }
        }

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public int CompareTo(object obj)
        {
            Event e = obj as Event;
            if (e == null)
            {
                throw new ArgumentException("Object is not Preson");
            }
            return this._time.CompareTo(e._time);
        }

        public override string ToString()
        {
            return this._desc;
        }
    }
}
