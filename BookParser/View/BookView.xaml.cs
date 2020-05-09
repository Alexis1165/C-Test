using BookParser.Helpers;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace BookParser.View
{
    /// <summary>
    /// Logic containing code for book data input
    /// </summary>
    public partial class BookView : UserControl
    {
        public BookView()
        {
            InitializeComponent();
        }

        private void bookData_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = Constants.DEFAULT_EXTENSION;
            dlg.Filter = Constants.FILTER;
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string fileName = dlg.FileName;
                BookViewModel bookViewModel = new BookViewModel(File.ReadAllLines(fileName));
                grdBooks.ItemsSource = bookViewModel.Books;
            }
        }
    }
}
