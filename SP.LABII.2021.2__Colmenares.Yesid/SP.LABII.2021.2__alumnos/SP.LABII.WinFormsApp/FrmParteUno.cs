using System;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using EntidadesSP;

namespace SP.LABII.WinFormsApp
{
    public delegate void MostrarLstVisor();
    ///Agregar manejo de excepciones en TODOS los lugares críticos!!!
    public partial class FrmParteUno : Form
    {
        private Zapato zapato;
        private Fosforo fosforo;
        private Remedio remedio;

        private Caja<Zapato> c_zapatos;
        private Caja<Fosforo> c_fosforos;
        private Caja<Remedio> c_remedios;

        public FrmParteUno()
        {
            InitializeComponent();

            this.Text = "Colmenares Yesid";
            MessageBox.Show(this.Text);

            ///Agregar 'dinámicamente' los manejadores de eventos a los 
            ///eventos 'Click' de los botones btnPunto1, btnPunto2, btnPunto3, btnPunto4 y btnPunto5
            this.btnPunto1.Click += new EventHandler(this.btnPunto1_Click);
            this.btnPunto2.Click += new EventHandler(this.btnPunto2_Click);
            this.btnPunto3.Click += new EventHandler(this.btnPunto3_Click);
            this.btnPunto4.Click += new EventHandler(this.btnPunto4_Click);
            this.btnPunto5.Click += new EventHandler(this.btnPunto5_Click);

        }

        ///Crear, en un proyecto de tipo class library (EntidadesSP), las siguientes clases:
        ///Producto:
        ///atributos protegidos: marca:string, tipo:string, codigo:int, precio:double 
        ///propiedes públicas de lectura y escritura para todos sus atributos.
        ///contructor con 4 parámetros.
        ///Sobrescritura del método ToString, mostrando todos sus atributos.
        ///Zapato->hereda de producto 
        ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
        ///Fosforo-> hereda de producto 
        ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
        ///Remedio-> hereda de producto
        ///ToString():string (polimorfismo; reutilizar código) (mostrar TODOS los valores).
        private void btnPunto1_Click(object sender, EventArgs e)
        {
            ///Crear una instancia de cada clase e inicializar los atributos del form zapato, fosforo y remedio. 
            this.zapato = new Zapato("Náutico", "Kickers", 1, 500);
            this.fosforo = new Fosforo("Madera", "3 patitos", 2, 65);
            this.remedio = new Remedio("Aspirina", "Bayer", 3, 100);

            MessageBox.Show(this.zapato.ToString());
            MessageBox.Show(this.fosforo.ToString());
            MessageBox.Show(this.remedio.ToString());
        }

        ///Crear, en EntidadesSP, la clase Caja<T>, dónde T sea de tipo Zapato, Fósforo o Remedio.
        ///atributos: capacidad:int y elementos:List<T> (TODOS protegidos)        
        ///Propiedades:
        ///Elementos:(sólo lectura) expone al atributo de tipo List<T>.
        ///PrecioTotal:(sólo lectura) retorna el precio total de la caja (la suma de los precios de sus elementos).
        ///Constructor
        ///Caja(), Caja(int); 
        ///El constructor por default es el único que se encargará de inicializar la lista.
        ///Métodos:
        ///ToString: Mostrará en formato de tipo string: 
        ///.-el tipo de caja, la capacidad, la cantidad actual de elementos, el precio total y el listado completo 
        ///de todos los elementos contenidos en la misma. Reutilizar código.
        ///Sobrecarga de operadores:
        ///(+) Será el encargado de agregar elementos a la caja, 
        ///siempre y cuando no supere la capacidad máxima de la misma.
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            this.c_zapatos = new Caja<Zapato>(3);
            this.c_fosforos = new Caja<Fosforo>(3);
            this.c_remedios = new Caja<Remedio>(2);

            this.c_zapatos += new Zapato("Mocasín", "Moscato", 4, 850); 
            this.c_zapatos += new Zapato("Charol", "Carlota", 5, 600); 
            this.c_zapatos += this.zapato;

            this.c_fosforos += this.fosforo;
            this.c_fosforos += new Fosforo("Cera", "Cerúmen", 6, 50);

            this.c_remedios += this.remedio;
            this.c_remedios += this.remedio;

            MessageBox.Show(this.c_zapatos.ToString());
            MessageBox.Show(this.c_fosforos.ToString());
            MessageBox.Show(this.c_remedios.ToString());

        }

        ///Agregar un elemento a la caja de zapatos, al superar la cantidad máxima, 
        ///lanzará un CajaLlenaException (diseñarla), cuyo mensaje explicará lo sucedido.
        private void btnPunto3_Click(object sender, EventArgs e)
        {
            try
            {
                this.c_zapatos += this.zapato;
            }
            catch (CajaLlenaException ex)
            {
                ///Agregar, para la clase CajaLlenaException, un método de extensión (InformarNovedad():string)
                ///que retorne el mensaje de error
                MessageBox.Show(ex.InformarNovedad());
            }
        }

