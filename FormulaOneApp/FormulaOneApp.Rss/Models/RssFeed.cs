using System;
using System.Collections.ObjectModel;

namespace FormulaOneApp.Rss.Models
{
    /// <summary>
    /// </summary>
    public class RssFeed
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string FeedType { get; set; }

        public string RssUrl { get; set; }

        public DateTime? RefreshTimeStamp { get; set; }

        public DateTime? LastBuildDate { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public Uri ImageUri { get; set; }

        public ObservableCollection<RssItem> Items { get; set; }
    }
}