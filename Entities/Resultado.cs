using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Resultado<T>
    {
        public T resultado { get; set; }
        public List<T> resultadoLista { get; set; }
        public Resultado() { }
        public Resultado(T resultado)
        {
            this.resultado = resultado;
        }
    }
}
