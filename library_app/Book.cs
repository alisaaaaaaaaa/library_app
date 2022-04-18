using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
public enum eBookCond
    {
        available   = 1, 
        busy        = 2,
        comingsoon  = 3,
        unavailable = 4 
    }
namespace library_app
{
    class Book
    {
        public string Title;
        public string Author;
        public Image Cover;
        public string Description;
        public eBookCond BookCond;
        public PictureBox pBoxBookShelf;
        public RichTextBox rTBoxBookShelf;
        public Book(string Title, string Author, Image Cover, string Description, eBookCond BookCond)
        {
            this.Title = Title;
            this.Author = Author;
            this.Cover = Cover;
            this.Description = Description;
            this.BookCond = BookCond;
        }
    }
}