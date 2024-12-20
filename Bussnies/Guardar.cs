using Data;
using Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussnies
{
    public class Guardar: IGuardar
    {
        Data.Guardar _guardar = new Data.Guardar();
        public DataTable GuardarTurno(string operacion, string cedula, string nombre, string fechaTurno, string idSucursal, string descripcion, string idTurno)
        {
            DataTable tblResult = _guardar.GuardarTurno(operacion, cedula, nombre, fechaTurno, idSucursal, descripcion, idTurno);
            return tblResult;
        }
    }
}
