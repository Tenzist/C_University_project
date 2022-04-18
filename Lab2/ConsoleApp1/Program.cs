using System;

namespace LabSecond
{
    // Структура для опису автора
    public struct Author
    {
        public string Surname, Name;

        // Перевизначення еквівалентності
        public override bool Equals(object obj)
        {
            Author author = (Author) obj;
            return author.Surname == Surname && author.Name == Name;
        }

        // Визначення представлення у вигляді рядку:
        public override string ToString()
        {
            return Name + " " + Surname;
        }

        // Визначається у парі з Equals()
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    // Книжка 
    public class Book
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public Author[] Authors { get; set; }

        // Конструктор
        public Book(string title, int year, params Author[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors;
        }

        // Визначення представлення у вигляді рядку
        // string.Format() забезпечує форматування, аналогічне Console.WriteLine()
        public override string ToString()
        {
            string s = string.Format("Назва: \"{0}\". Рiк видання: {1}", Title, Year);
            s += "\n" + "   Автор(и):";
            for (int i = 0; i < Authors.Length; i++)
            {
                s += string.Format("      {0}", Authors[i]);
                if (i < Authors.Length - 1)
                {
                    s += ",";
                }
                else
                {
                    s += "\n";
                }
            }
            return s;
        }

        // Перевизначення еквівалентності
        public override bool Equals(object obj)
        {
            Book b = obj as Book;
            if (b != null)
            {
                if (b.Authors.Length != Authors.Length)
                {
                    return false;
                }
                for (int i = 0; i < Authors.Length; i++)
                {
                    if (!b.Authors[i].Equals(Authors[i]))
                    {
                        return false;
                    }
                }
                return b.Title == Title && b.Year == Year;
            }
            return false;
        }

        // Визначається у парі з Equals()
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

    // Книжкова полиця
    public class Bookshelf
    {
        public Book[] Books { get; set; }
    
        // Конструктор
        public Bookshelf(params Book[] books)
        {
            Books = books;
        }

        // Індексатор
        public Book this[int index]
        {
            get { return Books[index]; }
            set { Books[index] = value; }
        }

        // Визначення представлення у вигляді рядку
        public override string ToString()
        {
            string result = "";
            foreach (Book book in Books)
            {
                result += book;
            }
            return result;
        }

        // Пошук книжки з певною послідовністю літер
        public Book[] ContainsCharacters(string characters)
        {
            Book[] found = new Book[0];
            foreach (Book book in Books)
            {
                if (book.Title.Contains(characters))
                {
                    // Додаємо новий елемент до масиву:
                    Array.Resize(ref found, found.Length + 1);
                    found[found.Length - 1] = book;
                }
            }
            return found;
        }

        // Додавання книжки
        public void Add(Book book)
        {
            Book[] books = Books;
            Array.Resize(ref books, Books.Length + 1);
            Books = books;
            Books[Books.Length - 1] = book;
        }

        // Видалення книжки зі вказаними даними
        public void Remove(Book book)
        {
            int i, k;
            Book[] newBooks = new Book[Books.Length];
            for (i = 0, k = 0; i < Books.Length; i++, k++)
            {
                if (Books[i].Equals(book))
                {
                    k--;
                }
                else
                {
                    newBooks[k] = Books[i];
                }
            }
            if (i > k)
            {
                Array.Resize(ref newBooks, Books.Length - 1);
            }
            Books = newBooks;
        }

        // Перевантажений оператор додавання книжки
        public static Bookshelf operator+(Bookshelf bookshelf, Book book)
        {
            Bookshelf newBookshelf = new Bookshelf(bookshelf.Books);
            newBookshelf.Add(book);
            return newBookshelf;
        }

        // Перевантажений оператор видалення книжки
        public static Bookshelf operator-(Bookshelf bookshelf, Book book)
        {
            Bookshelf newBookshelf = new Bookshelf(bookshelf.Books);
            newBookshelf.Remove(book);
            return newBookshelf;
        }
    }

    // Книжкова полиця з назвою
    public class TitledBookshelf : Bookshelf
    {
        public string Title { get; set; }

        public TitledBookshelf(string title, params Book[] books) : base(books)
        {
            Title = title;
        }
    
        // Визначення представлення у вигляді рядку
        public override string ToString()
        {
            return Title + "\n" + base.ToString();
        }

        // Перевантажений оператор додавання книжки
        public static TitledBookshelf operator +(TitledBookshelf titled, Book book)
        {
            TitledBookshelf newBookshelf = new TitledBookshelf(titled.Title, titled.Books);
            newBookshelf.Add(book);
            return newBookshelf;
        }

        // Перевантажений оператор видалення книжки
        public static TitledBookshelf operator -(TitledBookshelf titled, Book book)
        {
            TitledBookshelf newBookshelf = new TitledBookshelf(titled.Title, titled.Books);
            newBookshelf.Remove(book);
            return newBookshelf;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо порожню полицю:
            Bookshelf bookshelf = new Bookshelf();

            // Додаємо книжки
            bookshelf += new Book("The UML User Guide", 1999, 
                                  new Author() { Name = "Grady", Surname = "Booch" },
                                  new Author() { Name = "James", Surname = "Rumbaugh" },
                                  new Author() { Name = "Ivar", Surname = "Jacobson" });
            bookshelf += new Book(@"Об'єктно-орiєнтоване моделювання програмних систем", 2007, 
                                  new Author() { Name = "Iгор", Surname =  "Дудзяний" });
            bookshelf += new Book("Thinking in Java", 2005, 
                                  new Author() { Name = "Bruce", Surname = "Eckel" });

            // Виводимо дані на екран:
            Console.WriteLine(bookshelf); 
            Console.WriteLine();

            // Шукаємо книжки з певною послідовністю літер:
            Console.WriteLine("Уведiть послiдовнiсть лiтер:"); 
            string sequence = Console.ReadLine();
            Bookshelf newBookshelf = new Bookshelf(bookshelf.ContainsCharacters(sequence));
            // Виводимо результат на екран:
            Console.WriteLine("Знайденi книжки:"); 
            Console.WriteLine(newBookshelf);
            Console.WriteLine();

            // Видаляємо книжку про Java
            Book javaBook = bookshelf[2]; // індексатор
            bookshelf -= javaBook;
            Console.WriteLine("Пiсля видалення книжки:"); 
            Console.WriteLine(bookshelf);
            Console.WriteLine();

            // Створюємо нову полицю
            TitledBookshelf titledBookshelf = new TitledBookshelf("Java");
            titledBookshelf += javaBook;
            Console.WriteLine("Нова полиця:");
            Console.WriteLine(titledBookshelf);
        }
    }
}