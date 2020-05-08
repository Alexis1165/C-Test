using System.Windows.Input;
using System.Collections.Generic;
using System;

class BookViewModel
{
    public BookViewModel()
    {
        Books = new List<Book>
            {
                new Book{Title = "Sample", Author="Raj",Price="2",Year="2020"}
            };
    }

    public IList<Book> Books { get; set; }
}