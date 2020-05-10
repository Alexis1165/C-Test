using BookParser.Helpers;
using BookParser.Model;
using System;
using System.Collections.ObjectModel;

/// <summary>
/// Created By: Alexis Thomas
/// ViewModel class connected to the BookView. This class initializes the parsed ".csv" file 
/// and saves the data into two different collections i.e. "Books" and "Bindings" used to bind 
/// the main datagrid.
/// </summary>

namespace BookParser.ViewModel
{
    class BookViewModel
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Binding> Bindings { get; set; }
        public BookViewModel(string[] lines)
        {
            try
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

            catch (Exception ex) 
            {
                logger.Fatal(ex.ToString());
            }
        }
    }
}