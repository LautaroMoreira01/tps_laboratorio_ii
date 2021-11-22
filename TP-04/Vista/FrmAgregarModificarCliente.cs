using EntidadesHostel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistaHostel
{
    partial class FrmAgregarModificarCliente : Form
    {
        private Cliente cliente;
        public FrmAgregarModificarCliente(string titulo, string textoBoton, Cliente cliente)
        {
            InitializeComponent();
            Text = titulo;
            btnAgregarModificar.Text = textoBoton;

            this.cliente = cliente;
        }

        private void FrmAgregarModificarCliente_Load(object sender, EventArgs e)
        {
            cbSexo.DataSource = Enum.GetValues(typeof(ESexo));

            if (cliente is not null)
            {

                tbNombre.Text = cliente.Nombre;
                tbApellido.Text = cliente.Apellido;
                tbDni.Text = cliente.Dni.ToString();
                dtpFechaDeNacimiento.Value = cliente.FechaNacimiento;
                tbDni.Enabled = false;
                cbSexo.SelectedIndex = (int)cliente.Sexo;
            }
        }

        private void btnAgregarModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    int dni = int.Parse(tbDni.Text);

                    if (cliente is null)
                    {
                        cliente = new Cliente(tbNombre.Text, tbApellido.Text, dni, dtpFechaDeNacimiento.Value,
                        (ESexo)cbSexo.SelectedItem);

                    }
                    else
                    {
                        cliente.Nombre = tbNombre.Text;
                        cliente.Apellido = tbApellido.Text;
                        cliente.Dni = dni;
                        cliente.FechaNacimiento = dtpFechaDeNacimiento.Value;
                        cliente.FechaNacimiento = dtpFechaDeNacimiento.Value;
                        cliente.Sexo = (ESexo)cbSexo.SelectedItem;
                    }

                    Close();
                }
            }
            catch (CampoInvalidoException ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Valida si todos los campos son validos
        /// </summary>
        /// <returns>true si son validos</returns>
        /// <exception cref="CampoInvalidoException"> excepcion a lanzar si algun campo es invalido</exception>
        private bool ValidarCampos()
        {
            bool rta = false;
            try
            {
                bool nombre = ValidarCampoNombre();
                bool apellido = ValidarCampoApellido();
                bool edad = ValidarCampoFechaDeNacimiento();
                bool dni = ValidarCampoDni();
                bool sexo = ValidarCampoSexo();

                if (nombre && apellido && edad && dni && sexo)
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
            
            if (dtpFechaDeNacimiento.Value < DateTime.Now )
            {
                return true;
            }
            else
            {
                throw new CampoInvalidoException("El campo fecha de nacimiento no puede ser mayor a la fecha actual.");
            }
        }

        /// <summary>
        /// Propiedad que retorna o ingresa el valo de un cliente
        /// </summary>
        public Cliente Objeto
        {
            get { return cliente; }
            set { cliente = value; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
