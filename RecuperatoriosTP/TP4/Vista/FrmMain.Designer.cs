namespace Vista
{
    partial class FrmMain
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnAgregarEmpleado = new System.Windows.Forms.Button();
            this.btnModificarCliente = new System.Windows.Forms.Button();
            this.btnHostel = new System.Windows.Forms.Button();
            this.rtbInformacion = new System.Windows.Forms.RichTextBox();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.btnMostrarInformacionCliente = new System.Windows.Forms.Button();
            this.btnModificarEmpleado = new System.Windows.Forms.Button();
            this.btnMostrarInformacionEmpleado = new System.Windows.Forms.Button();
            this.btnEliminarEmpleado = new System.Windows.Forms.Button();
            this.btnEliminarCliente = new System.Windows.Forms.Button();
            this.btnLogs = new System.Windows.Forms.Button();
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.btnHistorialClientes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 29F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(316, 25);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(124, 52);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "label1";
            // 
            // btnAgregarEmpleado
            // 
            this.btnAgregarEmpleado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAgregarEmpleado.Location = new System.Drawing.Point(555, 483);
            this.btnAgregarEmpleado.Name = "btnAgregarEmpleado";
            this.btnAgregarEmpleado.Size = new System.Drawing.Size(193, 63);
            this.btnAgregarEmpleado.TabIndex = 1;
            this.btnAgregarEmpleado.Text = "Agregar empleado";
            this.btnAgregarEmpleado.UseVisualStyleBackColor = true;
            this.btnAgregarEmpleado.Click += new System.EventHandler(this.btnAgregarEmpleado_Click);
            // 
            // btnModificarCliente
            // 
            this.btnModificarCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnModificarCliente.Location = new System.Drawing.Point(555, 276);
            this.btnModificarCliente.Name = "btnModificarCliente";
            this.btnModificarCliente.Size = new System.Drawing.Size(193, 63);
            this.btnModificarCliente.TabIndex = 2;
            this.btnModificarCliente.Text = "Modificar Cliente";
            this.btnModificarCliente.UseVisualStyleBackColor = true;
            this.btnModificarCliente.Click += new System.EventHandler(this.btnModificarCliente_Click);
            // 
            // btnHostel
            // 
            this.btnHostel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHostel.Location = new System.Drawing.Point(555, 136);
            this.btnHostel.Name = "btnHostel";
            this.btnHostel.Size = new System.Drawing.Size(193, 63);
            this.btnHostel.TabIndex = 3;
            this.btnHostel.Text = "Hostel";
            this.btnHostel.UseVisualStyleBackColor = true;
            this.btnHostel.Click += new System.EventHandler(this.btnHostel_Click);
            // 
            // rtbInformacion
            // 
            this.rtbInformacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rtbInformacion.Location = new System.Drawing.Point(12, 136);
            this.rtbInformacion.Name = "rtbInformacion";
            this.rtbInformacion.ReadOnly = true;
            this.rtbInformacion.Size = new System.Drawing.Size(537, 617);
            this.rtbInformacion.TabIndex = 4;
            this.rtbInformacion.Text = "";
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAgregarCliente.Location = new System.Drawing.Point(555, 207);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(193, 63);
            this.btnAgregarCliente.TabIndex = 8;
            this.btnAgregarCliente.Text = "Agregar cliente";
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // btnMostrarInformacionCliente
            // 
            this.btnMostrarInformacionCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMostrarInformacionCliente.Location = new System.Drawing.Point(555, 414);
            this.btnMostrarInformacionCliente.Name = "btnMostrarInformacionCliente";
            this.btnMostrarInformacionCliente.Size = new System.Drawing.Size(193, 63);
            this.btnMostrarInformacionCliente.TabIndex = 9;
            this.btnMostrarInformacionCliente.Text = "Informacion clientes";
            this.btnMostrarInformacionCliente.UseVisualStyleBackColor = true;
            this.btnMostrarInformacionCliente.Click += new System.EventHandler(this.btnMostrarInformacionCliente_Click);
            // 
            // btnModificarEmpleado
            // 
            this.btnModificarEmpleado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnModificarEmpleado.Location = new System.Drawing.Point(555, 621);
            this.btnModificarEmpleado.Name = "btnModificarEmpleado";
            this.btnModificarEmpleado.Size = new System.Drawing.Size(193, 63);
            this.btnModificarEmpleado.TabIndex = 10;
            this.btnModificarEmpleado.Text = "Modificar empleado";
            this.btnModificarEmpleado.UseVisualStyleBackColor = true;
            this.btnModificarEmpleado.Click += new System.EventHandler(this.btnModificarEmpleado_Click);
            // 
            // btnMostrarInformacionEmpleado
            // 
            this.btnMostrarInformacionEmpleado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMostrarInformacionEmpleado.Location = new System.Drawing.Point(555, 690);
            this.btnMostrarInformacionEmpleado.Name = "btnMostrarInformacionEmpleado";
            this.btnMostrarInformacionEmpleado.Size = new System.Drawing.Size(193, 63);
            this.btnMostrarInformacionEmpleado.TabIndex = 11;
            this.btnMostrarInformacionEmpleado.Text = "Mostrar informacion empleado";
            this.btnMostrarInformacionEmpleado.UseVisualStyleBackColor = true;
            this.btnMostrarInformacionEmpleado.Click += new System.EventHandler(this.btnMostrarInformacionEmpleado_Click);
            // 
            // btnEliminarEmpleado
            // 
            this.btnEliminarEmpleado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEliminarEmpleado.Location = new System.Drawing.Point(555, 552);
            this.btnEliminarEmpleado.Name = "btnEliminarEmpleado";
            this.btnEliminarEmpleado.Size = new System.Drawing.Size(193, 63);
            this.btnEliminarEmpleado.TabIndex = 13;
            this.btnEliminarEmpleado.Text = "Despedir empleado";
            this.btnEliminarEmpleado.UseVisualStyleBackColor = true;
            this.btnEliminarEmpleado.Click += new System.EventHandler(this.btnEliminarEmpleado_Click);
            // 
            // btnEliminarCliente
            // 
            this.btnEliminarCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEliminarCliente.Location = new System.Drawing.Point(555, 345);
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.Size = new System.Drawing.Size(193, 63);
            this.btnEliminarCliente.TabIndex = 14;
            this.btnEliminarCliente.Text = "Eliminar cliente";
            this.btnEliminarCliente.UseVisualStyleBackColor = true;
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);
            // 
            // btnLogs
            // 
            this.btnLogs.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogs.Location = new System.Drawing.Point(14, 25);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(159, 52);
            this.btnLogs.TabIndex = 15;
            this.btnLogs.Text = "Ver historial de errores";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Location = new System.Drawing.Point(14, 136);
            this.dgvPersonas.MultiSelect = false;
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.ReadOnly = true;
            this.dgvPersonas.RowTemplate.Height = 25;
            this.dgvPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonas.Size = new System.Drawing.Size(535, 615);
            this.dgvPersonas.TabIndex = 16;
            // 
            // btnHistorialClientes
            // 
            this.btnHistorialClientes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnHistorialClientes.Location = new System.Drawing.Point(555, 67);
            this.btnHistorialClientes.Name = "btnHistorialClientes";
            this.btnHistorialClientes.Size = new System.Drawing.Size(193, 63);
            this.btnHistorialClientes.TabIndex = 17;
            this.btnHistorialClientes.Text = "Historial clientes";
            this.btnHistorialClientes.UseVisualStyleBackColor = true;
            this.btnHistorialClientes.Click += new System.EventHandler(this.btnHistorialClientes_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 765);
            this.Controls.Add(this.btnHistorialClientes);
            this.Controls.Add(this.dgvPersonas);
            this.Controls.Add(this.btnLogs);
            this.Controls.Add(this.btnEliminarCliente);
            this.Controls.Add(this.btnEliminarEmpleado);
            this.Controls.Add(this.btnMostrarInformacionEmpleado);
            this.Controls.Add(this.btnModificarEmpleado);
            this.Controls.Add(this.btnMostrarInformacionCliente);
            this.Controls.Add(this.btnAgregarCliente);
            this.Controls.Add(this.rtbInformacion);
            this.Controls.Add(this.btnHostel);
            this.Controls.Add(this.btnModificarCliente);
            this.Controls.Add(this.btnAgregarEmpleado);
            this.Controls.Add(this.lblNombre);
            this.MinimumSize = new System.Drawing.Size(776, 692);
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnAgregarEmpleado;
        private System.Windows.Forms.Button btnModificarCliente;
        private System.Windows.Forms.Button btnHostel;
        private System.Windows.Forms.RichTextBox rtbInformacion;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.Button btnMostrarInformacionCliente;
        private System.Windows.Forms.Button btnModificarEmpleado;
        private System.Windows.Forms.Button btnMostrarInformacionEmpleado;
        private System.Windows.Forms.Button btnEliminarEmpleado;
        private System.Windows.Forms.Button btnEliminarCliente;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.Button btnHistorialClientes;
    }
}