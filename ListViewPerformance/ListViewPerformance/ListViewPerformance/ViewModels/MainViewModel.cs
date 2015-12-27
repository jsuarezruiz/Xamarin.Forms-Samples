namespace ListViewPerformance.ViewModels
{
    using ListViewPerformance.ViewModels.Base;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Monkey> _monkeys;
        private int _count;
                
        public MainViewModel()
        {
            Monkeys = new ObservableCollection<Monkey>();

            _count = 1;
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                Monkeys.Insert(0,
                    new Monkey
                    {
                        Name = string.Format("Monkey {0}", _count),
                        Location = Countries[random.Next(0, Countries.Count)],
                        Photo = Images[random.Next(0, Images.Count)]
                    });
                _count++;
            }
        }

        public List<string> Countries
        {
            get
            {
                return new List<string>
                {
                    "Spain",
                    "EEUU",
                    "México",
                    "Peru",
                    "Brazil"
                };
            }
        }

        public List<string> Images
        {
            get
            {
                return new List<string>
                {
                    "http://photoportrays.com/wp-content/uploads/2015/03/Monkeys-monkeys-14750646-1600-1200.jpg",
                    "http://photoportrays.com/wp-content/uploads/2015/03/monkeys_family.jpg",
                    "http://photoportrays.com/wp-content/uploads/2015/03/monkey_by_mydarkeyes-d81yod1.jpg",
                    "http://photoportrays.com/wp-content/uploads/2015/03/lonely_monkey_by_krissimon-d76bn9o.jpg"
                };
            }
        }

        public ObservableCollection<Monkey> Monkeys
        {
            get { return _monkeys; }
            set
            {
                _monkeys = value;
                RaisePropertyChanged();
            }
        }
    }
}
