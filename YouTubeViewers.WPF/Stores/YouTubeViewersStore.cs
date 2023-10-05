using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.Domain.Queries;

namespace YouTubeViewers.WPF.Stores
{
    public class YouTubeViewersStore
    {
        private readonly IRetrieveQuery<YouTubeViewer> _youTubeViewersQuery;
        private readonly ICreateCommand<YouTubeViewer> _createYouTubeViewerCommand;
        private readonly IUpdateCommand<YouTubeViewer> _updateYouTubeViewerCommand;
        private readonly IDeleteCommand _deleteYouTubeViewerCommand;
        private readonly List<YouTubeViewer> _youTubeViewersList;

        public IEnumerable<YouTubeViewer> YouTubeViewers => _youTubeViewersList;

        public event Action? YouTubeViewersLoaded;
        public event Action<YouTubeViewer>? YouTubeViewerAdded;
        public event Action<YouTubeViewer>? YouTubeViewerUpdated;
        public event Action<Guid>? YouTubeViewerDeleted;

        public YouTubeViewersStore(
            IRetrieveQuery<YouTubeViewer> youTubeViewersQuery, 
            ICreateCommand<YouTubeViewer> createYouTubeViewerCommand, 
            IUpdateCommand<YouTubeViewer> updateYouTubeViewerCommand, 
            IDeleteCommand deleteYouTubeViewerCommand)
        {
            _youTubeViewersQuery = youTubeViewersQuery;
            _createYouTubeViewerCommand = createYouTubeViewerCommand;
            _updateYouTubeViewerCommand = updateYouTubeViewerCommand;
            _deleteYouTubeViewerCommand = deleteYouTubeViewerCommand;

            _youTubeViewersList = new List<YouTubeViewer>();
        }

        public async Task LoadAsync()
        {
            IEnumerable<YouTubeViewer> youTubeViewers = await _youTubeViewersQuery.GetAllAsync();

            _youTubeViewersList.Clear();
            _youTubeViewersList.AddRange(youTubeViewers);

            YouTubeViewersLoaded?.Invoke();
        }

        public async Task CreateAsync(YouTubeViewer youTubeViewer)
        {
            await _createYouTubeViewerCommand.ExecuteCreateAsync(youTubeViewer);

            _youTubeViewersList.Add(youTubeViewer);

            YouTubeViewerAdded?.Invoke(youTubeViewer);
        }

        public async Task UpdateAsync(YouTubeViewer youTubeViewer)
        {
            await _updateYouTubeViewerCommand.ExecuteUpdateAsync(youTubeViewer);

            int currentViewerIndex = _youTubeViewersList.FindIndex(y => y.Id == youTubeViewer.Id);

            if (currentViewerIndex != -1)
                _youTubeViewersList[currentViewerIndex] = youTubeViewer;
            else
                _youTubeViewersList.Add(youTubeViewer);

            YouTubeViewerUpdated?.Invoke(youTubeViewer);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _deleteYouTubeViewerCommand.ExecuteDeleteAsync(id);

            _youTubeViewersList.RemoveAll(y => y.Id == id);

            YouTubeViewerDeleted?.Invoke(id);
        }
    }
}
