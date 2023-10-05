namespace YouTubeViewers.Domain.Commands
{
    public interface ICreateCommand<T>
    {
        Task ExecuteCreateAsync(T obj);
    }
}
