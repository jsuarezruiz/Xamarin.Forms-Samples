namespace FormulaOneApp.Rss.Readers
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Xml.Linq;
    using Helpers;
    using Models;

    internal abstract class BaseRss : BaseReader
    {
        /// <summary>
        ///     Return a RssFeed object using the XDocument data
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public override RssFeed LoadFeed(XDocument doc)
        {
            var feed = new RssFeed();
            XNamespace defaultNamespace = string.Empty;

            SetMediaImage(feed, doc);
            if (doc.Root != null)
            {
                defaultNamespace = doc.Root.GetDefaultNamespace();

                feed.Description = doc.Root.Element("channel").GetSafeElementString("description");
                feed.Items = new ObservableCollection<RssItem>();
                feed.Link = doc.Root.Element("channel").GetSafeElementString("link");
            }

            foreach (XElement item in doc.Descendants(defaultNamespace + "item"))
            {
                RssItem rssItem = ParseItem(item);
                feed.Items.Add(rssItem);
            }

            RssItem lastItem = feed.Items.OrderByDescending(i => i.PublishDate).FirstOrDefault();
            if (lastItem != null)
                feed.LastBuildDate = lastItem.PublishDate;

            return feed;
        }

        protected abstract RssItem ParseItem(XElement item);
    }
}