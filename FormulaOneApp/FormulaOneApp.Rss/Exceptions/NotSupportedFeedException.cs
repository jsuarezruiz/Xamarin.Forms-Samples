using System;

namespace FormulaOneApp.Rss.Exceptions
{
    public class NotSupportedFeedException : Exception
    {
        /// <summary>
        ///     The exception that is thrown when an error occurs durin the feed parsing when the rss is not supported.
        /// </summary>
        public NotSupportedFeedException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     The exception that is thrown when an error occurs durin the feed parsing when the rss is not supported.
        /// </summary>
        public NotSupportedFeedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}