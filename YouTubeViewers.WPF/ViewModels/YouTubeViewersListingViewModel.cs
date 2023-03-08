using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _listingItemViewModel;
        private readonly YouTubeViewersStore _viewersStore;
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;
        private readonly ModalNavigationStore _navigationStore;
        private YouTubeViewersListingItemViewModel? _selectedViewerListingViewModel;

        public IEnumerable<YouTubeViewersListingItemViewModel> ListingItemViewModel => _listingItemViewModel;
        public YouTubeViewersListingItemViewModel? SelectedViewerListingViewModel
        {
            get =>_selectedViewerListingViewModel;
            set 
            { 
                _selectedViewerListingViewModel = value;
                OnPropertyChanged(nameof(SelectedViewerListingViewModel));

                _selectedYouTubeViewerStore.SelectedYouTubeViewer = _selectedViewerListingViewModel?.YouTubeViewer;
            }
        }

        public YouTubeViewersListingViewModel(YouTubeViewersStore viewersStore, SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore navigationStore)
        {
            _viewersStore = viewersStore;
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
            _navigationStore = navigationStore;
            _listingItemViewModel = new ObservableCollection<YouTubeViewersListingItemViewModel>();

            _viewersStore.YouTubeViewerAdded += ViewersStore_YouTubeViewerAdded;
            _viewersStore.YouTubeViewerUpdated += ViewersStore_YouTubeViewerUpdated;
        }

        private void ViewersStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersListingItemViewModel? youTubeViewerViewModel = 
                _listingItemViewModel.FirstOrDefault(y => y.YouTubeViewer.Id == youTubeViewer.Id);

            if (youTubeViewerViewModel != null)
            {
                youTubeViewerViewModel.Update(youTubeViewer);
            }
        }

        protected override void Dispose()
        {
            _viewersStore.YouTubeViewerAdded -= ViewersStore_YouTubeViewerAdded;
            _viewersStore.YouTubeViewerUpdated -= ViewersStore_YouTubeViewerUpdated;

            base.Dispose();
        }

        private void ViewersStore_YouTubeViewerAdded(YouTubeViewer youTubeViewer)
        {
            AddYouTubeViewer(youTubeViewer);
        }

        private void AddYouTubeViewer(YouTubeViewer youTubeViewer)
        {
            YouTubeViewersListingItemViewModel itemViewModel = 
                new YouTubeViewersListingItemViewModel(youTubeViewer, _viewersStore, _navigationStore);
            _listingItemViewModel.Add(itemViewModel);
        }
    }
}
