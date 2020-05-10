using BookParser.Helpers;
using BookParser.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

        private void btnFillGrid_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                dlg.DefaultExt = Constants.DEFAULT_EXTENSION;
                dlg.Filter = Constants.FILTER;
                bool? result = dlg.ShowDialog();

                if (result == true)
                {
                    string fileName = dlg.FileName;
                    BookViewModel bookViewModel = new BookViewModel(File.ReadAllLines(fileName));
                    dataGrid.ItemsSource = bookViewModel.Books;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book dataRowView = (Book)((Button)e.Source).DataContext;
                string ProductName = dataRowView.Title.ToString();
                string ProductDescription = dataRowView.Author.ToString();
                MessageBox.Show("You Clicked : " + ProductName + "\r\nDescription : " + ProductDescription);
                //This is the code which will show the button click row data. Thank you.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        //private void bookData_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        //    dlg.DefaultExt = Constants.DEFAULT_EXTENSION;
        //    dlg.Filter = Constants.FILTER;
        //    bool? result = dlg.ShowDialog();

        //    if (result == true)
        //    {
        //        string fileName = dlg.FileName;
        //        BookViewModel bookViewModel = new BookViewModel(File.ReadAllLines(fileName));
        //        grdBooks.ItemsSource = bookViewModel.Books;
        //    }
        //}
    }
}
