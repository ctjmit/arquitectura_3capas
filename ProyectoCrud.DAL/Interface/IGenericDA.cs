using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MU = ProyectoCrud.DAL.Models;

namespace ProyectoCrud.DAL.Interface
{
    public interface IGenericDA
    {
        Task<List<MU::Usuario>> GetUsuarios();
        Task<MU::Usuario> GetUsuariosbyid(int id);
        Task<string> Guardar(MU::Usuario usuario);
        Task<string> Eliminar(int id);
    }
}
