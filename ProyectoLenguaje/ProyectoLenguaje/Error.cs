using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLenguaje
{
    public partial class Error : Form
    {
        public Error()
        {
            InitializeComponent();
        }
        public Error(LinkedList<String> errores)
        {
            InitializeComponent();
            for (int i = 0; i < errores.Count; i++)
            {
                textBoxErrores.AppendText("\r\n" + errores.ElementAt<String>(i));
                textBoxErrores.ScrollToCaret();
            }
        }

        private void guardarErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagerArchivos manager = new ManagerArchivos();
            manager.Guardar(sender, e,textBoxErrores,this, "gtE");
        }

        private void verErroresAnterioresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxErrores.Clear();
            ManagerArchivos manager = new ManagerArchivos();
            manager.Abrir(sender, e, textBoxErrores, this, "gtE");
        }
    }
}
