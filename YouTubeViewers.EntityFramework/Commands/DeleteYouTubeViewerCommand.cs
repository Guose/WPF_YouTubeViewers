using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework.Commands
{
    public class DeleteYouTubeViewerCommand : IDeleteYouTubeViewerCommand
    {
        private readonly YouTubeViewersDbContextFactory _dbContextFactory;

        public DeleteYouTubeViewerCommand(YouTubeViewersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task ExecuteDeleteAsync(Guid id)
        {
            using (YouTubeViewersDbContext context = _dbContextFactory.Create())
            {
                YouTubeViewerDTO youTubeViewerDTO = new YouTubeViewerDTO
                {
                    Id = id,
                };

                context.YouTubeViewers!.Remove(youTubeViewerDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
