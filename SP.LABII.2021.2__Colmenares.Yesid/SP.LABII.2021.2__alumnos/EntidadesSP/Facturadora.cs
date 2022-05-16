using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///Crear el manejador necesario para que, una vez capturado el evento, se imprima en un archivo de texto: 
    ///la fecha (con hora, minutos y segundos) y el total de la caja (en un nuevo renglón). 
    ///Se deben acumular los mensajes. >>> true
    ///El archivo se guardará con el nombre 'facturas.log' en la carpeta 'Mis documentos' del cliente.
    ///El manejador de eventos (Caja_EventoPrecio) invocará al método (de clase) 
    ///ImprimirFactura(Caja<T>) (se alojará en la clase Facturadora<T>), que retorna un booleano 
    ///indicando si se pudo escribir o no.
    ///la clase Facturadora<T> sólo podrá 'facturar' Zapatos, Fósforos o Remedios.
    public class Facturadora<T>
        where T : Producto
    {

        public static bool ImprimirFactura(Caja<T> c)
        {
            bool valor = true;

            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\facturas.log";

                using (StreamWriter w = new StreamWriter(path, true))
                {
                    w.WriteLine(DateTime.Now.Millisecond);
                    w.WriteLine("------------------------------------");
                    w.WriteLine($"Precio total de la caja: {c.PrecioTotal}");
                }
            }
            catch (Exception)
            {
                valor = false;
            }
            return valor;
        }
    }
}
