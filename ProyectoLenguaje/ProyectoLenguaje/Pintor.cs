using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLenguaje {
    class Pintor {

        public void pintar(RichTextBox textBox, LinkedList<Token> tokens) {
            for (int i = 0; i<tokens.Count;i++) {
                int posicion = tokens.ElementAt<Token>(i).getPosicion();
                int size = tokens.ElementAt<Token>(i).getSize();
                textBox.Select(posicion, size);
                textBox.SelectionColor = tokens.ElementAt<Token>(i).getColor();
            }
        }
    }
}
