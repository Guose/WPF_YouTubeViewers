using System;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF.Stores
{
    internal class ModalNavigationStore
    {
		private ViewModelBase? _currentViewModel;
		public ViewModelBase? CurrentViewModel
		{
			get => _currentViewModel;
			set 
			{ 
				_currentViewModel = value;
				CurrentViewModelChanged?.Invoke();
			}
		}

        public bool IsOpen => CurrentViewModel != null;

        public event Action? CurrentViewModelChanged;

        internal void Close()
        {
			CurrentViewModel = null;
        }
    }
}
