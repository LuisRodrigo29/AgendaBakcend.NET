using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Actualizar
    {
        public DataTable ActualizarVigenciaTurnos()
        {
            string Query = String.Format("exec spActualizarTurnos");
            DataTable tblResult = Conexion.Consultar(Query);
            return tblResult;
        }

        public DataTable ActualizarTurno(string operacion, string cedula,  string nombre, string fechaTurno, string idSucursal, string descripcion, string idTurno)
        {
            string Query = String.Format("exec [dbo].[sp_GestionarTurnos] {0},'{1}', '{2}', '{3}', {4},'{5}', {6}", operacion, cedula, nombre, fechaTurno, idSucursal, descripcion, idTurno);
            DataTable tblResult = Conexion.Consultar(Query);
            return tblResult;
        }
    }
}
