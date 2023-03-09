using System;
using System.Windows.Input;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersListingItemViewModel : ViewModelBase
    {
        public YouTubeViewer YouTubeViewer { get; private set; }

        public string Username => YouTubeViewer.Username;
        public ICommand? EditCommand { get; }
        public ICommand? DeleteCommand { get; }

        public YouTubeViewersListingItemViewModel(YouTubeViewer youTubeViewer, YouTubeViewersStore viewersStore, ModalNavigationStore navigationStore)
        {
            YouTubeViewer = youTubeViewer;

            EditCommand = new OpenEditYouTubeViewerCommand(this, viewersStore, navigationStore);
            DeleteCommand = new DeleteYouTubeViewerCommand(this, viewersStore);
        }

        public void Update(YouTubeViewer youTubeViewer)
        {
            YouTubeViewer = youTubeViewer;

            OnPropertyChanged(nameof(Username));
        }
    }
}
