using System;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.Commands
{
    internal class CloseModalCommand : CommandBase
    {
        private readonly ModalNavigationStore _navigationStore;

        public CloseModalCommand(ModalNavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.Close();
        }
    }
}
