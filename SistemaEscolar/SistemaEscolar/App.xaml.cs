using Xamarin.Forms;
using SistemaEscolar.Datos;
using SistemaEscolar.Helpers;

namespace SistemaEscolar
{
	public partial class App : Application
	{
        public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new Paginas.PaginaListaEscuelas());
		}

        static BaseDatos bd;

        public static BaseDatos BD
        {
            get
            {
                if (bd == null)
                {
                    bd = new BaseDatos(Constantes.NombreBD);
                }
                return bd;
            }
        }
    }
}
