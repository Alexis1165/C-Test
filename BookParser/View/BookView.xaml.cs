using BookParser.Helpers;
using BookParser.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BookParser.View
{
    /// <summary>
    /// Created By: Alexis Thomas
    /// The core logic containing methods to create, manipulate and modify data in the User Interface
    /// </summary>
    public partial class BookView : UserControl
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        BookViewModel bookViewModel;
        public int OnSorted { get; }

        public BookView()
        {
            InitializeComponent();
            InitializeBookGrid();
            InitializeButtons();
        }
        private void InitializeButtons() 
        {
            try 
            {
                CustomElements.LoadButtonProperties(btnUploadBook);
                CustomElements.LoadLinkProperties(btnDeleteGrid);
            }
            
            catch(Exception ex) 
            {
                logger.Fatal(ex.ToString());
            }
        }
        private void InitializeBookGrid() 
        {
            try 
            {
                CustomElements.LoadGridProperties(dataGrid);
            }

            catch (Exception ex) 
            {
                logger.Fatal(ex.ToString());
            }
        }
        private void LoadBookGrid() 
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? result = CustomElements.BrowseFile(dialog);

            try 
            {
                if (result == true)
                {
                    string fileName = dialog.FileName;
                    bookViewModel = new BookViewModel(File.ReadAllLines(fileName));
                    dataGrid.ItemsSource = bookViewModel.Books;
                    DataContext = bookViewModel.Bindings;
                    HighlightStocks();
                }
            }

            catch(Exception ex) 
            {
                logger.Fatal(ex.ToString());
            }
        }
        private void HighlightStocks()
        {
            try 
            {
                Book[] sortedPrices = bookViewModel.Books.OrderBy(book => book.Price).ToArray();
                double[] priceList = CustomElements.SortPrices(sortedPrices);
                dataGrid.UpdateLayout();

                for (int i = 0; i < dataGrid.Items.Count; ++i)
                {
                    DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(i);
                    CheckBox inStock = dataGrid.Columns[4].GetCellContent(row) as CheckBox;
                    TextBlock txtprice = dataGrid.Columns[2].GetCellContent(row) as TextBlock;
                    double price = double.Parse(txtprice.Text, System.Globalization.CultureInfo.InvariantCulture);
                    if (!inStock.IsChecked.Value) row.Background = HexColors.HIGHLIGHTER;
                    txtprice.Foreground = CustomElements.ColorPrice(price, priceList);
                }
            }

            catch (Exception ex) 
            {
                logger.Fatal(ex.ToString());
            }
        }
        private void btnUploadBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadBookGrid();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Could Not Load Data!!");
                logger.Fatal(ex.ToString());
            }
        }
        private void dataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            Dispatcher.BeginInvoke((Action)delegate ()
            {
                HighlightStocks();
            }, null);
        }
        private void btnDescription_Click(object sender, RoutedEventArgs e)
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
                logger.Fatal(ex.ToString());
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try 
            {
                if (dataGrid.SelectedIndex >= 0) 
                {
                    HighlightStocks();
                    DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.
                                        ContainerFromIndex(dataGrid.SelectedIndex);
                    TextBlock txtprice = dataGrid.Columns[2].GetCellContent(row) as TextBlock;
                    txtprice.Foreground = Brushes.White;
                }
            }

            catch (Exception ex) 
            {
                logger.Fatal(ex.ToString());
            }
        }

        private void btnDeleteGrid_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try 
            {
                if (bookViewModel != null)
                {
                    ObservableCollection<Book> books = new ObservableCollection<Book>();

                    foreach (Book book in bookViewModel.Books)
                        if (book.InStock) books.Add(book);

                    bookViewModel.Books = books;
                    dataGrid.ItemsSource = bookViewModel.Books;
                    DataContext = bookViewModel.Bindings;
                    HighlightStocks();
                }

                else MessageBox.Show("Action Failed: \r\n No Data to Remove");
            }

            catch (NullReferenceException ex) 
            {
                MessageBox.Show("Action Failed: \r\n" + ex.Message);
                logger.Fatal(ex.ToString());
            }

            catch (Exception ex) 
            {
                MessageBox.Show("Action Failed: \r\n" + ex.Message);
                logger.Fatal(ex.ToString());
            }
        }
    }
}
