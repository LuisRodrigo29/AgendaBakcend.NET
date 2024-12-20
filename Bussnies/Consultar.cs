using Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussnies
{
    public class Consultar :IConsultar
    {
        Data.Consultar _consultar = new Data.Consultar();
        public DataTable Login(string usuario, string contrasena)
        {
            DataTable tblResult = _consultar.Login(usuario, contrasena);
            return tblResult;
        }

        public DataTable ObtenerTurnos()
        {
            DataTable tblResult = _consultar.ObtenerTurnos();
            return tblResult;
        }

        public DataTable ObtenerTurnoXCedula(string operacion, string cedula, string nombre, string fecha_turno, string id_sucursal, string descripcion, string idTurno)
        {
            DataTable tblResult = _consultar.ObtenerTuObtenerTurnoXCedularnos(operacion, cedula, nombre, fecha_turno, id_sucursal, descripcion, idTurno);
            return tblResult;
        }

        public DataTable ObtenerSucursales()
        {
            DataTable tblResult = _consultar.ObtenerSucursales();
            return tblResult;
        }
    }
}
