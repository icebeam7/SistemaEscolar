using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Datos;
using SistemaEscolar.Helpers;

namespace SistemaEscolar.Servicios
{
    public class ServicioBaseDatos<T> : IServicioBaseDatos<T> where T : class
    {
        BaseDatos bd;

        public ServicioBaseDatos()
        {
            bd = App.BD;
        }

        public virtual async Task<List<T>> ObtenerTabla()
        {
            return await bd.Set<T>().ToListAsync();
        }

        public virtual async Task<T> BuscarPorId(int id)
        {
            return await bd.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> Agregar(T dato)
        {
            try
            {
                await bd.Set<T>().AddAsync(dato);
                await bd.SaveChangesAsync();
                return dato;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public virtual async Task<T> Actualizar(T dato)
        {
            bd.Set<T>().Update(dato);
            await bd.SaveChangesAsync();
            return dato;
        }

        public virtual async Task<bool> Eliminar(int id)
        {
            try
            {
                var entity = await BuscarPorId(id);
                bd.Set<T>().Remove(entity);
                await bd.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
