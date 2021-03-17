using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    // Memory den türemiştir, bir nesne değişikliğe uğradıktan sonra tekrar eski haline geri döndürmemize yarar. Yani yapılan değişiklikleri geri alma gibi özellikleri sağlar.
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book { ISBN = "12345", Title = "Sefiller", Author = "Victor Hugo" };
            book.ShowBook();
            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.ISBN = "12345678";
            book.Title = "Lord of The Rings";
            book.Author = "Tolkien";
            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            book.ShowBook();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _iSBN;
        private DateTime _lastEdited;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                SetLastEdited();
            }
        }
        public string Author { get => _author; set { _author = value; SetLastEdited(); } }
        public string ISBN { get => _iSBN; set { _iSBN = value; SetLastEdited(); } }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_iSBN, _title, _author, _lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _iSBN = memento.ISBN;
            _lastEdited = memento.LastEditedDate;
        }

        public void ShowBook()
        {
            Console.WriteLine($"{_iSBN}, {_title}, {_author}, Edited: {_lastEdited}");
        }
    }

    class Memento
    {
        public Memento(string isbn, string title, string author, DateTime lastEdited)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            LastEditedDate = lastEdited;
        }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEditedDate { get; set; }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
