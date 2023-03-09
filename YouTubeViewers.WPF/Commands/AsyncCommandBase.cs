using System;
using System.Threading.Tasks;

namespace YouTubeViewers.WPF.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        private bool _isExecuting;
        public bool IsExecuting
        {
            get
            {
                return _isExecuting;
            }
            set
            {
                _isExecuting = value;
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }

        public override async void Execute(object? parameter)
        {
            try
            {
                IsExecuting = true;

                await ExecuteAsync(parameter);
            }
            catch (Exception) { }
            finally { IsExecuting = false; }
        }

        public abstract Task ExecuteAsync(object? parameter);
    }
}
