using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TestFastRenderers.Models;
using Xamarin.Forms;

namespace TestFastRenderers.ViewModels
{
    public class AdvancedTestViewModel : BindableObject
    {
        private ObservableCollection<Monkey> _monkeys;
        private int _count;

        public AdvancedTestViewModel()
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
                    "https://upload.wikimedia.org/wikipedia/commons/4/4e/Macaca_nigra_self-portrait_large.jpg",
                    "https://upload.wikimedia.org/wikipedia/commons/4/43/Bonnet_macaque_%28Macaca_radiata%29_Photograph_By_Shantanu_Kuveskar.jpg",
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/5/50/Male_gorilla_in_SF_zoo.jpg/1200px-Male_gorilla_in_SF_zoo.jpg",
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/b/be/Orang_Utan%2C_Semenggok_Forest_Reserve%2C_Sarawak%2C_Borneo%2C_Malaysia.JPG/220px-Orang_Utan%2C_Semenggok_Forest_Reserve%2C_Sarawak%2C_Borneo%2C_Malaysia.JPG"
                };
            }
        }

        public ObservableCollection<Monkey> Monkeys
        {
            get { return _monkeys; }
            set
            {
                _monkeys = value;
                OnPropertyChanged();
            }
        }
    }
}
