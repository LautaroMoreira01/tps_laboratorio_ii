using EntidadesHostel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmAgregarModificarEmpleado : Form
    {
        private Empleado empleado;

        /// <summary>
        /// Constructor que inicializa el titulo del form, texto del boton y un empleado
        /// </summary>
        /// <param name="titulo">titulo del form</param>
        /// <param name="textoBoton">texto del boton</param>
        /// <param name="empleado">empleado</param>
        public FrmAgregarModificarEmpleado(string titulo, string textoBoton , Empleado empleado)
        {
            InitializeComponent();
            Text = titulo;
            btnAgregarModificar.Text = textoBoton;

            this.empleado = empleado;
        }

        /// <summary>
        /// inicializa el estado de los elementos en el form
        /// </summary>
        private void FrmAgregarModificarEmpleado_Load(object sender, EventArgs e)
        {
            cbPuesto.DataSource = Enum.GetValues(typeof(EPuesto));
            cbSexo.DataSource = Enum.GetValues(typeof(ESexo));

            if (empleado is not null)
            {
                
                tbNombre.Text = empleado.Nombre;
                tbApellido.Text = empleado.Apellido;
                tbDni.Text = empleado.Dni.ToString();
                dtpFechaDeNacimiento.Value = empleado.FechaNacimiento;
                tbSalario.Text = empleado.Salario.ToString();
                tbDni.Enabled = false;
                cbPuesto.SelectedIndex = (int)empleado.Puesto;
                cbSexo.SelectedIndex = (int)empleado.Sexo;
            }
        }

        /// <summary>
        /// Metodo que agrega o modifica un objeto
        /// </summary>
        private void btnAgregarModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    
                    int dni = int.Parse(tbDni.Text);
                    float salario = float.Parse(tbSalario.Text, NumberStyles.Any, CultureInfo.InvariantCulture);

                    if(empleado is null)
                    {
                        empleado = new Empleado(tbNombre.Text, tbApellido.Text, dni, dtpFechaDeNacimiento.Value,
                        (ESexo)cbSexo.SelectedItem, (EPuesto)cbPuesto.SelectedItem, salario);

                    }
                    else
                    {
                        empleado.Nombre = tbNombre.Text;
                        empleado.Apellido = tbApellido.Text;
                        empleado.Dni = dni;
                        empleado.FechaNacimiento = dtpFechaDeNacimiento.Value;
                        empleado.Sexo = (ESexo)cbSexo.SelectedItem;
                        empleado.Puesto = (EPuesto)cbPuesto.SelectedItem;
                        empleado.Salario = salario;
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (CampoInvalidoException ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// valida los campos del form
        /// </summary>
        /// <returns>true si los campos son validos false si no lo son</returns>
        /// <exception cref="CampoInvalidoException">excepcion que se ejecuta si los campos no son validos</exception>
        private bool ValidarCampos()
        {
            bool rta = false;
            try
            {
                bool nombre = ValidarCampoNombre();
                bool apellido = ValidarCampoApellido();
                bool edad = ValidarCampoFechaDeNacimiento();
                bool salario = ValidarCampoSalario();
                bool dni = ValidarCampoDni();
                bool puesto = ValidarCampoPuesto();
                bool sexo = ValidarCampoSexo();

                if (nombre && apellido && edad && salario && dni && puesto && sexo)
                {
                    rta = true;
                }

            }
            catch (CampoInvalidoException ex)
            {
                throw new CampoInvalidoException(ex.Message, ex.InnerException);

            }

            return rta;

        }

        /// <summary>
        /// valida si el campo nombre es correcto
        /// </summary>
        /// <returns>true si el campo es correcto, si no lamza una excepcion de campo invalido</returns>
        /// <exception cref="CampoInvalidoException">excepcion a lanzar si el campo es invalido</exception>
        private bool ValidarCampoNombre()
        {

            if (tbNombre.Text != String.Empty)
            {
                return true;
            }
            else
            {
                throw new CampoInvalidoException("El campo nombre no puede estar vacio.");
            }
        }

        /// <summary>
        /// valida si el campo apellido es correcto
        /// </summary>
        /// <returns>true si el campo es correcto, si no lamza una excepcion de campo invalido</returns>
        /// <exception cref="CampoInvalidoException">excepcion a lanzar si el campo es invalido</exception>
        private bool ValidarCampoApellido()
        {
            if (tbApellido.Text != String.Empty)
            {
                return true;
            }
            else
            {
                throw new CampoInvalidoException("El campo apellido no puede estar vacio.");
            }
        }

        /// <summary>
        /// valida si el campo puesto es correcto
        /// </summary>
        /// <returns>true si el campo es correcto, si no lamza una excepcion de campo invalido</returns>
        /// <exception cref="CampoInvalidoException">excepcion a lanzar si el campo es invalido</exception>
        private bool ValidarCampoPuesto()
        {

            if (cbPuesto.SelectedIndex != -1)
            {
                return true;
            }
            else
            {
                throw new CampoInvalidoException("Debe seleccionar un puesto en el campo posicion.");
            }
        }

        /// <summary>
        /// valida si el campo sexo es correcto
        /// </summary>
        /// <returns>true si el campo es correcto, si no lamza una excepcion de campo invalido</returns>
        /// <exception cref="CampoInvalidoException">excepcion a lanzar si el campo es invalido</exception>
        private bool ValidarCampoSexo()
        {

            if (cbSexo.SelectedIndex != -1)
            {
                return true;
            }
            else
            {
                throw new CampoInvalidoException("Debe seleccionar una opcion en el campo sexo.");
            }
        }

        /// <summary>
        /// valida si el campo dni es correcto
        /// </summary>
        /// <returns>true si el campo es correcto, si no lamza una excepcion de campo invalido</returns>
        /// <exception cref="CampoInvalidoException">excepcion a lanzar si el campo es invalido</exception>
        private bool ValidarCampoDni()
        {
            int dni;

            if (tbDni.Text != String.Empty && int.TryParse(tbDni.Text, out dni))
            {
                return true;
            }
            else
            {
                throw new CampoInvalidoException("El campo Dni no puede estar vacio y debe contener solamente numeros.");
            }
        }


        /// <summary>
        /// valida si el campo fecha de nacimiento es correcto
        /// </summary>
        /// <returns>true si el campo es correcto, si no lamza una excepcion de campo invalido</returns>
        /// <exception cref="CampoInvalidoException">excepcion a lanzar si el campo es invalido</exception>
        private bool ValidarCampoFechaDeNacimiento()
        {

            if (dtpFechaDeNacimiento.Value < DateTime.Now)
            {
                return true;
            }
            else
            {
                throw new CampoInvalidoException("El campo fecha de nacimiento no puede ser mayor a la fecha actual.");
            }
        }


        /// <summary>
        /// valida si el campo salario es correcto
        /// </summary>
        /// <returns>true si el campo es correcto, si no lamza una excepcion de campo invalido</returns>
        /// <exception cref="CampoInvalidoException">excepcion a lanzar si el campo es invalido</exception>
        private bool ValidarCampoSalario()
        {
            float salario;

            if (tbSalario.Text != String.Empty && float.TryParse(tbSalario.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out salario))
            {
                return true;
            }
            else
            {
                throw new CampoInvalidoException("El campo salario no puede estar vacio y debe contener solamente numeros.");
            }
        }

        /// <summary>
        /// Propiedad que retorna o ingresa el valo de un empleado
        /// </summary>
        public Empleado Objeto
        {
            get { return empleado; }
            set { empleado = value; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
