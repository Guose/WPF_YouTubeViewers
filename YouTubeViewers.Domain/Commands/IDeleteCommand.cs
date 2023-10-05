namespace YouTubeViewers.Domain.Commands
{
    public interface IDeleteCommand
    {
        Task ExecuteDeleteAsync(Guid id);
    }
}
