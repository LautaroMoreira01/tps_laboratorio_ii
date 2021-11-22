namespace VistaHostel
{
    partial class FrmAgregarModificarCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgregarModificar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.tbApellido = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.tbDni = new System.Windows.Forms.TextBox();
            this.lblFechaDeNacimiento = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.cbSexo = new System.Windows.Forms.ComboBox();
            this.dtpFechaDeNacimiento = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnAgregarModificar
            // 
            this.btnAgregarModificar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAgregarModificar.Location = new System.Drawing.Point(233, 72);
            this.btnAgregarModificar.Name = "btnAgregarModificar";
            this.btnAgregarModificar.Size = new System.Drawing.Size(96, 60);
            this.btnAgregarModificar.TabIndex = 0;
            this.btnAgregarModificar.Text = "button1";
            this.btnAgregarModificar.UseVisualStyleBackColor = true;
            this.btnAgregarModificar.Click += new System.EventHandler(this.btnAgregarModificar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.Location = new System.Drawing.Point(233, 280);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 60);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tbNombre
            // 
            this.tbNombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbNombre.Location = new System.Drawing.Point(42, 72);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(151, 23);
            this.tbNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(42, 54);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(51, 15);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(42, 113);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(51, 15);
            this.lblApellido.TabIndex = 5;
            this.lblApellido.Text = "Apellido";
            // 
            // tbApellido
            // 
            this.tbApellido.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbApellido.Location = new System.Drawing.Point(42, 131);
            this.tbApellido.Name = "tbApellido";
            this.tbApellido.Size = new System.Drawing.Size(151, 23);
            this.tbApellido.TabIndex = 4;
            // 
            // lblDni
            // 
            this.lblDni.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(42, 242);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(25, 15);
            this.lblDni.TabIndex = 9;
            this.lblDni.Text = "Dni";
            // 
            // tbDni
            // 
            this.tbDni.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbDni.Location = new System.Drawing.Point(42, 260);
            this.tbDni.Name = "tbDni";
            this.tbDni.Size = new System.Drawing.Size(151, 23);
            this.tbDni.TabIndex = 8;
            // 
            // lblFechaDeNacimiento
            // 
            this.lblFechaDeNacimiento.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFechaDeNacimiento.AutoSize = true;
            this.lblFechaDeNacimiento.Location = new System.Drawing.Point(42, 179);
            this.lblFechaDeNacimiento.Name = "lblFechaDeNacimiento";
            this.lblFechaDeNacimiento.Size = new System.Drawing.Size(117, 15);
            this.lblFechaDeNacimiento.TabIndex = 7;
            this.lblFechaDeNacimiento.Text = "Fecha de nacimiento";
            // 
            // lblSexo
            // 
            this.lblSexo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(42, 299);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(32, 15);
            this.lblSexo.TabIndex = 11;
            this.lblSexo.Text = "Sexo";
            // 
            // cbSexo
            // 
            this.cbSexo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbSexo.FormattingEnabled = true;
            this.cbSexo.Location = new System.Drawing.Point(42, 317);
            this.cbSexo.Name = "cbSexo";
            this.cbSexo.Size = new System.Drawing.Size(151, 23);
            this.cbSexo.TabIndex = 12;
            // 
            // dtpFechaDeNacimiento
            // 
            this.dtpFechaDeNacimiento.Location = new System.Drawing.Point(42, 197);
            this.dtpFechaDeNacimiento.Name = "dtpFechaDeNacimiento";
            this.dtpFechaDeNacimiento.Size = new System.Drawing.Size(217, 23);
            this.dtpFechaDeNacimiento.TabIndex = 13;
            // 
            // FrmAgregarModificarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 436);
            this.Controls.Add(this.dtpFechaDeNacimiento);
            this.Controls.Add(this.cbSexo);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.tbDni);
            this.Controls.Add(this.lblFechaDeNacimiento);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.tbApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregarModificar);
            this.MinimumSize = new System.Drawing.Size(383, 475);
            this.Name = "FrmAgregarModificarCliente";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAgregarModificarCliente";
            this.Load += new System.EventHandler(this.FrmAgregarModificarCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarModificar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox tbApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox tbDni;
        private System.Windows.Forms.Label lblFechaDeNacimiento;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.ComboBox cbSexo;
        private System.Windows.Forms.DateTimePicker dtpFechaDeNacimiento;
    }
}