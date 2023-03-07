using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore _navigationStore;

        public ViewModelBase? CurrentModalViewModel => _navigationStore.CurrentViewModel;
        public bool IsModalOpen => _navigationStore.IsOpen;
        public YouTubeViewersViewModel YouTubeViewersViewModel { get; }

        public MainViewModel(ModalNavigationStore navigationStore, YouTubeViewersViewModel youTubeViewersViewModel)
        {
            _navigationStore = navigationStore;
            YouTubeViewersViewModel = youTubeViewersViewModel;

            _navigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;
        }

        protected override void Dispose()
        {
            _navigationStore.CurrentViewModelChanged -= ModalNavigationStore_CurrentViewModelChanged;

            base.Dispose();
        }

        private void ModalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
