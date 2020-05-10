using System.ComponentModel;

public class Book : INotifyPropertyChanged
{
    private string title;
    private string author;
    private string price;
    private string year;
    private bool inStock;
    private BindingType binding; 
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

    public string Price
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
    public BindingType Binding
    {
        get
        {
            return binding;
        }
        set
        {
            binding = value;
            OnPropertyChanged("Binding");
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

