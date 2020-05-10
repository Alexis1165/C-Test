using BookParser.Helpers;
using BookParser.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BookParser.View
{
    /// <summary>
    /// Logic containing code for book data input
    /// </summary>
    public partial class BookView : UserControl
    {
        Dictionary<int, Style> rowStyles = new Dictionary<int, Style>();
        BookViewModel bookViewModel;

        public int OnSorted { get; }

        public BookView()
        {
            InitializeComponent();
        }
        private void LoadBookGrid() 
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = Constants.DEFAULT_EXTENSION;
            dlg.Filter = Constants.FILTER;
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string fileName = dlg.FileName;
                bookViewModel = new BookViewModel(File.ReadAllLines(fileName));
                dataGrid.ItemsSource = bookViewModel.Books;
                DataContext = bookViewModel.Bindings;
                HighlightStocks();
            }
        }
        private void HighlightStocks()
        {
            double[] priceList = new double[3];
            Book[] sortedprices = bookViewModel.Books.OrderBy(book => book.Price).ToArray();
            int medianIndex = sortedprices.Length/2;
            priceList[PriceDistribution.MAXPRICE] = sortedprices[0].Price;
            priceList[PriceDistribution.MINPRICE] = sortedprices[sortedprices.Length - 1].Price;
            priceList[PriceDistribution.MEDIANPRICE] = sortedprices[medianIndex].Price;

            dataGrid.UpdateLayout();
            for (int i = 0; i < dataGrid.Items.Count; ++i)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(i);
                CheckBox inStock = dataGrid.Columns[4].GetCellContent(row) as CheckBox;
                TextBlock txtprice = dataGrid.Columns[2].GetCellContent(row) as TextBlock;
                double price = double.Parse(txtprice.Text, System.Globalization.CultureInfo.InvariantCulture);
                if (!inStock.IsChecked.Value) row.Background = HexColors.HIGHLIGHTER;
                txtprice.Foreground = ColorPrice(price, priceList);
            }
        }
        private SolidColorBrush ColorPrice(double currentPrice, double[] priceList) 
        {
            SolidColorBrush priceColor = new SolidColorBrush();

            if (!priceList.Contains(currentPrice)) priceColor =
                                                currentPrice < priceList[PriceDistribution.MEDIANPRICE] ?
                                                Brushes.Blue : Brushes.Orange;
            else if (currentPrice == priceList[PriceDistribution.MAXPRICE]) priceColor = Brushes.Red;
            else if (currentPrice == priceList[PriceDistribution.MINPRICE]) priceColor = Brushes.Green;
            else if (currentPrice == priceList[PriceDistribution.MEDIANPRICE]) priceColor = Brushes.Yellow;

            return priceColor;
        }
        private void btnFillGrid_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadBookGrid();
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
                Book selectedBook = (Book)((Button)e.Source).DataContext;
                string description = selectedBook.Description.ToString();
                DescriptionWindow descriptionWindow = new DescriptionWindow(description);
                descriptionWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)delegate ()
            {
                HighlightStocks();
            }, null);
        }
    }
}
