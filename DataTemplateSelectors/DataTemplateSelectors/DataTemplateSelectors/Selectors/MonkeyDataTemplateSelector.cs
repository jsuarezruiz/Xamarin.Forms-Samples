using DataTemplateSelectors.DataTemplates;
using DataTemplateSelectors.Models;
using Xamarin.Forms;

namespace DataTemplateSelectors.Selectors
{
    public class MonkeyDataTemplateSelector : DataTemplateSelector
    {

        private readonly DataTemplate _monkey;
        private readonly DataTemplate _noPhoto;

        public MonkeyDataTemplateSelector()
        {
            _monkey = new DataTemplate(typeof(MonkeyDataTemplate));
            _noPhoto = new DataTemplate(typeof(NoPhotoDataTemplate));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is Monkey)
            {
                if(!string.IsNullOrEmpty(((Monkey)item).Image))
                    return _monkey;
            }

            return _noPhoto;
        }
    }
}
