using System.ComponentModel;

public class Book : INotifyPropertyChanged
{
    private int bookId;
    private string title;
    private string author;
    private string year;
    private string description;
    private double price;
    private bool inStock;
    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            title = value;
            OnPropertyChanged("Title");
        }
    }
    public string Author
    {
        get
        {
            return author;
        }
        set
        {
            author = value;
            OnPropertyChanged("Author");
        }
    }

    public double Price
    {
        get
        {
            return price;
        }
        set
        {
            price = value;
            OnPropertyChanged("Price");
        }
    }

    public string Year
    {
        get
        {
            return year;
        }
        set
        {
            year = value;
            OnPropertyChanged("Year");
        }
    }

    public bool InStock
    {
        get
        {
            return inStock;
        }
        set
        {
            inStock = value;
            OnPropertyChanged("InStock");
        }
    }
    public int BookId
    {
        get
        {
            return bookId;
        }
        set
        {
            bookId = value;
            OnPropertyChanged("Binding");
        }
    }

    public string Description
    {
        get
        {
            return description;
        }
        set
        {
            description = value;
            OnPropertyChanged("Description");
        }
    }

    #region INotifyPropertyChanged Members  

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion

}

public enum BindingType
{
    Paperback,
    Hardcover,
    Unknown,
    Coalwood
}

