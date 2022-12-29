﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MU = ProyectoCrud.DAL.Models;

namespace ProyectoCrud.BL.Interface
{
    public interface IUsuarioBL
    {
        Task<List<MU::Usuario>> GetUsuarios();
        Task<MU::Usuario> GetUsuariosbyid(int id);
        Task<string> Guardar(MU::Usuario usuario);
        Task<string> Eliminar(int id);
    }
}
