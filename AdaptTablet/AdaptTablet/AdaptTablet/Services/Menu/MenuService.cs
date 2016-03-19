using AdaptTablet.Models;
using AdaptTablet.ViewModels;
using System.Collections.ObjectModel;

namespace AdaptTablet.Services.Menu
{
    public class MenuService : IMenuService
	{
		public ObservableCollection<MenuItem> LoadMenu()
		{
			return new ObservableCollection<MenuItem> {
				new MenuItem("Drivers", typeof(DriverListViewModel), "*"),
				new MenuItem("Constructors", null, "*"),
				new MenuItem("Circuits", null, "*"),
                new MenuItem("About", null, "*")
            };
		}
	}
}

