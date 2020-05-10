using System.Windows;

namespace BookParser
{
    /// <summary>
    /// Created By: Alexis Thomas
    /// This is a separate dialog box for description on button press.
    /// </summary>

    public partial class DescriptionWindow : Window
    {
        public DescriptionWindow(string description)
        {
            InitializeComponent();
            lblDescription.Content = description;
        }
    }
}
