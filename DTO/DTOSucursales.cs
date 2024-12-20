using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOSucursales
    {
        public string id { get; set; }

        public string nombre { get; set; }

        public DTOSucursales() { }

        public DTOSucursales(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
