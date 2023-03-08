using System;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands
{
    public class AddYouTubeViewerCommand : AsyncCommandBase
    {
        private readonly AddYouTubeViewerViewModel _addYouTubeViewerViewModel;
        private readonly YouTubeViewersStore _viewersStore;
        private readonly ModalNavigationStore _navigationStore;

        public AddYouTubeViewerCommand(AddYouTubeViewerViewModel addYouTubeViewerViewModel, YouTubeViewersStore viewersStore, ModalNavigationStore navigationStore)
        {
            _addYouTubeViewerViewModel = addYouTubeViewerViewModel;
            _viewersStore = viewersStore;
            _navigationStore = navigationStore;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            YouTubeViewerDetailsFormViewModel formViewModel = _addYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel;

            YouTubeViewer youTubeViewer = new YouTubeViewer(
                Guid.NewGuid(),
                formViewModel.Username,
                formViewModel.IsSubscribed,
                formViewModel.IsMember);

            await _viewersStore.CreateAsync(youTubeViewer);
            _navigationStore.Close();
        }
    }
}
