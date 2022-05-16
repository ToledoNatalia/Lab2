using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///El archivo .xml guardarlo en el escritorio del cliente, con el nombre formado con su apellido.nombre.zapato.xml
    ///Ejemplo: Alumno Juan Pérez -> perez.juan.zapato.xml
    ///Adaptar las clases que crea conveniente.
    public interface IDeserializa
    {
        bool Xml(out Zapato z);
    }
}
