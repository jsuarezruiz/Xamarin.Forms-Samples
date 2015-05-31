using System;

namespace FormulaOneApp.Rss.Models
{
    /// <summary>
    /// </summary>
    public class RssItem
    {
        public string Title { get; set; }

        public DateTime? PublishDate { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public string Image { get; set; }

        public string Guid { get; set; }
    }
}