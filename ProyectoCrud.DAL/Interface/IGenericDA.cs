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
        List<MU::Usuario> GetUsuarios();
    }
}
