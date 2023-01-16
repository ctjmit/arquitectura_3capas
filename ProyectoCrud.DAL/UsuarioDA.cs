using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task< List<MU::Usuario>> GetUsuarios()
        {
            var _data = await this.pruebaContext.Usuarios.ToListAsync();
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

        public async Task<MU::Usuario> GetUsuariosbyid(int id)
        {
            var _data = await this.pruebaContext.Usuarios.FirstOrDefaultAsync(item => item.Id == id);
            MU::Usuario usuarios = new MU::Usuario();
            if (_data != null)
            {
                
                    usuarios=(new MU.Usuario()
                    {
                        Id = _data.Id,
                        Nombre = _data.Nombre,
                        Edad = _data.Edad,
                        Email = _data.Email,
                        Salario = _data.Salario,
                        Fecha = _data.Fecha,
                    }); 
            }
            return usuarios;
        }

        public async Task<string> Guardar(MU::Usuario usuario)
        {
            string Response = string.Empty;
            try
            {
                if(usuario.Id > 0)
                {
                    var _exist = await this.pruebaContext.Usuarios.FirstOrDefaultAsync(item => item.Id == usuario.Id);
                    if (_exist != null)
                    {
                        _exist.Nombre= usuario.Nombre;
                        _exist.Edad= usuario.Edad;
                        _exist.Email= usuario.Email;
                        _exist.Salario= usuario.Salario;
                        _exist.Fecha= usuario.Fecha;
                    }
                }
                else
                {
                    //se crea un objeto de la clase usuario
                    Usuario _usuario = new Usuario()
                    {
                        Nombre = usuario.Nombre,
                        Edad = usuario.Edad,
                        Email = usuario.Email,
                        Salario = usuario.Salario,
                        Fecha = usuario.Fecha,
                    };
                    await this.pruebaContext.Usuarios.AddAsync(_usuario);
                }
                await this.pruebaContext.SaveChangesAsync();
                Response = "pass";

            }
            catch(Exception ex)
            {
                Response = ex.Message;
            }

            return Response;
        }

        public async Task<string> Eliminar(int id)
        {
            var _data = await this.pruebaContext.Usuarios.FirstOrDefaultAsync(item => item.Id == id);
            string Response = string.Empty;
            if (_data != null)
            {
                try
                {
                    this.pruebaContext.Usuarios.Remove(_data);
                    await this.pruebaContext.SaveChangesAsync();
                    Response = "pass";
                }
                catch(Exception ex)
                {
                    Response = ex.Message;
                }
            }
            return Response;
        }
    }
}
