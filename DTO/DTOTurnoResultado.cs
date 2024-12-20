using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOTurnoResultado
    {
        public string nombre { get; set; }

        public string cedula { get; set; }
        public string fechaTurno { get; set; }
        public string fechaCorta { get; set; }

        public string descripcion { get; set; }
        public string sucursal { get; set; }

        public string turno { get; set; }

        public string idTurno { get; set; }

        public DTOTurnoResultado() { }

        public DTOTurnoResultado(string nombre, string cedula, string fechaTurno, string fechaCorta, string descripcion, string sucursal, string turno, string idTurno)
        {
            this.nombre = nombre;
            this.cedula = cedula;
            this.fechaTurno = fechaTurno;
            this.fechaCorta = fechaCorta;
            this.descripcion = descripcion;
            this.sucursal = sucursal;
            this.turno = turno;
            this.idTurno = idTurno;
        }
    }
}
