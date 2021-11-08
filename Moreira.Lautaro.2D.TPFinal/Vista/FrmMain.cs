using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesHostel;
using VistaHostel;

namespace Vista
{
    
    public partial class FrmMain : Form
    {
        private Hostel hostel;
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/");
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            hostel = new Hostel("La roca");
            Text = $"{hostel.Nombre} HOSTEL";
            lblNombre.Text = hostel.Nombre;
            
            
            
            CargarEmpleados(path);
            CargarClientes(path);
            CargarHabitaciones(path);

            btnModificarCliente.Enabled = false;
            btnAgregarCliente.Enabled = false;
            btnEliminarCliente.Enabled = false;
            btnModificarEmpleado.Enabled = false;
            btnAgregarEmpleado.Enabled = false;
            btnEliminarEmpleado.Enabled = false;


        }
        private void btnHostel_Click(object sender, EventArgs e)
        {
            cbPersona.Visible = false;
            rtbInformacion.Text = hostel.MostrarInformacionHostel();
        }
        

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            AgregarEmpleado();
        }

        /// <summary>
        /// Agrega un empleado cargando los datos por un form
        /// </summary>
        public void AgregarEmpleado()
        {
            FrmAgregarModificarEmpleado frmAgregarModificarEmpleado = new FrmAgregarModificarEmpleado("Agregar empleado", "Agregar", null);
            frmAgregarModificarEmpleado.ShowDialog();

            if (frmAgregarModificarEmpleado.Objeto is not null && hostel.Empleados + frmAgregarModificarEmpleado.Objeto)
            {
                rtbInformacion.Text = frmAgregarModificarEmpleado.Objeto.MostrarInformacion();
                MessageBox.Show("Empleado agregado", "Empleado agregado", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else if (hostel.Empleados.Count == hostel.CapacidadMaximaEmpleados)
            {
                MessageBox.Show("El empleado no se pudo agregar ya que se supero la cantidad de empleados.", "Empleado no agregado.");
            }
        }


        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            ModificarEmpleado();
        }

        /// <summary>
        /// Modifica los valores del empleado seleccionado.
        /// </summary>
        private void ModificarEmpleado()
        {
            if (cbPersona.SelectedIndex != -1)
            {
                FrmAgregarModificarEmpleado frmAgregarModificarEmpleado =
                    new FrmAgregarModificarEmpleado("Modificar empleado", "Modificar empleado", (Empleado)cbPersona.SelectedItem);
                frmAgregarModificarEmpleado.ShowDialog();

                if (frmAgregarModificarEmpleado.DialogResult == DialogResult.OK)
                {
                    rtbInformacion.Text = ((Empleado)cbPersona.SelectedItem).MostrarInformacion();
                }


            }
        }

        private void btnMostrarInformacionEmpleado_Click(object sender, EventArgs e)
        {
            btnModificarCliente.Enabled = false;
            btnAgregarCliente.Enabled = false;
            btnEliminarCliente.Enabled = false;
            btnEliminarEmpleado.Enabled = true;
            btnAgregarEmpleado.Enabled = true;
            btnModificarEmpleado.Enabled = true;
            cbPersona.Visible = true;

            MostrarInformacionEmpleados();

        }

        /// <summary>
        /// Muestra la informacion de los empleados y te permite seleccionar un empleado para modificar
        /// </summary>
        private void MostrarInformacionEmpleados()
        {
            
            rtbInformacion.Text = hostel.Empleados.Mostrar();
            cbPersona.Items.Clear();

            foreach (Empleado empleado in hostel.Empleados.Lista)
            {
                cbPersona.Items.Add(empleado);
                cbPersona.SelectedIndex = 0;
            }
        }


        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            EliminarEmpleado();
        }

        /// <summary>
        /// Elimina el empleado seleccionado
        /// </summary>
        private void EliminarEmpleado()
        {
            if (cbPersona.SelectedIndex != -1)
            {
                try
                {
                    Empleado empleadoAEliminar = cbPersona.SelectedItem as Empleado;
                    DialogResult dialogResult = MessageBox.Show($"Esta seguro que desea eliminar a: {cbPersona.SelectedItem}?", "Eliminar empleado", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes && hostel.Empleados - empleadoAEliminar)
                    {
                        MessageBox.Show("Empleado eliminado.", "Eliminar empleado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        rtbInformacion.Text = hostel.Empleados.Mostrar();
                    }

                }
                catch (PersonaException ex)
                {
                    Log.Guardar(ex);

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado a despedir.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// Carga los empleados desde un xml
        /// </summary>
        /// <param name="path">ruta donde se encuentra la carpeta de archivos</param>
        private void CargarEmpleados(string path)
        {
            try
            {

                string ruta = Path.Combine(path, "Empleados.Xml");
                Xml<Personas<Empleado>> xml = new Xml<Personas<Empleado>>();

                hostel.Empleados = xml.Deserializar(ruta);

            }
            catch (DirectoryNotFoundException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
            catch(Exception ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }

        }
       

        private void btnMostrarInformacionCliente_Click(object sender, EventArgs e)
        {
            btnEliminarEmpleado.Enabled = false;    
            btnAgregarEmpleado.Enabled = false;    
            btnModificarEmpleado.Enabled = false;
            btnModificarCliente.Enabled = true;
            btnAgregarCliente.Enabled = true;
            btnModificarCliente.Enabled = true;
            btnEliminarCliente.Enabled = true;
            cbPersona.Visible = true;

            MostrarInformacionClientes();
        }

        /// <summary>
        /// Te muestra la informacion de los clientes y te permite seleccionar uno para eliminar o modificar
        /// </summary>
        private void MostrarInformacionClientes()
        {

            rtbInformacion.Text = hostel.Clientes.Mostrar();
            cbPersona.Items.Clear();

            foreach (Cliente cliente in hostel.Clientes.Lista)
            {
                cbPersona.Items.Add(cliente);
                cbPersona.SelectedIndex = 0;
            }
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {

            ModificarCLiente();
        }

        /// <summary>
        /// abre el formulario que permite modificar el cliente seleccionado
        /// </summary>
        private void ModificarCLiente()
        {
            if (cbPersona.SelectedIndex != -1)
            {
                FrmAgregarModificarCliente frmAgregarModificarCliente = new FrmAgregarModificarCliente("Modificar Cliente", "Modificar cliente", (Cliente)cbPersona.SelectedItem);
                frmAgregarModificarCliente.ShowDialog();

                if (frmAgregarModificarCliente.DialogResult == DialogResult.OK)
                {
                    rtbInformacion.Text = ((Cliente)cbPersona.SelectedItem).MostrarInformacion();
                }
            }

        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            AgregarCliente();            
        }

        /// <summary>
        /// Abre el form que te permite agregar un cliente a la lista de clientes
        /// </summary>
        private void AgregarCliente()
        {
            FrmAgregarModificarCliente frmAgregarModificarCliente = new FrmAgregarModificarCliente("Agregar cliente", "Agregar", null);
            frmAgregarModificarCliente.ShowDialog();

            try
            {
                if (frmAgregarModificarCliente.Objeto is not null && hostel.Clientes + frmAgregarModificarCliente.Objeto)
                {
                    rtbInformacion.Text = frmAgregarModificarCliente.Objeto.MostrarInformacion();
                    MessageBox.Show("Cliente agregado", "Cliente agregado", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
            }
            catch (PersonaException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Guarda la lista de los empleados serializados en xml
        /// </summary>
        /// <param name="path">la ruta donde se encuentram los empleados</param>
        private void GuardarEmpleados(string path)
        {
            try
            {
                string ruta = Path.Combine(path, "Empleados.Xml");

                Xml<Personas<Empleado>> xml = new Xml<Personas<Empleado>>();
                xml.Serializar(ruta, hostel.Empleados);
            }
            catch (DirectoryNotFoundException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }

        }

        /// <summary>
        /// Carga los clientes desde un archivo xml
        /// </summary>
        /// <param name="path">ruta donde se encuentra el archivo xml</param>
        private void CargarClientes(string path)
        {
            try
            {
                string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                ruta = Path.Combine(path, "Clientes.Xml");

                Xml<Personas<Cliente>> xml= new Xml<Personas<Cliente>>();

                hostel.Clientes = xml.Deserializar(ruta);

            }
            catch (DirectoryNotFoundException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }

        }

        /// <summary>
        /// Guarda la lista de clientes en un archivo xml
        /// </summary>
        /// <param name="path">ruta donde se encuentra el archivo</param>
        private void GuardarClientes(string path)
        {
            try
            {
                
                string ruta = Path.Combine(path, "Clientes.Xml");

                Xml<Personas<Cliente>> xml = new Xml<Personas<Cliente>>();

                xml.Serializar(ruta , hostel.Clientes);
            }
            catch (DirectoryNotFoundException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }


        }
        /// <summary>
        /// Carga las habitaciones desde un archivo json
        /// </summary>
        /// <param name="path">ruta donde se encuentra el archivo json</param>
        private void CargarHabitaciones(string path)
        {
            try
            {
                string ruta = Path.Combine(path, "Habitaciones.json");
                Json<List<Habitacion>> json = new Json<List<Habitacion>>();

                hostel.Habitaciones = json.Deserializar(ruta);

            }
            catch (DirectoryNotFoundException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }

        }
        
        /// <summary>
        /// Guarda la lista de habitaciones en un archivo json
        /// </summary>
        /// <param name="path">ruta donde se encuentran el archivo</param>
        private void GuardarHabitaciones(string path)
        {
            try
            {
                string ruta = Path.Combine(path, "Habitaciones.json");

                Json<List<Habitacion>> json = new Json<List<Habitacion>>();

                json.Serializar(ruta, hostel.Habitaciones);

            }
            catch (DirectoryNotFoundException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            EliminarCliente();
        }

        /// <summary>
        /// Elimina el cliente seleccionado
        /// </summary>
        private void EliminarCliente()
        {
            if (cbPersona.SelectedIndex != -1)
            {
                try
                {
                    Cliente clienteAEliminar = cbPersona.SelectedItem as Cliente;
                    DialogResult dialogResult = MessageBox.Show($"Esta seguro que desea eliminar a: {cbPersona.SelectedItem}?", "Eliminar cliente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes && hostel.Clientes - clienteAEliminar)
                    {
                        MessageBox.Show("Cliente eliminado.", "Cliente eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        rtbInformacion.Text = hostel.Clientes.Mostrar();
                    }

                }
                catch (PersonaException ex)
                {
                    Log.Guardar(ex);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un empleado a despedir.", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            MostrarLogs();
        }

        /// <summary>
        /// Muestra el log de errores en el cuadro de texto.
        /// </summary>
        private void MostrarLogs()
        {
            try
            {
                rtbInformacion.Text = Log.Leer();
            }
            catch (FileNotFoundException ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
            catch (DirectoryNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarClientes(path);
            GuardarEmpleados(path);
            GuardarHabitaciones(path);

            MessageBox.Show("Hasta luego" , "Cerrar" , MessageBoxButtons.OK , MessageBoxIcon.Information);
        }
    }
}