        ///Si el precio total de la caja supera los 999 pesos, se disparará el evento EventoPrecio. 
        ///Diseñarlo (de acuerdo a las convenciones vistas) en la clase caja. 
        ///Adaptar la sobrecarga del operador +, para que lance el evento, según lo solicitado.
        ///Crear el manejador necesario para que, una vez capturado el evento, se imprima en un archivo de texto: 
        ///la fecha (con hora, minutos y segundos) y el total de la caja (en un nuevo renglón). 
        ///Se deben acumular los mensajes. 
        ///El archivo se guardará con el nombre 'facturas.log' en la carpeta 'Mis documentos' del cliente.
        ///El manejador de eventos (Caja_EventoPrecio) invocará al método (de clase) 
        ///ImprimirFactura(Caja<T>) (se alojará en la clase Facturadora<T>), que retorna un booleano 
        ///indicando si se pudo escribir o no.
        ///la clase Facturadora<T> sólo podrá 'facturar' Zapatos, Fósforos o Remedios.
        private void btnPunto4_Click(object sender, EventArgs e)
        {
            try
            {
                ///Asociar 'dinámicamente' el manejador de eventos (Caja_EventoPrecio) aquí  
                this.c_fosforos.EventoPrecio += new EventoPrecio(Caja_EventoPrecio);

                this.c_fosforos += new Fosforo("Madera", "Fragata", 7, 900);
            }
            catch (CajaLlenaException ex)
            {
                MessageBox.Show(ex.InformarNovedad());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Caja_EventoPrecio(object sender, EventArgs e)
        {
            bool todoOK = Facturadora<Fosforo>.ImprimirFactura(this.c_fosforos);///Reemplazar por la llamada al método de clase ImprimirFactura

            if (todoOK)
            {
                MessageBox.Show("Factura impresa correctamente!!!");
            }
            else
            {
                MessageBox.Show("No se pudo imprimir la factura!!!");
            }
        }

        ///Crear las interfaces (en class library): 
        ///#.-ISerializa -> Xml() : bool
        ///              -> Path{ get; } : string
        ///#.-IDeserializa -> Xml(out zapato) : bool
        ///Implementar (implícitamente) ISerializa zapato
        ///Implementar (explícitamente) IDeserializa en zapato
        ///El archivo .xml guardarlo en el escritorio del cliente, con el nombre formado con su apellido.nombre.zapato.xml
        ///Ejemplo: Alumno Juan Pérez -> perez.juan.zapato.xml
        ///Adaptar las clases que crea conveniente.
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            Zapato aux = null;

            if (this.zapato.Xml())
            {
                MessageBox.Show("Zapato serializado OK");
            }
            else
            {
                MessageBox.Show("Zapato NO serializado");
            }

            if (((IDeserializa)this.zapato).Xml(out aux))
            {
                MessageBox.Show("Zapato deserializado OK");
                MessageBox.Show(aux.ToString());
            }
            else
            {
                MessageBox.Show("Zapato NO deserializado");
            }
        }

        ///Configurar el OpenFileDialog, para poder seleccionar el log de facturas
        private void btnVerLog_Click(object sender, EventArgs e)
        {
            ///titulo -> 'Abrir archivo de facturas'
            ///directorio por defecto -> Mis documentos
            ///tipo de archivo (filtro) -> .log
            ///extensión por defecto -> .log
            ///nombre de archivo (defecto) -> facturas

            this.openFileDialog1.Title = "Abrir archivo de facturas";
            this.openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            this.openFileDialog1.Filter = "XML Files(*.txt)| *.txt;";
            this.openFileDialog1.DefaultExt = ".log";
            this.openFileDialog1.FileName = "facturas";

            DialogResult rta = this.openFileDialog1.ShowDialog();///Reemplazar por la llamada al método correspondiente del OpenFileDialog

            if (rta == DialogResult.OK)
            {
                ///leer el archivo seleccionado por el cliente y mostrarlo en lstVisor

                string facturas = this.LeerArchivo(openFileDialog1.FileName);

                if (facturas is not null)
                {
                    this.lstVisor.Items.Clear();
                    this.lstVisor.Items.Add(facturas);
                }
            }
        }

        private string LeerArchivo(string path)
        {
            string facturas;

            try
            {
                using (StreamReader w = new StreamReader(path))
                {
                    facturas = w.ReadToEnd();
                }
            }
            catch (Exception)
            {
                facturas = null;
            }
            return facturas;
        }

        ///Iniciar una nueva tarea en segundo plano (hilo) que muestre en lstVisor el contenido
        ///de los objetos this.fosforo, this.remedio y this.zapato
        ///agregando un retardo de 3 segundos.
        private void btnHilos_Click(object sender, EventArgs e)
        {
            Task hilo = new Task(this.MostrarLstVisor);///generar la tarea en segundo plano

            hilo.Start();
        }

        private void MostrarLstVisor()
        {
            if (this.InvokeRequired)
            {
                MostrarLstVisor mostrar = new MostrarLstVisor(this.MostrarLstVisor);
                this.Invoke(mostrar);
            }
            else
            {
                this.lstVisor.Items.Add(this.fosforo.ToString());
                this.lstVisor.Items.Add(this.remedio.ToString());
                this.lstVisor.Items.Add(this.zapato.ToString());
                Thread.Sleep(3000);
            }
        }
    }
}
