using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework.Commands
{
    public class UpdateYouTubeViewerCommand : IUpdateCommand<YouTubeViewer>
    {
        private readonly YouTubeViewersDbContextFactory _dbContextFactory;

        public UpdateYouTubeViewerCommand(YouTubeViewersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task ExecuteUpdateAsync(YouTubeViewer youTubeViewer)
        {
            using (YouTubeViewersDbContext context = _dbContextFactory.Create())
            {
                YouTubeViewerDTO youTubeViewerDTO = new YouTubeViewerDTO
                {
                    Id = youTubeViewer.Id,
                    Username = youTubeViewer.Username,
                    IsSubscribed = youTubeViewer.IsSubscribed,
                    IsMember = youTubeViewer.IsMember,
                };

                context.YouTubeViewers!.Update(youTubeViewerDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
