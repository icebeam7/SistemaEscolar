using Xamarin.Forms;
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Modelos;

namespace SistemaEscolar.Datos
{
    public class BaseDatos : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }

        private readonly string rutaBD;

        public BaseDatos(string rutaBD)
        {
            this.rutaBD = rutaBD;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IBaseDatos>().GetDatabasePath();
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
