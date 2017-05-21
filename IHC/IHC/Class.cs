using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHC
{
    class Class
    {
        private string _name;
        private string _start;
        private string _end;
        private string _place; 

        public Class( string s, string e, string n, string p)
        {
            this._name = n;
            this._start = s;
            this._end = e;
            this._place = p;
        }

        public string Place
        {
            get { return _place; }
            set { _place = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Start
        {
            get { return _start; }
            set { _end = value; }
        }

        public string End
        {
            get { return _end; }
            set { _end = value; }
        }

    }

}
