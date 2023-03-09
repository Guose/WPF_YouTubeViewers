using System.Windows.Input;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersViewModel : ViewModelBase
    {
        public YouTubeViewersListingViewModel ListingViewModel { get; }
        public YouTubeViewersDetailsViewModel DetailsViewModel { get; set; }
        public ICommand? AddYouTubeViewersCommand { get; }

        public YouTubeViewersViewModel(YouTubeViewersStore viewersStore, SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            ListingViewModel = YouTubeViewersListingViewModel.LoadViewModel(viewersStore, selectedYouTubeViewerStore, modalNavigationStore);
            DetailsViewModel = new YouTubeViewersDetailsViewModel(selectedYouTubeViewerStore);

            AddYouTubeViewersCommand = new OpenAddYouTubeViewerCommand(viewersStore, modalNavigationStore);
        }
    }
}
