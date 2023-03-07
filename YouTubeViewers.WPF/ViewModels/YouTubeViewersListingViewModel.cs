using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    internal class YouTubeViewersListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _listingItemViewModel;
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;
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

        public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore navigationStore)
        {
            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
            _listingItemViewModel = new ObservableCollection<YouTubeViewersListingItemViewModel>();

            AddYouTubeViewer(new YouTubeViewer("Justin", true, true), navigationStore);
            AddYouTubeViewer(new YouTubeViewer("Kathleen", false, true), navigationStore);
            AddYouTubeViewer(new YouTubeViewer("Alison", false, false), navigationStore);
            AddYouTubeViewer(new YouTubeViewer("Olivia", false, true), navigationStore);
            AddYouTubeViewer(new YouTubeViewer("Isabella", true, false), navigationStore);
        }

        private void AddYouTubeViewer(YouTubeViewer youTubeViewer, ModalNavigationStore modalNavigationStore)
        {
            ICommand editComman = new OpenEditYouTubeViewerCommand(youTubeViewer, modalNavigationStore);
            _listingItemViewModel.Add(new YouTubeViewersListingItemViewModel(youTubeViewer, editComman));
        }
    }
}
