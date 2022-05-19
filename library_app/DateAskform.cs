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
    public partial class DateAskform : Form
    {
        public DateAskform()
        {
            InitializeComponent();
        }
        private void OkClick(Book book)
        {
            LibraryApp main = this.Owner as LibraryApp;
            book.BookCond = eBookCond.available;
            foreach (ListViewItem i in main.busybooks.Items)
            {
                if (i.Text.Equals(book.Title))
                {
                    main.busybooks.Items.Remove(i);
                }
            }
        }
        private Book GetBookByBusyBooks(ListViewItem item)//вспомогательный метод для того, чтобы связать книгу в busybooks с экземпляром книги
        {
            LibraryApp main = this.Owner as LibraryApp;
            foreach (Book Book in main.ListOfBooks)
            {
                if (item.Selected)
                {
                    return Book;
                }
            }
            return null;
        }
        private void okbutton_Click(object sender, EventArgs e)
        {
            LibraryApp main = this.Owner as LibraryApp;
            foreach (ListViewItem i in main.busybooks.Items)
            {
                if (datetb.Text.Equals(""))
                {
                    MessageBox.Show("Введите данные!");
                }
                else if (Convert.ToInt32(datetb.Text) >= 7 && Convert.ToInt32(datetb.Text) <= 60)
                {
                    if (GetBookByBusyBooks(i) != null)
                    {
                        foreach (Book book in main.ListOfBooks)
                        {
                            if (i.Text.Equals(book.Title))
                            {
                                OkClick(book);
                                book.TakeDays = Convert.ToInt32(datetb.Text);
                            }
                        }
                    }
                }
                this.Close();
            }
        }
    }
}
