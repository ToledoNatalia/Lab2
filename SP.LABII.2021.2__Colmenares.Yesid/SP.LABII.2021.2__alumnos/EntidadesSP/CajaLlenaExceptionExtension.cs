using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    public static class CajaLlenaExceptionExtension
    {
        public static string InformarNovedad(this CajaLlenaException e)
        {
            CajaLlenaException a = new CajaLlenaException();

            return a.Message;
        }
    }
}
