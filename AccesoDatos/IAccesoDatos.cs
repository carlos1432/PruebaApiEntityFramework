using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    interface IAccesoDatos
    {
        Task<IEnumerable<Producto>> GetEstudiantes();
        Task<IEnumerable<Producto>> GetEstudianteById(int id);
    }
}
