using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace EntidadesSP
{
    ///Zapato->hereda de producto 
    ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
    public class Zapato : Producto, ISerializa, IDeserializa
    {
        //CONSTRUCTOR
        public Zapato()
        {

        }
        public Zapato(string marca, string tipo, int codigo, double precio) : base(marca, tipo, codigo, precio)
        {

        }


        //IMPLEMENTACION INTERFAZ
        public bool Xml()
        {
            bool valor = true;

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(this.Path, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Zapato));

                    serializer.Serialize(writer, this);
                }
            }
            catch (Exception e)
            {
                valor = false;
            }

            return valor;
        }
        bool IDeserializa.Xml(out Zapato z)
        {
            bool valor = true;
            z = null;

            try
            {
                using (XmlTextReader reader = new XmlTextReader(this.Path))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Zapato));

                    z = (Zapato)serializer.Deserialize(reader);
                }
            }
            catch (Exception)
            {
                valor = false;
            }

            return valor;
        }


        //POLIMORFISMO
        public override string ToString()
        {
            return base.ToString();
        }


        //PROPIEDADES
        public string Path
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\colmenares.yesid.zapato.xml";
            }
        }
    }
}
