using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz
{
    public interface ISecurity
    {
        string GetToken(DataTable tblResult, string usuario, string contrasena);
    }
}
