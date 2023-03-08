using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.Domain.Queries
{
    public interface IYouTubeViewersQuery
    {
        Task<IEnumerable<YouTubeViewer>> GetAllViewers();
        Task GetViewerById(Guid id);
    }
}
