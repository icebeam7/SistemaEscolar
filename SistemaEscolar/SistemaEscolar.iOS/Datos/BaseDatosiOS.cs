using System;
using System.IO;
using Xamarin.Forms;
using SistemaEscolar.iOS.Datos;
using SistemaEscolar.Datos;
using SistemaEscolar.Helpers;

[assembly: Dependency(typeof(BaseDatosiOS))]
namespace SistemaEscolar.iOS.Datos
{
    public class BaseDatosiOS : IBaseDatos
    {
        public string GetDatabasePath()
        {
            return Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments),
                "..",
                "Library",
                Constantes.NombreBD);
        }
    }
}