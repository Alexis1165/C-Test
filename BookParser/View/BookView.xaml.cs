using System.Windows.Controls;

namespace BookParser.View
{
    /// <summary>
    /// Interaktionslogik für BookView.xaml
    /// </summary>
    public partial class BookView : UserControl
    {
        public BookView()
        {
            InitializeComponent();
            BookViewModel bookViewModel = new BookViewModel();
            grdBooks.ItemsSource = bookViewModel.Books;
        }
    }
}
