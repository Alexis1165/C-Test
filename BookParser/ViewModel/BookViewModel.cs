using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using System;

class BookViewModel
{
    private IList<Book> _BooksList;

    public BookViewModel()
    {
        _BooksList = new List<Book>
            {
                new Book{Title = "Sample", Author="Raj",Price="2",Year="2020"}
            };
    }

    public IList<Book> Books
    {
        get { return _BooksList; }
        set { _BooksList = value; }
    }

    private ICommand mUpdater;
    public ICommand UpdateCommand
    {
        get
        {
            if (mUpdater == null)
                mUpdater = new Updater();
            return mUpdater;
        }
        set
        {
            mUpdater = value;
        }
    }

    private class Updater : ICommand
    {
        #region ICommand Members  

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {

        }

        #endregion
    }
}