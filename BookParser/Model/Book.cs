using System.ComponentModel;

public class Book : INotifyPropertyChanged
{
    private string title;
    private string author;
    private string price;
    private string year;
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

    #region INotifyPropertyChanged Members  

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    #endregion

}
