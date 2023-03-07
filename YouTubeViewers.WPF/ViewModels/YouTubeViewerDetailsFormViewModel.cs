using System.Windows.Input;

namespace YouTubeViewers.WPF.ViewModels
{
    internal class YouTubeViewerDetailsFormViewModel : ViewModelBase
    {
		private string? _username;
		public string? Username
		{
			get
			{
				return _username;
			}
			set
			{
				_username = value;
				OnPropertyChanged(nameof(Username));
                OnPropertyChanged(nameof(CanSubmit));
            }
		}

		private bool _isSubscribed;
		public bool IsSubscriped
		{
			get
			{
				return _isSubscribed;
			}
			set
			{
				_isSubscribed = value;
				OnPropertyChanged(nameof(IsSubscriped));
			}
		}

		private bool _isMember;
        public bool IsMember
		{
			get
			{
				return _isMember;
			}
			set
			{
				_isMember = value;
				OnPropertyChanged(nameof(IsMember));
			}
		}
        public YouTubeViewerDetailsFormViewModel(ICommand? submitCommand, ICommand? cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }

        public bool CanSubmit => !string.IsNullOrEmpty(Username);

        public ICommand? SubmitCommand { get; set; }
        public ICommand? CancelCommand { get; set; }

    }
}
