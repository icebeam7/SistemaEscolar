using System.IO;
using Xamarin.Forms;
using Windows.Storage;
using SistemaEscolar.UWP.Datos;
using SistemaEscolar.Datos;
using SistemaEscolar.Helpers;

[assembly: Dependency(typeof(BaseDatosUWP))]
namespace SistemaEscolar.UWP.Datos
{
    public class BaseDatosUWP : IBaseDatos
    {
        public string GetDatabasePath()
        {
            return Path.Combine(
                ApplicationData.Current.LocalFolder.Path, 
                Constantes.NombreBD);
        }
    }
}
