using System.Windows.Input;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersViewModel : ViewModelBase
    {
        public YouTubeViewersListingViewModel ListingViewModel { get; }
        public YouTubeViewersDetailsViewModel DetailsViewModel { get; set; }
        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public ICommand AddYouTubeViewersCommand { get; }
        public ICommand LoadYouTubeViewersCommand { get; }

        public YouTubeViewersViewModel(YouTubeViewersStore viewersStore, SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            ListingViewModel = new YouTubeViewersListingViewModel(viewersStore, selectedYouTubeViewerStore, modalNavigationStore);
            DetailsViewModel = new YouTubeViewersDetailsViewModel(selectedYouTubeViewerStore);

            LoadYouTubeViewersCommand = new LoadYouTubeViewersCommand(this, viewersStore);
            AddYouTubeViewersCommand = new OpenAddYouTubeViewerCommand(viewersStore, modalNavigationStore);
        }

        public static YouTubeViewersViewModel LoadViewModel(YouTubeViewersStore viewersStore, SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore navigationStore)
        {
            YouTubeViewersViewModel viewModel = new YouTubeViewersViewModel(viewersStore, selectedYouTubeViewerStore, navigationStore);

            viewModel.LoadYouTubeViewersCommand.Execute(viewModel);

            return viewModel;
        }
    }
}
