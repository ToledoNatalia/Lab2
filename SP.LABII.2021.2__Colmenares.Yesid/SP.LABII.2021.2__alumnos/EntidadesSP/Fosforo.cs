using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///Fosforo-> hereda de producto 
    ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
    public class Fosforo : Producto
    {
        //CONSTRUCTOR
        public Fosforo(string marca, string tipo, int codigo, double precio) : base(marca, tipo, codigo, precio)
        {

        }


        //POLIMORFISMO
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
