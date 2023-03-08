using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.Domain.Commands
{
    public interface IUpdateYouTubeViewerCommand
    {
        Task ExecuteUpdateAsync(YouTubeViewer youTubeViewer);
    }
}
