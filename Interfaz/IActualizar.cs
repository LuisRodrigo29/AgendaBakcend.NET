using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz
{
    public interface IActualizar
    {
        DataTable ActualizarTurno(string operacion, string cedula, string nombre, string fechaTurno, string idSucursal, string descripcion, string idTurno);

        DataTable ActualizarVigenciaTurnos();
    }
}
