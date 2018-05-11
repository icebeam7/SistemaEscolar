using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SistemaEscolar.Modelos;
using SistemaEscolar.Servicios;

namespace SistemaEscolar.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaAlumno : ContentPage
	{
        ServicioBaseDatos<Alumno> bd;

        public PaginaAlumno (Alumno alumno)
		{
			InitializeComponent ();

            this.BindingContext = alumno;
            bd = new ServicioBaseDatos<Alumno>();

            if (alumno.Id == 0)
                this.ToolbarItems.RemoveAt(1);
        }

        void Loading(bool mostrar)
        {
            indicator.IsEnabled = mostrar;
            indicator.IsRunning = mostrar;
        }

        async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Loading(true);
            var alumno = (Alumno)this.BindingContext;

            if (alumno.Id > 0)
                await bd.Actualizar(alumno);
            else
                await bd.Agregar(alumno);

            Loading(false);
            await DisplayAlert("Correcto", "Registro realizado correctamente", "OK");
            await Navigation.PopAsync();
        }

        async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Advertencia", "¿Deseas eliminar este registro?", "Si", "No"))
            {
                Loading(true);
                await bd.Eliminar(((Alumno)this.BindingContext).Id);
                Loading(false);
                await DisplayAlert("Correcto", "Registro eliminado correctamente", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}