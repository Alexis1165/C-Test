using System.Windows.Controls;
using System.Windows.Media;

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
        public static SolidColorBrush HIGHLIGHTER = (SolidColorBrush) new BrushConverter().ConvertFromString("#FFB366");
    }
}
