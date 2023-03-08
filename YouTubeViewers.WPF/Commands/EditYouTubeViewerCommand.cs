using System;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands
{
    public class EditYouTubeViewerCommand : AsyncCommandBase
    {
        private readonly EditYouTubeViewerViewModel _editYouTubeViewerViewModel;
        private readonly YouTubeViewersStore _viewersStore;
        private readonly ModalNavigationStore _navigationStore;

        public EditYouTubeViewerCommand(EditYouTubeViewerViewModel editYouTubeViewerViewModel, YouTubeViewersStore viewersStore, ModalNavigationStore navigationStore)
        {
            _editYouTubeViewerViewModel = editYouTubeViewerViewModel;
            _viewersStore = viewersStore;
            _navigationStore = navigationStore;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            YouTubeViewerDetailsFormViewModel formViewModel = _editYouTubeViewerViewModel.YouTubeViewerDetailsFormViewModel;

            YouTubeViewer youTubeViewer = new YouTubeViewer(
                _editYouTubeViewerViewModel.YouTubeViewerId,
                formViewModel.Username,
                formViewModel.IsSubscribed,
                formViewModel.IsMember);

            await _viewersStore.UpdateAsync(youTubeViewer);
            _navigationStore.Close();
        }
    }
}
