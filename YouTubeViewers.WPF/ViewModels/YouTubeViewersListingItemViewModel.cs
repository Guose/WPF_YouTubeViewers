using System.Windows.Input;
using YouTubeViewers.WPF.Models;

namespace YouTubeViewers.WPF.ViewModels
{
    internal class YouTubeViewersListingItemViewModel : ViewModelBase
    {
        public YouTubeViewer YouTubeViewer { get; }

        public string Username => YouTubeViewer.Username;
        public ICommand? EditCommand { get; }
        public ICommand? DeleteCommand { get; }

        public YouTubeViewersListingItemViewModel(YouTubeViewer youTubeViewer, ICommand editCommand)
        {
            YouTubeViewer = youTubeViewer;
            EditCommand = editCommand;
        }
    }
}
