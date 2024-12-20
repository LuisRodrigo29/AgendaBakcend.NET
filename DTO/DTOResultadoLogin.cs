using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTOResultadoLogin
    {
        public string Token { get; set; }

        public int state { get; set; }

        public DTOResultadoLogin(string token, int state)
        {
            Token = token;
            this.state = state;
        }

        public DTOResultadoLogin() { }
    }
}
