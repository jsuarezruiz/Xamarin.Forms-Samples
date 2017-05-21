namespace FormsEmbedding.Model
{
    public class Item : BaseDataObject
    {
        public Item() : base()
        {
        }
        /// <summary>
        /// Private backing field to hold the text
        /// </summary>
        string text = string.Empty;
        /// <summary>
        /// Public property to set and get the text of the item
        /// </summary>
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

    }
}
