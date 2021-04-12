
namespace AplicacionComercial.Windows
{
    partial class Mdi
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
            this.menuMdi = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAlmacenes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuConceptos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMdi.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMdi
            // 
            this.menuMdi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuArchivo});
            this.menuMdi.Location = new System.Drawing.Point(0, 0);
            this.menuMdi.Name = "menuMdi";
            this.menuMdi.Size = new System.Drawing.Size(773, 24);
            this.menuMdi.TabIndex = 0;
            this.menuMdi.Text = "menuStrip1";
            // 
            // toolStripMenuArchivo
            // 
            this.toolStripMenuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuAlmacenes,
            this.toolStripMenuClientes,
            this.toolStripMenuConceptos});
            this.toolStripMenuArchivo.Name = "toolStripMenuArchivo";
            this.toolStripMenuArchivo.Size = new System.Drawing.Size(60, 20);
            this.toolStripMenuArchivo.Text = "&Archivo";
            // 
            // toolStripMenuAlmacenes
            // 
            this.toolStripMenuAlmacenes.Name = "toolStripMenuAlmacenes";
            this.toolStripMenuAlmacenes.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuAlmacenes.Text = "Al&macenes";
            this.toolStripMenuAlmacenes.Click += new System.EventHandler(this.toolStripMenuAlmacenes_Click);
            // 
            // toolStripMenuClientes
            // 
            this.toolStripMenuClientes.Name = "toolStripMenuClientes";
            this.toolStripMenuClientes.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuClientes.Text = "&Clientes";
            // 
            // toolStripMenuConceptos
            // 
            this.toolStripMenuConceptos.Name = "toolStripMenuConceptos";
            this.toolStripMenuConceptos.Size = new System.Drawing.Size(132, 22);
            this.toolStripMenuConceptos.Text = "C&onceptos";
            // 
            // Mdi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 472);
            this.Controls.Add(this.menuMdi);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMdi;
            this.Name = "Mdi";
            this.Text = "Mdi";
            this.menuMdi.ResumeLayout(false);
            this.menuMdi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMdi;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuArchivo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAlmacenes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuClientes;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuConceptos;
    }
}