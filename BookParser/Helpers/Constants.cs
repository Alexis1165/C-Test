using System.Windows.Media;

/// <summary>
/// Created By: Alexis Thomas
/// This file consists of a number of constant classes in order to increase readability and 
/// reusability along with avoiding hard-coded values for string variables.
/// </summary>

namespace BookParser.Helpers
{
    public static class Constants
    {
        public static string DEFAULT_EXTENSION = ".csv";
        public static string FILTER = "CSV Files (*.csv)|*.csv";
        public static string YES = "yes";                   
        public static string PAPERBACK = "Paperback";
        public static string HARDCOVER = "Hardcover";
        public static string UNKNOWN = "Unknown";
        public static string COALWOOD = "Coalwood";
    }

    public static class PriceDistribution 
    {
        public static int MINPRICE = 0;
        public static int MAXPRICE = 1;
        public static int MEDIANPRICE = 2;
    }

    public static class HexColors 
    {
        public static SolidColorBrush HIGHLIGHTER = 
            (SolidColorBrush) new BrushConverter().ConvertFromString("#FFB366");
        public static SolidColorBrush GRID_BACKGROUND =
            (SolidColorBrush)new BrushConverter().ConvertFromString("#525252");
        public static SolidColorBrush ALTERNATING_GRID_BACKGROUND =
            (SolidColorBrush)new BrushConverter().ConvertFromString("#F2F2F2");
        public static SolidColorBrush GRID_BORDER_BRUSH =
            (SolidColorBrush)new BrushConverter().ConvertFromString("#545454");
    }
}
