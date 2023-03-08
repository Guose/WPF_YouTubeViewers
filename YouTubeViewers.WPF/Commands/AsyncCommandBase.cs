using System;
using System.Threading.Tasks;

namespace YouTubeViewers.WPF.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        public override async void Execute(object? parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception) { }
        }

        public abstract Task ExecuteAsync(object? parameter);
    }
}
