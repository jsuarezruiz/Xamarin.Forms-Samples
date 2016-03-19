using AdaptTablet.Models;
using System.Collections.ObjectModel;

namespace AdaptTablet.Services.Menu
{
    public interface IMenuService
	{
		ObservableCollection<MenuItem> LoadMenu();
	}
}

