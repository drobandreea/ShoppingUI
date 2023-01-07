
using System;
using System.Collections.ObjectModel;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Input;

namespace ShoppingUI
{
    public class ProductPageViewModel
    {
        public ObservableCollection<Items> Items { get; set; }

        public ObservableCollection<Items> CartItems { get; set; }

        public Items SelectedItem { get; set; }

        public ICommand Itemclick { get; set; }
        public ICommand CartItemclick { get; set; }
        public ProductPageViewModel(INavigation navigation)
        {
            Items = new ObservableCollection<Items>
            {
                new Items
                {
                    Imagine="albastru.png",
                    Nume = "DAVIDOFF COOL WATER INTENSE",
                    Cantitate = "1",
                    Pret = "520 LEI"
                },
                new Items
                {
                    Imagine="irres.png",
                    Nume = "LANVIN ÉCLAT D´ARPEGE",
                    Cantitate = "1",
                    Pret = "444 LEI"
                },
                new Items
                {
                    Imagine="kalvin.png",
                    Nume = "CALVIN KLEIN EUPHORIA INTENSE",
                    Cantitate = "1",
                    Pret = "256 LEI"
                },
                new Items
                {
                    Imagine="parfum.png",
                    Nume = "GIVENCHY IRRESISTIBLE",
                    Cantitate = "1",
                    Pret = "456 LEI"
                },
                new Items
                {
                    Imagine="ruxi.png",
                    Nume = "CHOPARD HAPPY CHOPARD FELICIA ROSES",
                    Cantitate = "1",
                    Pret = "100 LEI"
                },
                new Items
                {
                    Imagine="top.png",
                    Nume = "SET PARFUMURI TOP",
                    Cantitate = "1",
                    Pret = "700 LEI"
                }
            };
            CartItems = new ObservableCollection<Items> { };
            Itemclick = new Command<Items>(executeitemclickcommand);
            CartItemclick = new Command<Items>(executeCartitemclickcommand);
            this.navigation = navigation;
        }
        private INavigation navigation;

        async void executeitemclickcommand(Items item)
        {
            this.SelectedItem = item;
            await navigation.PushModalAsync(new DetailsPage(this));
        }

        async void executeCartitemclickcommand(Items item)
        {
            this.CartItems.Add(this.SelectedItem);
            await navigation.PushModalAsync(new CartPage(this));

        }
    }
}
