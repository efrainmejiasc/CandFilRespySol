namespace CandFilRespySol
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel11 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mTablero = new System.Windows.Forms.ToolStripMenuItem();
            this.mColores = new System.Windows.Forms.ToolStripMenuItem();
            this.mContadores = new System.Windows.Forms.ToolStripMenuItem();
            this.mIdiomas = new System.Windows.Forms.ToolStripMenuItem();
            this.mIIngles = new System.Windows.Forms.ToolStripMenuItem();
            this.mIEspañol = new System.Windows.Forms.ToolStripMenuItem();
            this.mIPortugues = new System.Windows.Forms.ToolStripMenuItem();
            this.panel11.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.Gray;
            this.panel11.Controls.Add(this.menuStrip1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(570, 24);
            this.panel11.TabIndex = 60;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gray;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mArchivo,
            this.mTablero,
            this.mColores,
            this.mContadores,
            this.mIdiomas});
            this.menuStrip1.Location = new System.Drawing.Point(196, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(153, 24);
            this.menuStrip1.TabIndex = 58;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mArchivo
            // 
            this.mArchivo.Name = "mArchivo";
            this.mArchivo.Size = new System.Drawing.Size(70, 20);
            this.mArchivo.Text = "ARCHIVO";
            this.mArchivo.Visible = false;
            // 
            // mTablero
            // 
            this.mTablero.Name = "mTablero";
            this.mTablero.Size = new System.Drawing.Size(68, 20);
            this.mTablero.Text = "TABLERO";
            this.mTablero.Visible = false;
            // 
            // mColores
            // 
            this.mColores.Name = "mColores";
            this.mColores.Size = new System.Drawing.Size(70, 20);
            this.mColores.Text = "COLORES";
            this.mColores.Visible = false;
            // 
            // mContadores
            // 
            this.mContadores.Name = "mContadores";
            this.mContadores.Size = new System.Drawing.Size(95, 20);
            this.mContadores.Text = "CONTADORES";
            this.mContadores.Visible = false;
            // 
            // mIdiomas
            // 
            this.mIdiomas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mIIngles,
            this.mIEspañol,
            this.mIPortugues});
            this.mIdiomas.Name = "mIdiomas";
            this.mIdiomas.Size = new System.Drawing.Size(145, 20);
            this.mIdiomas.Text = "IDIOMAS - LANGUAGES";
            // 
            // mIIngles
            // 
            this.mIIngles.Name = "mIIngles";
            this.mIIngles.Size = new System.Drawing.Size(152, 22);
            this.mIIngles.Text = "English";
            // 
            // mIEspañol
            // 
            this.mIEspañol.Name = "mIEspañol";
            this.mIEspañol.Size = new System.Drawing.Size(152, 22);
            this.mIEspañol.Text = "Español";
            // 
            // mIPortugues
            // 
            this.mIPortugues.Name = "mIPortugues";
            this.mIPortugues.Size = new System.Drawing.Size(152, 22);
            this.mIPortugues.Text = "Português";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 641);
            this.Controls.Add(this.panel11);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mArchivo;
        private System.Windows.Forms.ToolStripMenuItem mTablero;
        private System.Windows.Forms.ToolStripMenuItem mColores;
        private System.Windows.Forms.ToolStripMenuItem mContadores;
        private System.Windows.Forms.ToolStripMenuItem mIdiomas;
        private System.Windows.Forms.ToolStripMenuItem mIIngles;
        private System.Windows.Forms.ToolStripMenuItem mIEspañol;
        private System.Windows.Forms.ToolStripMenuItem mIPortugues;
    }
}

