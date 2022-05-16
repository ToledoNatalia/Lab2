using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    //DELEGADO
    public delegate void EventoPrecio(object sender, EventArgs e);

    public class Caja<T>
        where T : Producto
    {
        //ATRIBUTOS
        protected List<T> elementos;
        protected int capacidad;


        //EVENTOS
        public event EventoPrecio EventoPrecio;


        //CONSTRUCTOR
        public Caja()
        {
            this.elementos = new List<T>();
        }
        public Caja(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }


        //METODOS
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Tipo caja: {typeof(T).Name}");
            sb.AppendLine($"Capacidad: {this.capacidad}");
            sb.AppendLine($"Cantidad elementos: {this.Elementos.Count}");
            sb.AppendLine($"Precio total : {this.PrecioTotal}");
            sb.AppendLine("Lista de elementos: ");

            foreach (Producto item in this.Elementos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }


        //SOBRECARGA DE OPERADORES
        public static Caja<T> operator +(Caja<T> c, T e)
        {
            if (c.capacidad > c.Elementos.Count)
            {
                c.Elementos.Add(e);
            }
            else
            {
                throw new CajaLlenaException();
            }

            return c;
        }


        //PROPIEDADES
        public List<T> Elementos
        {
            get
            {
                return this.elementos;
            }
        }
        public double PrecioTotal
        {
            get
            {
                double precioTotal = 0;

                foreach (Producto item in this.Elementos)
                {
                    precioTotal += item.Precio;
                }
                if (precioTotal > 999 && this.EventoPrecio is not null)
                {
                    this.EventoPrecio.Invoke(this, EventArgs.Empty);
                }
                return precioTotal;
            }
        }

    }
}
