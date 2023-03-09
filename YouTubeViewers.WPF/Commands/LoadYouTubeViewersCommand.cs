using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Commands
{
    public class LoadYouTubeViewersCommand : AsyncCommandBase
    {
        private readonly YouTubeViewersViewModel _youTubeViewersViewModel;
        private readonly YouTubeViewersStore _viewersStore;

        public LoadYouTubeViewersCommand(YouTubeViewersViewModel youTubeViewersViewModel, YouTubeViewersStore viewersStore)
        {
            _youTubeViewersViewModel = youTubeViewersViewModel;
            _viewersStore = viewersStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                _youTubeViewersViewModel.ErrorMessage = string.Empty;
                _youTubeViewersViewModel.IsLoading = true;

                await _viewersStore.LoadAsync();
            }
            catch (Exception)
            {
                _youTubeViewersViewModel.ErrorMessage = "Failed to load YouTube viewers. Please restart the application.";
            }
            finally { _youTubeViewersViewModel.IsLoading = false; }
        }
    }
}
