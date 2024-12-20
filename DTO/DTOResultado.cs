using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOResultado
    {
        public string resultado { get; set; }

        public DTOResultado() { }

        public DTOResultado(string resultado)
        {
            this.resultado = resultado;
        }
    }
}
