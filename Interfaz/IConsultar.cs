using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz
{
    public interface IConsultar
    {
        DataTable Login(string usuario, string contrasena);

        DataTable ObtenerTurnos();
        DataTable ObtenerTurnoXCedula(string operacion, string cedula, string nombre, string fecha_turno, string id_sucursal, string descripcion, string idTurno);
        DataTable ObtenerSucursales();
    }
}
