using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
public enum eBookCond
 {
     available = 1, 
     busy = 2,
     comingsoon = 3,
     unavailable = 4 
 }
namespace library_app
{
   public class Book
    {
        public int ID;
        public string Title;
        public string Author;
        public Image Cover;
        public string Description;
        public string Genre;
        public eBookCond BookCond;
        public PictureBox pBoxBookShelf;
        public RichTextBox rTBoxBookShelf;
        public int TakeNum;//сколько раз взяли кингу
        public int TakeDays;//сколько дней книга была у читателя
        public Book(int ID,string Title, string Author, Image Cover, string Description, string Genre, eBookCond BookCond,int TakeNum, int TakeDays)
        {
            this.ID = ID;
            this.Title = Title;
            this.Author = Author;
            this.Cover = Cover;
            this.Description = Description;
            this.Genre = Genre;
            this.BookCond = BookCond;
            this.TakeNum = TakeNum;
            this.TakeDays = TakeDays;
        }
    }
}