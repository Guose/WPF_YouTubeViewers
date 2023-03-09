using System;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands
{
    public class DeleteYouTubeViewerCommand : AsyncCommandBase
    {
        private readonly YouTubeViewersListingItemViewModel _youTubeViewersListingItemViewModel;
        private readonly YouTubeViewersStore _viewersStore;

        public DeleteYouTubeViewerCommand(
            YouTubeViewersListingItemViewModel youTubeViewersListingItemViewModel,
            YouTubeViewersStore viewersStore)
        {
            _youTubeViewersListingItemViewModel = youTubeViewersListingItemViewModel;
            _viewersStore = viewersStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                YouTubeViewer youTubeViewer = _youTubeViewersListingItemViewModel.YouTubeViewer;

                await _viewersStore.DeleteAsync(youTubeViewer.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
