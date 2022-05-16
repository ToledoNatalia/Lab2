using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesSP
{
    ///ObtenerTodos(string) : List<Producto> -> se obtienen por marca
    ///
    public delegate void MarcaExistente(object sender, EventArgs e);

    public class ADO
    {
        //ATRIBUTOS
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader reader;

        //EVENTO
        public event MarcaExistente MarcaExistente;

        public static List<Producto> ObtenerTodos()
        {
            SqlConnection connection;
            SqlCommand command;
            SqlDataReader reader;

            List<Producto> l = null;

            try
            {
                using (connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=almacen_db;Trusted_Connection=True;"))
                {
                    command = new SqlCommand($"SELECT * FROM productos", connection);

                    connection.Open();

                    reader = command.ExecuteReader();

                    l = new List<Producto>();

                    while (reader.Read())
                    {
                        l.Add(new Producto((string)reader["marca"], (string)reader["tipo"], int.Parse(reader["codigo"].ToString()), int.Parse(reader["precio"].ToString())));
                    }

                    reader.Close();
                }
            }
            catch (Exception)
            {
            }
            return l;
        }
        public static List<Producto> ObtenerTodos(string marca)
        {
            return new List<Producto>();
        }

        public bool Agregar(Producto e)
        {
            bool valor = true;

            try
            {
                using (this.connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=almacen_db;Trusted_Connection=True;"))
                {
                    string queryString = $"INSERT INTO productos (marca, tipo, codigo, precio) VALUES('{e.Marca}', '{e.Tipo}', {e.Codigo}, {e.Precio})";

                    this.command = new SqlCommand(queryString, this.connection);

                    this.connection.Open();

                    if (this.command.ExecuteNonQuery() == 0)
                    {
                        valor = false;
                    }
                }

            }
            catch (Exception)
            {
                valor = false;
            }

            return valor;
        }
        public bool Modificar(Producto e)
        {
            bool valor = true;
            try
            {
                using (this.connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=almacen_db;Trusted_Connection=True;"))
                {
                    this.command = new SqlCommand();

                    this.command.Parameters.AddWithValue("@Marca", e.Marca);
                    this.command.Parameters.AddWithValue("@Tipo", e.Tipo);
                    this.command.Parameters.AddWithValue("@Codigo", e.Codigo);
                    this.command.Parameters.AddWithValue("@Precio", e.Precio);

                    this.command.Connection = this.connection;
                    this.command.CommandType = CommandType.Text;
                    this.command.CommandText = $"UPDATE productos SET marca = @Marca, tipo = @Tipo, precio = @Precio WHERE codigo = @Codigo";

                    this.connection.Open();

                    if (this.command.ExecuteNonQuery() == 0)
                    {
                        valor = false;
                    }
                }
            }
            catch (Exception)
            {
                valor = false;
            }

            return valor;
        }
        public bool Eliminar(Producto e)
        {
            bool valor = true;

            try
            {
                using (this.connection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=almacen_db;Trusted_Connection=True;"))
                {
                    this.command = new SqlCommand($"DELETE FROM productos WHERE codigo = {e.Codigo}", this.connection);

                    this.connection.Open();

                    if (this.command.ExecuteNonQuery() == 0)
                    {
                        valor = false;
                    }
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
