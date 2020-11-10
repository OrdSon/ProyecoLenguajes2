namespace ProyectoLenguaje
{
    partial class Error
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
            this.textBoxErrores = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.guardarErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verErroresAnterioresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxErrores
            // 
            this.textBoxErrores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxErrores.Location = new System.Drawing.Point(0, 24);
            this.textBoxErrores.Name = "textBoxErrores";
            this.textBoxErrores.Size = new System.Drawing.Size(466, 426);
            this.textBoxErrores.TabIndex = 0;
            this.textBoxErrores.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guardarErroresToolStripMenuItem,
            this.verErroresAnterioresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(466, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // guardarErroresToolStripMenuItem
            // 
            this.guardarErroresToolStripMenuItem.Name = "guardarErroresToolStripMenuItem";
            this.guardarErroresToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.guardarErroresToolStripMenuItem.Text = "Guardar Errores";
            this.guardarErroresToolStripMenuItem.Click += new System.EventHandler(this.guardarErroresToolStripMenuItem_Click);
            // 
            // verErroresAnterioresToolStripMenuItem
            // 
            this.verErroresAnterioresToolStripMenuItem.Name = "verErroresAnterioresToolStripMenuItem";
            this.verErroresAnterioresToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.verErroresAnterioresToolStripMenuItem.Text = "Ver Errores Anteriores";
            this.verErroresAnterioresToolStripMenuItem.Click += new System.EventHandler(this.verErroresAnterioresToolStripMenuItem_Click);
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 450);
            this.Controls.Add(this.textBoxErrores);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Error";
            this.Text = "Errores";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBoxErrores;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem guardarErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verErroresAnterioresToolStripMenuItem;
    }
}