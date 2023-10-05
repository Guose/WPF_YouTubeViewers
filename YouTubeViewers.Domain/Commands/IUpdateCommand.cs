using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.Domain.Commands
{
    public interface IUpdateCommand<T>
    {
        Task ExecuteUpdateAsync(T obj);
    }
}
