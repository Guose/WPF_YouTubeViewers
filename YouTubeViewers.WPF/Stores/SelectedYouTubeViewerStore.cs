using System;
using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.WPF.Stores
{
    public class SelectedYouTubeViewerStore
    {
        private readonly YouTubeViewersStore _youTubeViewersStore;

        private YouTubeViewer? _selectedYouTubeViewer;
        public YouTubeViewer? SelectedYouTubeViewer
        {
			get => _selectedYouTubeViewer;
			set 
			{ 
				_selectedYouTubeViewer = value;
				SelectedYouTubeViewerChanged?.Invoke();
			}
		}

        public SelectedYouTubeViewerStore(YouTubeViewersStore youTubeViewersStore)
        {
            _youTubeViewersStore = youTubeViewersStore;

            _youTubeViewersStore.YouTubeViewerUpdated += YouTubeViewersStore_YouTubeViewerUpdated;
            _youTubeViewersStore.YouTubeViewerAdded += YouTubeViewersStore_YouTubeViewerAdded;
        }

        private void YouTubeViewersStore_YouTubeViewerAdded(YouTubeViewer youTubeViewer)
        {
            SelectedYouTubeViewer = youTubeViewer;
        }

        private void YouTubeViewersStore_YouTubeViewerUpdated(YouTubeViewer youTubeViewer)
        {
            if (youTubeViewer.Id == SelectedYouTubeViewer?.Id)
            {
                SelectedYouTubeViewer = youTubeViewer;
            }
        }

        public event Action? SelectedYouTubeViewerChanged;
    }
}
