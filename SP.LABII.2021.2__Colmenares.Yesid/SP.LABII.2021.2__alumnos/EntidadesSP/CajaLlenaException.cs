using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    public class CajaLlenaException : Exception
    {
        public CajaLlenaException() : base("Error, la caja de elementos esta llena")
        {

        }
    }
}
