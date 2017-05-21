using System;
using Xamarin.Forms;

namespace FormsEmbedding.Forms
{
    public class XamarinFormsApp : Application
    {
        public XamarinFormsApp(Type page = null)
        {
            SetPage(page);
        }

        public void SetPage(Type page)
        {
            if (page == null) 
            {
                MainPage = new ContentPage();
                return;
            }

            MainPage = (Page)Activator.CreateInstance(page);
        }

        public static Page GetPage<T>() where T : Page 
        {
            return Activator.CreateInstance<T>();
        }
    }
}