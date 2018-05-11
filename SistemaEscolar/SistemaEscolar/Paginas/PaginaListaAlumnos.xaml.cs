using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SistemaEscolar.Modelos;
using SistemaEscolar.Servicios;

namespace SistemaEscolar.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaListaAlumnos : ContentPage
	{
		public PaginaListaAlumnos (Escuela escuela)
		{
			InitializeComponent ();

            this.BindingContext = escuela;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Loading(true);
            var escuela = (Escuela)this.BindingContext;
            if (escuela != null)
            {
                lsvAlumnos.ItemsSource = null;
                lsvAlumnos.ItemsSource = escuela.Alumnos;
            }
            Loading(false);
        }

        void Loading(bool mostrar)
        {
            indicator.IsEnabled = mostrar;
            indicator.IsRunning = mostrar;
        }

        private async void lsvAlumnos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var dato = (Alumno)e.SelectedItem;
                await Navigation.PushAsync(new PaginaAlumno(dato));
                lsvAlumnos.SelectedItem = null;
            }
            catch (Exception ex)
            {
            }
        }

        public async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            var escuela = (Escuela)this.BindingContext;
            await Navigation.PushAsync(new PaginaAlumno(new Alumno() { Escuela = escuela }));
        }
    }
}