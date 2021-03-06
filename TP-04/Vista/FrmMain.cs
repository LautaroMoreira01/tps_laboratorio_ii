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
    public delegate void EncuestarCliente(Cliente cliente);
    
    public partial class FrmMain : Form
    {
        private Hostel hostel;
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/");
        
        public EncuestarCliente delegadoEncuestar;
        public event EncuestarCliente notificarClienteEncuestado;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

            hostel = new Hostel("La roca");
            Text = $"{hostel.Nombre} HOSTEL";
            lblNombre.Text = hostel.Nombre;
            
            CargarEmpleados();
            CargarClientes(path);
            CargarHabitaciones(path);

            btnModificarCliente.Enabled = false;
            btnAgregarCliente.Enabled = false;
            btnEliminarCliente.Enabled = false;
            btnModificarEmpleado.Enabled = false;
            btnAgregarEmpleado.Enabled = false;
            btnEliminarEmpleado.Enabled = false;
            rtbInformacion.Visible = false;
        }
        private void btnHostel_Click(object sender, EventArgs e)
        {
            dgvPersonas.Visible = false;
            rtbInformacion.Visible = true;
            btnModificarCliente.Enabled = false;
            btnAgregarCliente.Enabled = false;
            btnEliminarCliente.Enabled = false;
            btnModificarEmpleado.Enabled = false;
            btnAgregarEmpleado.Enabled = false;
            btnEliminarEmpleado.Enabled = false;
            rtbInformacion.Visible = true;


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

            try
            {
                FrmAgregarModificarEmpleado frmAgregarModificarEmpleado = new FrmAgregarModificarEmpleado("Agregar empleado", "Agregar", null);
                frmAgregarModificarEmpleado.ShowDialog();

                if (frmAgregarModificarEmpleado.Objeto is not null && hostel.Empleados.Count < hostel.Empleados.CapacidadMaxima && frmAgregarModificarEmpleado.DialogResult == DialogResult.OK)
                {
                    bool pudoAgregar = hostel.Empleados + frmAgregarModificarEmpleado.Objeto;
                    EmpleadoDao.Guardar(frmAgregarModificarEmpleado.Objeto);
                    MessageBox.Show("Empleado agregado", "Empleado agregado", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }
                ActualizarDGVEmpleado(hostel.Empleados);
            }
            catch (PersonaException ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Empleado empleado;
            try
            {
                if (dgvPersonas.SelectedRows.Count >= 0)
                {
                    empleado = (Empleado)dgvPersonas.CurrentRow.DataBoundItem;

                    FrmAgregarModificarEmpleado frmAgregarModificarEmpleado =
                        new FrmAgregarModificarEmpleado("Modificar empleado", "Modificar empleado", empleado);

                    frmAgregarModificarEmpleado.ShowDialog();

                    if (frmAgregarModificarEmpleado.DialogResult != DialogResult.Cancel)
                    {
                        EmpleadoDao.ActualizarEmpleado(empleado);
                        

                        MessageBox.Show("Empleado modificado", "Empleado modificado", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    }
                    
                    CargarEmpleados();
                    ActualizarDGVEmpleado(hostel.Empleados);
                }
            }
            catch (Exception ex )
            {
                Log.Guardar(ex);

                MessageBox.Show("Debe seleccionar un empleado para modificarlo.");
            }
           

        }

        /// <summary>
        /// Elimina el empleado seleccionado
        /// </summary>
        private void EliminarEmpleado()
        {
            if (dgvPersonas.SelectedRows.Count >= 0)
            {
                try
                {
                    Empleado empleadoAEliminar = (Empleado)dgvPersonas.CurrentRow.DataBoundItem;
                    DialogResult dialogResult = MessageBox.Show($"Esta seguro que desea eliminar a: {empleadoAEliminar.ToString()}?", "Eliminar empleado", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                    {
                        EmpleadoDao.EliminarEmpleado(empleadoAEliminar);
                        MessageBox.Show("Empleado eliminado.", "Eliminar empleado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    CargarEmpleados();
                    ActualizarDGVEmpleado(hostel.Empleados);


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

        private void btnMostrarInformacionEmpleado_Click(object sender, EventArgs e)
        {

            MostrarInformacionEmpleados();
            
        }

        /// <summary>
        /// Muestra la informacion de los empleados y te permite seleccionar un empleado para modificar
        /// </summary>
        private void MostrarInformacionEmpleados()
        {
            rtbInformacion.Visible = false;
            btnModificarCliente.Enabled = false;
            btnAgregarCliente.Enabled = false;
            btnEliminarCliente.Enabled = false;
            btnEliminarEmpleado.Enabled = true;
            btnAgregarEmpleado.Enabled = true;
            btnModificarEmpleado.Enabled = true;
            
            dgvPersonas.Visible = true;
            rtbInformacion.Visible = false;

            ActualizarDGVEmpleado(EmpleadoDao.Leer());
        }


        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            EliminarEmpleado();
        }



        /// <summary>
        /// Carga los empleados desde una base de datos
        /// </summary>
        /// <param name="path">ruta donde se encuentra la carpeta de archivos</param>
        private void CargarEmpleados()
        {
            try
            {

                hostel.Empleados = EmpleadoDao.Leer();

            }
            catch(Exception ex)
            {
                Log.Guardar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }
       

        private void btnMostrarInformacionCliente_Click(object sender, EventArgs e)
        {
            MostrarInformacionClientes();
        }

        /// <summary>
        /// Te muestra la informacion de los clientes y te permite seleccionar uno para eliminar o modificar
        /// </summary>
        private void MostrarInformacionClientes()
        {
            rtbInformacion.Visible = false;
            btnEliminarEmpleado.Enabled = false;
            btnAgregarEmpleado.Enabled = false;
            btnModificarEmpleado.Enabled = false;
            btnModificarCliente.Enabled = true;
            btnAgregarCliente.Enabled = true;
            btnModificarCliente.Enabled = true;
            btnEliminarCliente.Enabled = true;

            dgvPersonas.Visible = true;

            ActualizarDGVCliente(hostel.Clientes);


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
                if (frmAgregarModificarCliente.Objeto is not null && hostel.Clientes.Count < hostel.CapacidadMaximaClientes && hostel.Clientes + frmAgregarModificarCliente.Objeto)
                {
                    MessageBox.Show("Cliente agregado", "Cliente agregado", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                }

                ActualizarDGVCliente(hostel.Clientes);
            }
            catch (PersonaException ex)
            {
                Log.Guardar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

            Cliente cliente;
            if (dgvPersonas.SelectedRows.Count >= 0)
            {
                cliente = (Cliente)dgvPersonas.CurrentRow.DataBoundItem;
                FrmAgregarModificarCliente frmAgregarModificarCliente = new FrmAgregarModificarCliente("Modificar Cliente", "Modificar cliente", cliente);
                frmAgregarModificarCliente.ShowDialog();

                ActualizarDGVCliente(hostel.Clientes);
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
            Cliente clienteAEliminar;
            if (dgvPersonas.SelectedRows.Count > 0)
            {
                try
                {

                    clienteAEliminar = (Cliente)dgvPersonas.CurrentRow.DataBoundItem;

                    DialogResult dialogResult = MessageBox.Show($"Esta seguro que desea eliminar a: {clienteAEliminar}?", "Eliminar cliente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes && hostel.Clientes - clienteAEliminar)
                    {
                        hostel.HistorialClientes.Lista.Add(clienteAEliminar);
                        MessageBox.Show("Cliente eliminado.", "Cliente eliminado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        Task.Run(() => EncuestarCliente(clienteAEliminar));

                        if(!(delegadoEncuestar is null))
                        {
                            delegadoEncuestar.Invoke(clienteAEliminar);
                        }
                    }

                    ActualizarDGVCliente(hostel.Clientes);
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
        /// Encuesta al cliente pasado por parametro y notifica los resultados a partir de un evento
        /// </summary>
        /// <param name="cliente">cliente a encuestar</param>
        private void EncuestarCliente(Cliente cliente)
        {
            Random random = new Random();
            cliente.PuntuacionDelServicio = random.Next(0 , 6);

            if (random.Next(0, 2) == 1) 
            {
                cliente.VolveriaAVenir = true;
            }
            else 
            {
                cliente.VolveriaAVenir = false; 
            }
            
            delegadoEncuestar += NotificarClienteEncuestado ;

        }

        /// <summary>
        /// Muestra los resultados de la encuesta que se realizo al cliente
        /// </summary>
        /// <param name="cliente"></param>
        private void NotificarClienteEncuestado(Cliente cliente)
        {
            MessageBox.Show(cliente.MostrarResultadosEncuesta());
        }

        /// <summary>
        /// Carga los clientes desde un archivo xml
        /// </summary>
        /// <param name="path">ruta donde se encuentra el archivo xml</param>
        private void CargarClientes(string path)
        {
            try
            {
                string ruta = Path.Combine(path, "Clientes.Xml");

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


        private void btnLogs_Click(object sender, EventArgs e)
        {
            MostrarLogs();
        }

        /// <summary>
        /// Muestra el log de errores en el cuadro de texto.
        /// </summary>
        private void MostrarLogs()
        {
            rtbInformacion.Visible = true;
            dgvPersonas.Visible = false;

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
            GuardarHabitaciones(path);
        }

        /// <summary>
        /// Actualiza el data grid view con los datos de la lista pasada por parametros
        /// </summary>
        /// <param name="personas">lista a asignar en el form</param>
        private void ActualizarDGVEmpleado(Personas<Empleado> personas)
        {
            dgvPersonas.DataSource = null;
            dgvPersonas.DataSource = personas.Lista;
        }

        /// <summary>
        /// Actualiza el data grid view con los datos de la lista pasada por parametros
        /// </summary>
        /// <param name="personas">lista a asignar en el form</param>
        private void ActualizarDGVCliente(Personas<Cliente> clientes)
        {
            dgvPersonas.DataSource = null;
            dgvPersonas.DataSource = clientes.Lista;
            dgvPersonas.Columns[0].Visible = false;
            dgvPersonas.Columns[1].Visible = false;
        }

    }
}
