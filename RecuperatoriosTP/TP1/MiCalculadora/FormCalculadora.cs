using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        /// <summary>
        /// Constructor de la clase FormCalculadora.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            LoadComboBox();
        }
        
        /// <summary>
        /// Metodo para limpiar los textBoxs y el combobox del formulario.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = ""; 
            cmbOperador.SelectedIndex = 0;

        }
        
        /// <summary>
        /// Carga los valores del combobox.
        /// </summary>
        public void LoadComboBox()
        {
            cmbOperador.Items.Add('+');
            cmbOperador.Items.Add('-');
            cmbOperador.Items.Add('*');
            cmbOperador.Items.Add('/');

        }
        /// <summary>
        /// Metodo operar que realiza la operacion de los datos ingresados.
        /// </summary>
        /// <param name="numero1">Primer numero a oprerar.</param>
        /// <param name="numero2">Segundo numero a oprerar.</param>
        /// <param name="operador">Operacion a realizar.</param>
        /// <returns>Devuelve el resultado de la operacion realizada.</returns>
        private static double Operar(string numero1 , string numero2 , string operador)
        {
            double resultado;

            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);
            
            resultado = Calculadora.Operar(operando1, operando2, char.Parse(operador));

            return resultado;
        }

        /// <summary>
        /// Metodo load que llama al metodo limpiar del form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Boton cerrar que llama al metodo close del form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Boton operar realiza la operacion ingresada con los numeros de los textBoxs.
        /// y agrega el resultado en el listbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
             
            double resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString());
 
            lblResultado.Text = resultado.ToString() ;

            string ecuacion = $"{txtNumero1.Text} {cmbOperador.SelectedItem.ToString()} {txtNumero2.Text} = {resultado}";

            lstOperaciones.Items.Add(ecuacion) ;
        }
        /// <summary>
        /// Convierte el resultado que se encuentra en el label a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Operando resultado =new Operando();
            
            string numeroDecimal = lblResultado.Text;
            string numeroBinario;

            numeroBinario = lblResultado.Text = resultado.DecimalBinario(lblResultado.Text);

            string ecuacion = $"{numeroDecimal} = {numeroBinario} ";

            lstOperaciones.Items.Add(ecuacion);

        }

        /// <summary>
        /// Convierte el resultado que se encuentra en el label a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Operando resultado = new Operando();

            string numeroBinario = lblResultado.Text;
            string numeroDecimal = "";

            numeroDecimal = lblResultado.Text = resultado.BinarioDecimal(lblResultado.Text);

            string ecuacion = $"{numeroBinario} = {numeroDecimal} ";

            lstOperaciones.Items.Add(ecuacion);

        }
        /// <summary>
        /// Llama al metodo limpiar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// metodo form closing del form pregunta si estas seguro de querer salir del form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que desea salir?", "Salir.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            
        }

    }
}
