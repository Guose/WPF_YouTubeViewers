using System;

namespace YouTubeViewers.WPF.Models
{
    public class YouTubeViewer
    {
        public Guid Id { get; }
        public string Username { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }

        public YouTubeViewer(Guid id, string username, bool subscribed, bool member)
        {
            Id = id;
            Username = username;
            IsSubscribed = subscribed;
            IsMember = member;
        }
    }
}
