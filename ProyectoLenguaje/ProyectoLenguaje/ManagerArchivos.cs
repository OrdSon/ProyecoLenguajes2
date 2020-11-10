using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLenguaje
{
    class ManagerArchivos
    {
        public void Abrir(object sender, EventArgs e, RichTextBox textBox, IWin32Window ventana, String extension)
        {
            OpenFileDialog Open = new OpenFileDialog();
            System.IO.StreamReader myStreamReader = null;
            Open.Filter = "Codigo [*."+extension+ "*]|*." + extension + "|All Files [*,*]|*,*";
            Open.CheckFileExists = true;
            Open.Title = "Abrir Archivo";
            Open.ShowDialog(ventana);
            try
            {
                Open.OpenFile();
                myStreamReader = System.IO.File.OpenText(Open.FileName);
                textBox.Clear();
                textBox.Text = myStreamReader.ReadToEnd();

            }
            catch (Exception)
            {

            }
        }
        public void Guardar(object sender, EventArgs e, RichTextBox textBox, IWin32Window ventana, String extension)
        {
            SaveFileDialog Save = new SaveFileDialog();
            System.IO.StreamWriter myStreamWriter = null;
            Save.Filter = "Codigo (*." + extension + ")|*." + extension + "|All files(*.*)|*.*";
            Save.CheckPathExists = true;
            Save.Title = "Guardar como";
            Save.ShowDialog(ventana);
            try
            {
                myStreamWriter = System.IO.File.AppendText(Save.FileName);
                myStreamWriter.Write(textBox.Text);
                myStreamWriter.Flush();

            }
            catch (Exception)
            {

            }
        }

    }
}
