using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace library_app
{
    public partial class LibraryApp : Form
    {
        public List<Book> ListOfBooks = new List<Book>();
        List<Reader> readers = new List<Reader>();
        Book Checked_Book;

        SqlConnection sqlConnection = new SqlConnection(@"Server=localhost; Database=Books; Integrated Security=SSPI");
        public LibraryApp()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            BookList(ListOfBooks);
            try
            {
                sqlConnection.Open();

                SqlCommand myQuery = new SqlCommand("SELECT * FROM Books.dbo.BookInfo_new;", sqlConnection);

                SqlDataReader myReader = myQuery.ExecuteReader();


                myReader.Read();


                if (myReader.HasRows)
                {

                    int Id = 0;
                    while (myReader.Read())//Запись книг
                    {
                        string Book_Title = myReader["Book_title"].ToString();
                        string Author = myReader["Author"].ToString();
                        string Description = myReader["Description"].ToString();
                        string Genre = myReader["Genre"].ToString();
                        Image image = Image.FromStream(myReader.GetStream(5));
                        //добавилось поле TakeNum(сколько раз книгу брали), нужно добавить его сюда
                        Book book = new Book(Id, Book_Title, Author, image, Description, Genre, eBookCond.available);
                        ListOfBooks.Add(book);
                        switch (Id)
                        {
                            case 0: Bookshelf(book, cover1, title1); coverMouseEnter(cover1); break;
                            case 1: Bookshelf(book, cover2, title2); coverMouseEnter(cover2); break;
                            case 2: Bookshelf(book, cover3, title3); coverMouseEnter(cover3); break;
                            case 3: Bookshelf(book, cover4, title4); coverMouseEnter(cover4); break;
                            case 4: Bookshelf(book, cover5, title5); coverMouseEnter(cover5); break;
                            case 5: Bookshelf(book, cover6, title6); coverMouseEnter(cover6); break;
                            case 6: Bookshelf(book, cover7, title7); coverMouseEnter(cover7); break;
                            case 7: Bookshelf(book, cover8, title8); coverMouseEnter(cover8); break;
                            case 8: Bookshelf(book, cover9, title9); coverMouseEnter(cover9); break;
                        }
                        Id++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void Bookshelf(Book book, PictureBox pBoxBookShelf, RichTextBox rTBoxBookShelf)//метод добавления книги в книжную полку
        {
            pBoxBookShelf.Image = book.Cover;
            rTBoxBookShelf.Text = book.Title + "  -  " + book.Author;
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
            if (numbertextbox.Text.Equals("") || timetextbox.Text.Equals("") || Checked_Book == null)
            {
                MessageBox.Show("Введите все данные!");
            }
            else if (Convert.ToInt32(timetextbox.Text) >= 7 && Convert.ToInt32(timetextbox.Text) <= 60)
            {
                bool is_find = false;//есть ли пользователь в списке прошлых пользователей
                int index = Checked_Book.ID;
                if (readers.Count == 0)
                {
                    readers.Add(new Reader(numbertextbox.Text, Checked_Book, Convert.ToInt32(timetextbox.Text)));
                    ListOfBooks[index].BookCond = eBookCond.busy;
                    Set_book_status(ListOfBooks[index].BookCond);
                    MessageBox.Show($"Вы взяли {Checked_Book.Title + " " + Checked_Book.Author}");
                    //Checked_Book.TakeNum += 1;
                    string takedate = DateTime.Now.ToLongTimeString();//дата взятия книги
                    //записать дату в бд
                }
                else
                {
                    for (int i = 0; i < readers.Count; i++)
                    {
                        if (numbertextbox.Text == readers[i].ID_reader)
                        {
                            is_find = true;
                            if (readers[i].is_ok )
                            {
                                if (ListOfBooks[index].BookCond == eBookCond.available)
                                {
                                    ListOfBooks[index].BookCond = eBookCond.busy;
                                    Set_book_status(ListOfBooks[index].BookCond);
                                    readers.Add(new Reader(numbertextbox.Text, Checked_Book, Convert.ToInt32(timetextbox.Text)));
                                    MessageBox.Show($"Вы взяли {Checked_Book.Title + " " + Checked_Book.Author}");
                                    //Checked_Book.TakeNum += 1;
                                    string takedate = DateTime.Now.ToLongTimeString();//дата взятия книги
                                                                                      //записать дату в бд
                                    break;
                                }
                                else 
                                {
                                    MessageBox.Show("Книга недоступна");
                                    break;
                                }
                               
                            }
                            else
                            {
                                MessageBox.Show("У вас просрочена книга");
                                break;
                            }
                        }
                    }
                    if(!is_find)
                    {
                        if(Checked_Book.BookCond == eBookCond.available)
                        {
                            readers.Add(new Reader(numbertextbox.Text, Checked_Book, Convert.ToInt32(timetextbox.Text)));
                            ListOfBooks[index].BookCond = eBookCond.busy;
                            Set_book_status(ListOfBooks[index].BookCond);
                            MessageBox.Show($"Вы взяли {Checked_Book.Title + " " + Checked_Book.Author}");
                            //Checked_Book.TakeNum += 1;
                            string takedate = DateTime.Now.ToLongTimeString();//дата взятия книги
                                                                              //записать дату в бд
                        }
                        else
                       {
                            MessageBox.Show("Книга недоступна");
                       }
                    }


                }
           
            }
            else if (Convert.ToInt32(timetextbox.Text) < 7 || Convert.ToInt32(timetextbox.Text) > 60)
            {
                MessageBox.Show("Введеный срок не соотвествует указанному диапазону!");
            }
            
        }
        public void coverMouseEnter(PictureBox cover)//метод для того, чтобы при нажатии слева появлялась брошюра
        {
            var Book = GetBookByBookShelf(cover);
            bigcover.Image = cover.Image;
            description.Text = Book.Description;
            Set_book_status(Book.BookCond);
            string str = "";
            foreach (var b in ListOfBooks)
            {
               if( !Book.ID.Equals(b.ID) &&  Book.Genre.Equals(b.Genre))
               {
                    str += b.Author + " - " + b.Title + "\n";      
               }
            }
            Suggestion_Books.Text = "Вам может понравится:\n" + str;

        }
        private void cover1_Click(object sender, EventArgs e)
        {
            Checked_Book = ListOfBooks[0];
        }
        private void cover2_Click(object sender, EventArgs e)
        {
            Checked_Book = ListOfBooks[1];
        }

        private void cover3_Click(object sender, EventArgs e)
        {
            Checked_Book = ListOfBooks[2];
        }

        private void cover4_Click(object sender, EventArgs e)
        {
            Checked_Book = ListOfBooks[3];
        }

        private void cover5_Click(object sender, EventArgs e)
        {
            Checked_Book = ListOfBooks[4];
        }

        private void cover6_Click(object sender, EventArgs e)
        {
            Checked_Book = ListOfBooks[5];
        }

        private void cover7_Click(object sender, EventArgs e)
        {
            Checked_Book = ListOfBooks[6];
        }

        private void cover8_Click(object sender, EventArgs e)
        {
            Checked_Book = ListOfBooks[7];
        }

        private void cover9_Click(object sender, EventArgs e)
        {
            Checked_Book = ListOfBooks[8];
        }
        private void filter_TextChanged(object sender, EventArgs e)
        {
            if (filter.Items.Equals("алфавиту по авторам")) //сортировка по алфавиту по авторам
            {
                MessageBox.Show("К сожалению, данная функция пока не доступна. Наши разработчики уже работают над этим!");
            }
            else if (filter.Items.Contains("алфавиту по названиям")) //сортировка по алфавиту по названиям
            {
                MessageBox.Show("К сожалению, данная функция пока не доступна. Наши разработчики уже работают над этим!");
            }
            else if (filter.Items.Contains("только свободные книги"))//показать только свободные
            {

            }
        }
        public void Set_book_status(eBookCond eBook)
        {
            switch(eBook)
            {
                case eBookCond.available: label_BOOK_status.Text = "Книга доступна"; break;
                case eBookCond.busy: label_BOOK_status.Text = "Книга находится у читателя"; break;
                case eBookCond.comingsoon: label_BOOK_status.Text = "Книга скоро поступит в бибилиотеку"; break;
                case eBookCond.unavailable: label_BOOK_status.Text = "Книга более не доступна"; break;
            }
        }

        private void cover1_MouseEnter(object sender, EventArgs e)
        {
            coverMouseEnter(cover1);
        }

        private void cover2_MouseEnter(object sender, EventArgs e)
        {
            coverMouseEnter(cover2);
        }

        private void cover3_MouseEnter(object sender, EventArgs e)
        {
            coverMouseEnter(cover3);
        }

        private void cover4_MouseEnter(object sender, EventArgs e)
        {
            coverMouseEnter(cover4);
        }

        private void cover5_MouseEnter(object sender, EventArgs e)
        {
            coverMouseEnter(cover5);
        }

        private void cover6_MouseEnter(object sender, EventArgs e)
        {
            coverMouseEnter(cover6);
        }

        private void cover7_MouseEnter(object sender, EventArgs e)
        {
            coverMouseEnter(cover7);
        }

        private void cover8_MouseEnter(object sender, EventArgs e)
        {
            coverMouseEnter(cover8);
        }

        private void cover9_MouseEnter(object sender, EventArgs e)
        {
            coverMouseEnter(cover9);
        }

        private void passbutton_Click(object sender, EventArgs e)
        {
                DialogResult result = MessageBox.Show("Пользователь действительно хочет сдать книгу?", "", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    DateAskform askform = new DateAskform();
                    askform.ShowDialog();
                }
        }
        private void BookList(List<Book> ListOfBooks)//метод для создания списка занятых книг
        {
            foreach (Book book in ListOfBooks)
            {
                if (book.BookCond == eBookCond.busy)
                {
                    busybooks.Items.Add(book.Title);
                }
            }
        }
        private Book GetBookByBusyBooks(ListViewItem item)//вспомогательный метод для того, чтобы связать книгу в busybooks с экземпляром книги
        {
            foreach (Book Book in ListOfBooks)
            {
                if (item.Selected)
                {
                    return Book;
                }
            }
            return null;
        }
        private void busybooksItemClick(ListViewItem item)//метод для того, чтобы при нажатии посередине появлялась брошюра
        {
            var Book = GetBookByBusyBooks(item);
            bigcover2.Image = Book.Cover;
            description2.Text = Book.Description;
        }
        private void busybooks_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            foreach(ListViewItem i in busybooks.Items)
            {
                if(GetBookByBusyBooks(i)!=null)
                {
                    busybooksItemClick(i);
                }
            }
        }
        private void Statistic(List<Book> ListOfBooks)
        {
            foreach (Book book in ListOfBooks)
            {
                statDate.Rows.Add(book.Title, book.TakeDays, book.TakeNum);
            }
        }
    }
}
