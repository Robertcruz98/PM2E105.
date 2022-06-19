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
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        private async void btnnewuuu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.DirectionsPage());
        }

        private async void btndel_Clicked(object sender, EventArgs e)
        {
            var direccion = new Models.Direcciones
            {
                codigo = Convert.ToInt32(this.txtcod.Text),
                latitud = this.txtlat.Text,
                longitud = this.txtlon.Text,
                longdirection = this.txtlong.Text,
                shortdirection = this.txtshort.Text,

            };

            if (await App.BaseDatos.EliminarDireccion(direccion) != 0)
                await DisplayAlert("Dato eliminado", "El dato ha sido eliminado correctamente", "OK");
            else
                await DisplayAlert("Error", "El dato no ha sido eliminado", "OK");

            await Navigation.PushAsync(new View.DirectionsPage());

        }
    

        private async void btnup_Clicked(object sender, EventArgs e)
        {
            var Direccion = new Models.Direcciones
            {

                codigo = Convert.ToInt32(this.txtcod.Text),
                latitud = this.txtlat.Text,
                longitud = this.txtlon.Text,
                longdirection = this.txtlong.Text,
                shortdirection = this.txtshort.Text,

            };

            if (await App.BaseDatos.GrabarDireccion(Direccion) != 0)
                await DisplayAlert("Direccion actualizado", "La Direccion ha sido actualizada correctamente", "OK");
            else
                await DisplayAlert("Error", "Direccion no ha sido actualizada", "OK");
        }

        private async void btnmapa_Clicked(object sender, EventArgs e)
        {
            var dir = new Models.Direcciones
            {
                longitud = txtlon.Text,
                latitud = txtlat.Text,

            };
            var secondPage = new MapaPage();
            secondPage.BindingContext = dir;
            await Navigation.PushAsync(secondPage);
        }
    }
}