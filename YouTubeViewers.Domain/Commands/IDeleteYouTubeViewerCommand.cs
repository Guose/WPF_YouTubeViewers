namespace YouTubeViewers.Domain.Commands
{
    public interface IDeleteYouTubeViewerCommand
    {
        Task ExecuteDeleteAsync(Guid id);
    }
}
