namespace FormulaOneApp.Rss.Readers
{
    using System.Collections.ObjectModel;
    using System.Xml.Linq;
    using Helpers;
    using Models;

    internal class AtomReader : BaseReader
    {
        /// <summary>
        ///     Return a RssFeed object using the XDocument data
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public override RssFeed LoadFeed(XDocument doc)
        {
            var feed = new RssFeed();

            SetMediaImage(feed, doc);
            feed.Description = doc.Root.GetSafeElementString("summary");
            feed.Items = new ObservableCollection<RssItem>();
            feed.LastBuildDate = doc.Root.GetSafeElementDate("updated");
            feed.Link = doc.Root.GetLink("self");

            if (doc.Root == null) return feed;
            foreach (XElement item in doc.Root.Elements(doc.Root.GetDefaultNamespace() + "entry"))
            {
                RssItem rssItem = ParseItem(item);
                feed.Items.Add(rssItem);
            }

            return feed;
        }

        private static RssItem ParseItem(XElement item)
        {
            var rssItem = new RssItem {Title = item.GetSafeElementString("title")};

            string description = item.GetSafeElementString("description");
            rssItem.Description = !string.IsNullOrEmpty(description)
                ? description
                : item.GetSafeElementString("content");

            rssItem.Image = item.GetImage();
            rssItem.PublishDate = item.GetSafeElementDate("published") ?? item.GetSafeElementDate("updated");
            rssItem.Guid = item.GetSafeElementString("id");
            rssItem.Link = item.GetLink("alternate");

            return rssItem;
        }
    }
}