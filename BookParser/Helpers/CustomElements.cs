using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BookParser.Helpers
{
    public static class CustomElements
    {
        public static void LoadGridProperties(DataGrid bookGrid)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            try
            {
                bookGrid.AutoGenerateColumns = false;
                bookGrid.CanUserAddRows = false;
                bookGrid.Margin = new Thickness(5);
                bookGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
                bookGrid.VerticalAlignment = VerticalAlignment.Stretch;
                bookGrid.FontWeight = FontWeights.Bold;
                bookGrid.CanUserResizeColumns = false;
                bookGrid.CanUserResizeRows = false;
                bookGrid.Foreground = HexColors.GRID_BACKGROUND;
                bookGrid.Height = 390;
                bookGrid.MaxHeight = 390;
                bookGrid.AlternatingRowBackground = HexColors.ALTERNATING_GRID_BACKGROUND;
                bookGrid.BorderBrush = HexColors.GRID_BORDER_BRUSH;
                bookGrid.BorderThickness = new Thickness(2);
                ScrollViewer.SetHorizontalScrollBarVisibility(bookGrid, ScrollBarVisibility.Visible);
                ScrollViewer.SetVerticalScrollBarVisibility(bookGrid, ScrollBarVisibility.Auto);
                ScrollViewer.SetCanContentScroll(bookGrid, true);
            }

            catch (Exception ex)
            {
                logger.Fatal(ex.ToString());
            }
        }
        public static bool? BrowseFile(OpenFileDialog dialog)
        {
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            bool? result = false;

            try
            {
                dialog.DefaultExt = Constants.DEFAULT_EXTENSION;
                dialog.Filter = Constants.FILTER;
                result = dialog.ShowDialog();
            }

            catch (Exception ex)
            {
                logger.Fatal(ex.ToString());
            }

            return result;
        }
        public static double[] SortPrices(Book[] sortedPrices)
        {
            double[] priceList = new double[3];
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            try
            {
                int medianIndex = sortedPrices.Length / 2;
                priceList[PriceDistribution.MINPRICE] = sortedPrices[0].Price;
                priceList[PriceDistribution.MAXPRICE] = sortedPrices[sortedPrices.Length - 1].Price;
                priceList[PriceDistribution.MEDIANPRICE] = sortedPrices[medianIndex].Price;
            }

            catch (Exception ex)
            {
                logger.Fatal(ex.ToString());
            }

            return priceList;
        }
        public static SolidColorBrush ColorPrice(double currentPrice, double[] priceList)
        {
            SolidColorBrush priceColor = new SolidColorBrush();
            NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

            try
            {
                if (!priceList.Contains(currentPrice)) priceColor =
                                        currentPrice < priceList[PriceDistribution.MEDIANPRICE] ?
                                        HexColors.ABOVE_MEDIAN : HexColors.BELOW_MEDIAN;
                else if (currentPrice == priceList[PriceDistribution.MAXPRICE]) priceColor = HexColors.MAX_PRICE;
                else if (currentPrice == priceList[PriceDistribution.MINPRICE]) priceColor = HexColors.MIN_PRICE;
                else if (currentPrice == priceList[PriceDistribution.MEDIANPRICE]) priceColor = HexColors.MEDIAN_PRICE;
            }

            catch (Exception ex) 
            {
                logger.Fatal(ex.ToString());
            }

            return priceColor;
        }
    }
}
