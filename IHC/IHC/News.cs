using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHC
{
    public class News
    {
        private string _text = null;
        private string _urlImage = null;
        private string _urlNews = null;

        public News(string t, string i, string l)
        {
            this._text = t;
            this._urlImage = i;
            this._urlNews = l;
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string URL
        {
            get { return _urlNews; }
            set { _urlNews = value; }
        }

        public string Image
        {
            get { return _urlImage; }
            set { _urlImage = value; }
        }
    }
}
