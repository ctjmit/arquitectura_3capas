using ProyectoCrud.DAL.Models;
using ProyectoCrud.DAL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BL.Services
{
    public class UsuarioService : IUsuarioService
    {
        //accederemos a los metodos creados en el repositorio
        private readonly IRepositorioGeneric<Usuario> _RepoUser;
        //creamos el constructor
        public UsuarioService(IRepositorioGeneric<Usuario> RepoUser)
        {
            _RepoUser = RepoUser;
        }
        public async Task<bool> Actualizar(Usuario modelo)
        {
            return await _RepoUser.Actualizar(modelo); 
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _RepoUser.Eliminar(id);
        }

        public async Task<bool> Insertar(Usuario modelo)
        {
            return await _RepoUser.Insertar(modelo);
        }

        public async Task<Usuario> Obtener(int id)
        {
            return await _RepoUser.Obtener(id);
        }

        public async Task<Usuario> ObtenerPorNombre(String nombreUsuario)
        {
            IQueryable<Usuario> queryUsuarioSQL = await _RepoUser.ObtenerTodos();
            Usuario usuario = queryUsuarioSQL.Where(c => c.Nombre == nombreUsuario).FirstOrDefault();
            return usuario;
        }

        public async Task<IQueryable<Usuario>> ObtenerTodos()
        {
            return await _RepoUser.ObtenerTodos();
        }
    }
}
