using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands
{
    public class OpenEditYouTubeViewerCommand : CommandBase
    {
        private readonly YouTubeViewersListingItemViewModel _youTubeViewersListingItemViewModel;
        private readonly YouTubeViewersStore _viewersStore;
        private readonly ModalNavigationStore _navigationStore;

        public OpenEditYouTubeViewerCommand(
            YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel, 
            YouTubeViewersStore viewersStore, 
            ModalNavigationStore navigationStore)
        {
            _youTubeViewersListingItemViewModel = youTubeViewersListingItemViewModel;
            _viewersStore = viewersStore;
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            YouTubeViewer youTubeViewer = _youTubeViewersListingItemViewModel.YouTubeViewer;

            if (youTubeViewer != null)
            {
                EditYouTubeViewerViewModel editYouTubeViewerViewModel = 
                    new EditYouTubeViewerViewModel(youTubeViewer, _viewersStore, _navigationStore);

                _navigationStore.CurrentViewModel = editYouTubeViewerViewModel;
            }
        }
    }
}
