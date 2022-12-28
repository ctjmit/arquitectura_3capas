using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCrud.DAL.Interface;
using ProyectoCrud.DAL.Models;
using MU = ProyectoCrud.DAL.Models;


namespace ProyectoCrud.DAL
{
    public class UsuarioDA : IGenericDA
    {
        private readonly DbpruebaContext pruebaContext;
        public UsuarioDA(DbpruebaContext pruebaContext)
        {
            this.pruebaContext = pruebaContext;
        }

        public List<MU::Usuario> GetUsuarios()
        {
            var _data = this.pruebaContext.Usuarios.ToList();
            List<MU::Usuario> usuarios = new List<MU::Usuario>();
            if(_data !=null && _data.Count > 0)
            {
                _data.ForEach(item =>
                {
                    usuarios.Add(new MU.Usuario() 
                    { 
                        Id = item.Id,
                        Nombre= item.Nombre,
                        Edad= item.Edad,
                        Email= item.Email,
                        Salario= item.Salario,
                        Fecha= item.Fecha,
                    });
                });
            }
            return usuarios;
        }
    }
}
