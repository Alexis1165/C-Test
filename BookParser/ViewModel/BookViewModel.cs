using BookParser.Helpers;
using System.Collections.ObjectModel;

namespace BookParser.ViewModel
{
    class BookViewModel
    {
        public ObservableCollection<Book> Books { get; set; }
        public BookViewModel(string[] lines)
        {
            Books = new ObservableCollection<Book>();
            for (int i = 1; i < lines.Length; ++i)
            {
                string[] words = lines[i].Split(';');

                Books.Add(new Book
                {
                    Title = words[0],
                    Author = words[1],
                    Year = words[2],
                    Price = words[3],
                    InStock = words[4] == Constants.YES ? true : false,
                    Binding = setBinding(words[5])
                });
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