using AdaptTablet.Models;
using AdaptTablet.Services.Menu;
using AdaptTablet.Services.Navigation;
using AdaptTablet.ViewModels.Base;
using System.Collections.ObjectModel;

namespace AdaptTablet.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
		private ObservableCollection<MenuItem> _menu;
        private MenuItem _selectedMenu;

        private INavigationService _navigationService;
        private IMenuService _menuService;

		public MainMenuViewModel(
            INavigationService navigationService,
            IMenuService menuService)
		{
            _navigationService = navigationService;
			_menuService = menuService;
		}

		public ObservableCollection<MenuItem> Menu
		{
			get{ return _menu; }
			set
			{
				_menu = value;
				RaisePropertyChanged ();
			}
		}

        public MenuItem SelectedMenu
        {
            get { return _selectedMenu; }
            set
            {
                _selectedMenu = value;

                if (_selectedMenu.PageType != null)
                    _navigationService.NavigateTo(_selectedMenu.PageType, _selectedMenu);
            }
        }

        public override void OnAppearing (object navigationContext)
		{
			base.OnAppearing (navigationContext);

			Menu = _menuService.LoadMenu ();
		}
    }
}