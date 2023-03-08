namespace YouTubeViewers.Domain.Commands
{
    public interface IUpdateYouTubeViewerCommand
    {
        Task Execute(Guid Id);
    }
}
