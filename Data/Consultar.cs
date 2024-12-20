using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Consultar
    {
        public DataTable Login(string usuario, string contrasena)
        {
            string Query = String.Format("exec dbo.sp_Login '{0}','{1}'", usuario, contrasena);
            DataTable tblResult = Conexion.Consultar(Query);
            return tblResult;
        }

        public DataTable ObtenerDatosUsuario(string usuario, string contrasena)
        {
            string Query = String.Format("exec dbo.sp_ObtenerDatosUsuario '{0}','{1}'", usuario, contrasena);
            DataTable tblResult = Conexion.Consultar(Query);
            return tblResult;
        }

        public DataTable ObtenerSucursales()
        {
            string Query = String.Format("exec [dbo].[sp_ObtenerSucursales]");
            DataTable tblResult = Conexion.Consultar(Query);
            return tblResult;
        }

        public DataTable ObtenerTuObtenerTurnoXCedularnos(string operacion, string cedula, string nombre, string fecha_turno, string id_sucursal, string descripcion, string idTurno)
        {
            string Query = String.Format("exec [dbo].[sp_GestionarTurnos] {0},'{1}', '{2}', '{3}', {4},'{5}', {6}", operacion, cedula, nombre, fecha_turno, id_sucursal, descripcion, idTurno);
            DataTable tblResult = Conexion.Consultar(Query);
            return tblResult;
        }

        public DataTable ObtenerTurnos()
        {
            string Query = String.Format("exec [dbo].[sp_GestionarTurnos] 4");
            DataTable tblResult = Conexion.Consultar(Query);
            return tblResult;
        }
    }
}
