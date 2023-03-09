using System;
using System.Threading.Tasks;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.Commands
{
    public class LoadYouTubeViewersCommand : AsyncCommandBase
    {
        private readonly YouTubeViewersStore _viewersStore;

        public LoadYouTubeViewersCommand(YouTubeViewersStore viewersStore)
        {
            _viewersStore = viewersStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _viewersStore.LoadAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
