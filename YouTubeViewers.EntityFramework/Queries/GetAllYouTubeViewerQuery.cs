using Microsoft.EntityFrameworkCore;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.Domain.Queries;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework.Queries
{
    public class GetAllYouTubeViewerQuery : IRetrieveQuery<YouTubeViewer>
    {
        private readonly YouTubeViewersDbContextFactory _dbContextFactory;

        public GetAllYouTubeViewerQuery(YouTubeViewersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<YouTubeViewer>> GetAllAsync()
        {
            using (YouTubeViewersDbContext context = _dbContextFactory.Create())
            {
                IEnumerable<YouTubeViewerDTO> youTubeViewerDTO = await context.YouTubeViewers!.ToListAsync();

                return youTubeViewerDTO.Select(y => new YouTubeViewer(y.Id, y.Username, y.IsSubscribed, y.IsMember));
            }
        }

        public async Task<YouTubeViewer> GetByIdAsync(Guid id)
        {
            using (var context = _dbContextFactory.Create())
            {
                YouTubeViewerDTO youTubeViewerDTO = await context.YouTubeViewers!.FirstAsync(y => y.Id == id)!.ConfigureAwait(false);

                return new YouTubeViewer(youTubeViewerDTO.Id, youTubeViewerDTO.Username, youTubeViewerDTO.IsSubscribed, youTubeViewerDTO.IsMember);
            }
        }
    }
}
