using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///Remedio-> hereda de producto
    ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
    public class Remedio : Producto
    {
        //CONSTRUCTOR
        public Remedio(string marca, string tipo, int codigo, double precio) : base(marca, tipo, codigo, precio)
        {

        }


        //POLIMORFISMO
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
