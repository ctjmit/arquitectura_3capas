using ProyectoCrud.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BL.Services
{
    public interface IUsuarioService
    {
        Task<bool> Insertar(Usuario modelo);
        Task<bool> Actualizar(Usuario modelo);
        Task<bool> Eliminar(int id);
        Task<Usuario> Obtener(int id);
        Task<IQueryable<Usuario>> ObtenerTodos();

        Task<Usuario> ObtenerPorNombre(String nombreUsuario);
    }
}
