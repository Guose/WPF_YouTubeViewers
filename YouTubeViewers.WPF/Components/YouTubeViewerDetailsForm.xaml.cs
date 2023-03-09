using System.Windows;
using System.Windows.Controls;

namespace YouTubeViewers.WPF.Components
{
    /// <summary>
    /// Interaction logic for YouTubeViewerDetailsForm.xaml
    /// </summary>
    public partial class YouTubeViewerDetailsForm : UserControl
    {
        public YouTubeViewerDetailsForm()
        {
            InitializeComponent();

            txtAddViewer.Focusable = true;
            txtAddViewer.Focus();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((sender as UserControl).IsVisible)
            {
                (sender as UserControl).Focus();
            }
        }
    }
}
