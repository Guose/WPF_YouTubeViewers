using System.Windows;
using System.Windows.Controls;

namespace YouTubeViewers.WPF.Components
{
    /// <summary>
    /// Interaction logic for YouTubeViewerListingItem.xaml
    /// </summary>
    public partial class YouTubeViewerListingItem : UserControl
    {
        public YouTubeViewerListingItem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dropdown.IsOpen = false;
        }
    }
}
