using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_app
{
    public partial class LibraryApp : Form
    {
        List<Book> ListOfBooks = new List<Book>();
        public LibraryApp()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            //пример:
            Image Img = Image.FromFile("WandP.jpg");
            Book Book1 = new Book("Война и мир", "Тослой Л.Н.", Img, "Интересная книга", eBookCond.available);
            ListOfBooks.Add(Book1);
            Bookshelf(Book1, cover1, title1);
            //считать из бд названия и обложки книг и записать в список
            coverClick(cover1);
            FilterClick();
        }
        private void Bookshelf(Book book, PictureBox pBoxBookShelf, RichTextBox rTBoxBookShelf)//метод добавления книги в книжную полку
        {
            pBoxBookShelf.Image = book.Cover;
            rTBoxBookShelf.Text = book.Title + book.Author;
            book.pBoxBookShelf = pBoxBookShelf;
            book.rTBoxBookShelf = rTBoxBookShelf;
        }
        private Book GetBookByBookShelf(PictureBox pBoxBookShelf)//вспомогательный метод для того, чтобы связать обложку в книжной полке с экземпляром книги
        {
            foreach (Book Book in ListOfBooks)
            {
                if (Book.pBoxBookShelf == pBoxBookShelf)
                    return Book;
            }
                return null;
        }
        private void applybutton_Click(object sender, EventArgs e)
        {

            if (numbertextbox.Text.Equals("") || timetextbox.Text.Equals(""))
            {
                MessageBox.Show("Введите все данные!");
            }
            else if (Convert.ToInt32(timetextbox.Text) >= 7 && Convert.ToInt32(timetextbox.Text) <= 60)
            {
                MessageBox.Show("Заявка уcпешно принята!");

            }
            else if (Convert.ToInt32(timetextbox.Text) < 7 || Convert.ToInt32(timetextbox.Text) > 60)
            {
                MessageBox.Show("Введеный срок не соотвествует указанному диапазону!");
            }
        }
        public void coverClick(PictureBox cover)//метод для того, чтобы при нажатии слева появлялась брошюра
        {
            bigcover.Image = cover.Image;
            description.Text = GetBookByBookShelf(cover).rTBoxBookShelf.Text;
            availablebutton.Checked = GetBookByBookShelf(cover).BookCond.Equals("available");
            busybutton.Checked = GetBookByBookShelf(cover).BookCond.Equals("busy");
            comingsoonbutton.Checked = GetBookByBookShelf(cover).BookCond.Equals("comingsoon");
            unavailablebutton.Checked = GetBookByBookShelf(cover).BookCond.Equals("unavailable");
        }
        private void cover1_Click(object sender, EventArgs e)
        {
            coverClick(cover1);
        }
        private void cover2_Click(object sender, EventArgs e)
        {
            coverClick(cover2);
        }

        private void cover3_Click(object sender, EventArgs e)
        {
            coverClick(cover3);
        }

        private void cover4_Click(object sender, EventArgs e)
        {
            coverClick(cover4);
        }

        private void cover5_Click(object sender, EventArgs e)
        {
            coverClick(cover5);
        }

        private void cover6_Click(object sender, EventArgs e)
        {
            coverClick(cover6);
        }

        private void cover7_Click(object sender, EventArgs e)
        {
            coverClick(cover7);
        }

        private void cover8_Click(object sender, EventArgs e)
        {
            coverClick(cover8);
        }

        private void cover9_Click(object sender, EventArgs e)
        {
            coverClick(cover9);
        }
        public void FilterClick()//метод для осуществления сортировок принажатии на меню
        {
            if(filter.Items.Contains("алфавиту по авторам"))
            {
                //сортировка по алфавиту по авторам
            }
            else if (filter.Items.Contains("алфавиту по названиям"))
            {
                //сортировка по алфавиту по названиям
            }
            else if (filter.Items.Contains("только свободные книги"))
            {
                //показать только свободные
            }
        }
    }
}
