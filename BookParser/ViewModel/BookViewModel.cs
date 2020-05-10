using BookParser.Helpers;
using BookParser.Model;
using System;
using System.Collections.ObjectModel;

namespace BookParser.ViewModel
{
    class BookViewModel
    {
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Binding> Bindings { get; set; }
        public BookViewModel(string[] lines)
        {
            Books = new ObservableCollection<Book>();
            Bindings = new ObservableCollection<Binding>();
            for (int i = 1; i < lines.Length; ++i)
            {
                string[] words = lines[i].Split(';');

                Books.Add(new Book
                {
                    BookId = i,
                    Title = words[0],
                    Author = words[1],
                    Year = words[2],
                    Price = Convert.ToDouble(words[3]),
                    InStock = words[4] == Constants.YES ? true : false,
                    Description = words[6]
                });
                Bindings.Add(new Binding { bindingId = i, bindingType = words[5] });
            }
        }

        public BindingType setBinding(string word)
        {
            if (word == Constants.PAPERBACK) return BindingType.Paperback;
            else if (word == Constants.HARDCOVER) return BindingType.Hardcover;
            else if (word == Constants.COALWOOD) return BindingType.Coalwood;

            return BindingType.Unknown;
        }
    }
}