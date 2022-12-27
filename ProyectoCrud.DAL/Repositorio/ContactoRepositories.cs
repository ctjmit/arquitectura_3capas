using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositorio
{
    //toda clase que haga una referencia a IRepositorioGeneric tendra que respetar todo el contrato
    public class ContactoRepositories : IRepositorioGeneric<Usuario>
    {
        //referenciamos la bd, agregamos el contexto DbcrudcoreContext 
        private readonly DbcrudcoreContext _dbcontext;

        //creando constructor
        public ContactoRepositories(DbcrudcoreContext context)
        {
            _dbcontext = context;  //_dbcontext recibe el valor por el constructor
        }
        public async Task<bool> Actualizar(Usuario modelo)
        {
            _dbcontext.Usuarios.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            //utilizamos un modelo de usuario con first accedomos al primero que encuentre(se declara c como un alias)
            Usuario modelo = _dbcontext.Usuarios.First(c => c.IdUser == id);
            _dbcontext.Usuarios.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Usuario modelo)
        {
            _dbcontext.Usuarios.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;    
        }

        public async Task<Usuario> Obtener(int id)
        {
            //retornamos un await, utilizamos el parametro que estamos llamando
            return await _dbcontext.Usuarios.FindAsync(id);
        }

        public async Task<IQueryable<Usuario>> ObtenerTodos()
        {
            //debilvemos la consulta
            IQueryable<Usuario> queryUsuarioSQL = _dbcontext.Usuarios;
            return queryUsuarioSQL;
        }
    }
}
