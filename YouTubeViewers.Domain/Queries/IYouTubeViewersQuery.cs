using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.Domain.Queries
{
    public interface IYouTubeViewersQuery
    {
        Task<IEnumerable<YouTubeViewer>> GetAllYouTubeViewers();
        Task<YouTubeViewer> GetYouTubeViewerById(Guid id);
    }
}
