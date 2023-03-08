namespace YouTubeViewers.Domain.Commands
{
    public interface ICreateYouTubeViewerCommand
    {
        Task Execute(Guid Id);
    }
}
