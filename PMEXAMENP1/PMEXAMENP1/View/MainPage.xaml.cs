using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;
using Xamarin.Essentials;

namespace PMEXAMENP1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        public async void getlocation()
        {
             Location Location = await Geolocation.GetLastKnownLocationAsync();
            if (Location == null)
            {
                Location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                }); ;
            }
        }

        private void btnnewu_Clicked(object sender, EventArgs e)
        {

        }
        public async void GetLocation()
        {
            Location Location = await Geolocation.GetLastKnownLocationAsync();

            if (Location == null)
            {
                Location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                }); ;
            }

            txtlatitud.Text = Location.Latitude.ToString();
            txtlongitud.Text = Location.Longitude.ToString();


        }
        private async void btnsavedu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.DirectionsPage());
        }

        private async void btnsave_Clicked(object sender, EventArgs e)
        {
            if (txtlongdesc.Text == "" || txtshortdec.Text == "")
            {
                await DisplayAlert("Error", "Campos Vacios!!", "Ok");
            }
            else
            {
                try
                {
                    //var personas = (Models.Personas)BindingContext;

                    var Direccion = new Models.Direcciones
                    {
                        latitud = this.txtlatitud.Text,
                        longitud = this.txtlongitud.Text,
                        longdirection = this.txtlongdesc.Text,
                        shortdirection = this.txtshortdec.Text,

                    };



                    var resultado = await App.BaseDatos.GrabarDireccion(Direccion);

                    if (resultado == 1)
                    {
                        await DisplayAlert("Agregado", "Ingresado Exitosamente", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo agregar", "OK");
                    }

                }

                catch (Exception ex)
                {
                    await DisplayAlert("Error", ex.Message.ToString(), "Ok");
                    await Navigation.PushAsync(new View.DirectionsPage());
                }
            }
        }

        private void ClearScreen()
        {
            this.txtlatitud.Text = String.Empty;
            this.txtlongitud.Text = String.Empty;
            this.txtlongdesc.Text = String.Empty;
            this.txtshortdec.Text = String.Empty;

        }

        private async void btnsaved_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new View.DirectionsPage());
        }

        private void btngetl_Clicked(object sender, EventArgs e)
        {
            GetLocation();
        }
    }
}