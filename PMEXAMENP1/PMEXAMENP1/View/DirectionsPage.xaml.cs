using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMEXAMENP1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DirectionsPage : ContentPage
    {
        public DirectionsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var listadireccione = await App.BaseDatos.ObtenerListaDirecciones();
            lsdirecciones.ItemsSource = listadireccione;
        }


        private async void btnnewuu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.MainPage());
        }


        

        private async void lsdirecciones_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Direcciones item = (Models.Direcciones)e.Item;
            //await DisplayAlert("Elemento seleccionado" ,"Correo: " + item.email, "OK");   
            var page = new View.MapPage();
            page.BindingContext = item;
            await Navigation.PushAsync(page);
        }

        

        private async void toolbar01_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.MainPage());
        }
    }
}