namespace YouTubeViewers.WPF.Models
{
    internal class YouTubeViewer
    {
        public string Username { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }

        public YouTubeViewer(string user, bool subscribed, bool member)
        {
            Username = user;
            IsSubscribed = subscribed;
            IsMember = member;
        }
    }
}
