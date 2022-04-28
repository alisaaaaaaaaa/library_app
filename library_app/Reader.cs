using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_app
{
    class Reader
    {
        public string ID_reader;
        public Book book;
        public int Days; 
        public bool is_ok = true;// можно ли давать книгу
        public Reader(string ID_reader, Book book, int Days)
        {
            this.ID_reader = ID_reader;
            this.book = book;
            this.Days = Days;
        }
    }
}
