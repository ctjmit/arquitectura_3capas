using ProyectoCrud.BL.Interface;
using ProyectoCrud.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCrud.DAL;
using MU = ProyectoCrud.DAL.Models;
using ProyectoCrud.DAL.Models;

namespace ProyectoCrud.BL
{
    public class UsuarioBL : IUsuarioBL
    {
        private readonly IGenericDA genericDA;
        public UsuarioBL(IGenericDA usuario)
        {
            this.genericDA = usuario;
        }

        public async Task<List<MU::Usuario>> GetUsuarios()
        {
            return await this.genericDA.GetUsuarios();
        }
        public async Task<MU::Usuario> GetUsuariosbyid(int id)
        {
            return await this.genericDA.GetUsuariosbyid(id);
        }
        public async Task<string> Guardar(MU::Usuario usuario)
        {
            return await this.genericDA.Guardar(usuario);
        }

        public async Task<string> Eliminar(int id)
        {
            return await this.genericDA.Eliminar(id);
        }
    }
}
