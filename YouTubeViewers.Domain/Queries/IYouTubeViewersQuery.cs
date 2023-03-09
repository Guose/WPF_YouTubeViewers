using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.Domain.Queries
{
    public interface IYouTubeViewersQuery
    {
        Task<IEnumerable<YouTubeViewer>> GetAllYouTubeViewersAsync();
        Task<YouTubeViewer> GetYouTubeViewerByIdAsync(Guid id);
    }
}
