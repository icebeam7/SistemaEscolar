using System.IO;
using Xamarin.Forms;
using SistemaEscolar.Droid.Datos;
using SistemaEscolar.Datos;
using SistemaEscolar.Helpers;

[assembly: Dependency(typeof(BaseDatosAndroid))]
namespace SistemaEscolar.Droid.Datos
{
    public class BaseDatosAndroid : IBaseDatos
    {
        public string GetDatabasePath()
        {
            return Path.Combine(
                System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal),
                    Constantes.NombreBD);
        }
    }
}