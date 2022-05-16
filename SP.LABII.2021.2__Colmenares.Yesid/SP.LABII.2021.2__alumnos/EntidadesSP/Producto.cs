using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    public class Producto
    {
        //ATRIBUTOS
        protected string marca;
        protected string tipo;
        protected int codigo;
        protected double precio;


        //CONSTRUCTOR
        public Producto()
        {

        }
        public Producto(string marca, string tipo, int codigo, double precio)
        {
            this.Marca = marca;
            this.Tipo = tipo;
            this.Codigo = codigo;
            this.Precio = precio;
        }


        //POLIMORFISMO
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Marca: {this.Marca}");
            sb.AppendLine($"Tipo: {this.Tipo}");
            sb.AppendLine($"Codigo: {this.Marca}");
            sb.AppendLine($"Precio: {this.Precio}");

            return sb.ToString();
        }


        //PROPIEDADES
        public string Marca
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value;
            }
        }
        public string Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }
        public int Codigo
        {
            get
            {
                return this.codigo;
            }
            set
            {
                this.codigo = value;
            }
        }
        public double Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }
    }
}
