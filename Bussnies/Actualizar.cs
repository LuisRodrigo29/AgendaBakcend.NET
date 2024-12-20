using Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussnies
{
    public class Actualizar: IActualizar
    {
        Data.Actualizar _actualizar = new Data.Actualizar();
        public DataTable ActualizarTurno(string operacion, string cedula,  string nombre, string fechaTurno, string idSucursal, string descripcion, string idTurno)
        {
            DataTable tblResult = _actualizar.ActualizarTurno(operacion, cedula, nombre, fechaTurno, idSucursal, descripcion, idTurno);
            return tblResult;
        
        }

        public DataTable ActualizarVigenciaTurnos()
        {
            DataTable tblResult = _actualizar.ActualizarVigenciaTurnos();
            return tblResult;
        }
    }
}
