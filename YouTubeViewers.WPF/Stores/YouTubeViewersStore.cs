using System;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.WPF.Stores
{
    public class YouTubeViewersStore
    {
        public event Action<YouTubeViewer>? YouTubeViewerAdded;
        public event Action<YouTubeViewer>? YouTubeViewerUpdated;

        public async Task CreateAsync(YouTubeViewer youTubeViewer)
        {
            YouTubeViewerAdded?.Invoke(youTubeViewer);
        }

        public async Task UpdateAsync(YouTubeViewer youTubeViewer)
        {
            YouTubeViewerUpdated?.Invoke(youTubeViewer);
        }
    }
}
