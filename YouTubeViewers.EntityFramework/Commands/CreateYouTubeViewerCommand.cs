using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework.Commands
{
    public class CreateYouTubeViewerCommand : ICreateYouTubeViewerCommand
    {
        private readonly YouTubeViewersDbContextFactory _dbContextFactory;

        public CreateYouTubeViewerCommand(YouTubeViewersDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task ExecuteCreateAsync(YouTubeViewer youTubeViewer)
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

                await context.YouTubeViewers!.AddAsync(youTubeViewerDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
