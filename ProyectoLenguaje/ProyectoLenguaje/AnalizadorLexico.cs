using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLenguaje
{
    public class AnalizadorLexico {

        LinkedList<Token> tokens = new LinkedList<Token>();
        LinkedList<Token> errores = new LinkedList<Token>();
        const string estadoInicial = "S0";
        string estadoActual = "S0";
        char charActual;
        string valor;
        Token.Tipo tipo;
        Boolean aceptacion;

        /* L = Letra
         * E = Entero
         * P = Punto
         * B = Blank
         * U = Guion bajo
         * C = Comillas
         * S = Simbolo
         */
        string[,] funcionTransicion = { {"S0", "E", "S1"},//transicion a cada automata
                                        {"S0", "C", "S5"},
                                        {"S0", "L", "S7"},
                                        {"S0" ,"A" ,"S9"},
                                        {"S0", "<", "S10"},
                                        {"S0", ">", "S11"},
                                        {"S0", "!", "S12"},
                                        {"S0", "=", "S13"},
                                        {"S0","&","S15" },
                                        {"S0","|","S15" },

                                        {"S1", "E", "S1"},//automata numeros
                                        {"S1", "P", "S2"},
                                        {"S2", "E", "S3"},
                                        {"S3", "E", "S3"},

                                                        //automata cadena
                                        {"S5", "E", "S5"},
                                        {"S5", "L", "S5"},
                                        {"S5", "B", "S5"},
                                        {"S5", "S", "S5"},
                                        {"S5", "C", "S6"},

                                        {"S7", "L", "S8"},//automata identificador
                                        {"S8", "L", "S8"},
                                        {"S8", "U", "S8"},
                                        {"S8", "E", "S8"},

                                        
                                        {"S10", "=", "S14"},//automata relacional
                                        {"S11", "=", "S14"},
                                        {"S12", "=", "S14"},
                                        {"S13", "=", "S14"},

                                        {"S15","&","S16" },
                                        {"S15","|","S17" }
                                         };
        
        string[] estadosAceptacion = {"S1","S3","S6","s7","S8","S9","S10",
            "S11","S13","S12","S14","15","16","17"};
        /* S1 = ENTERO
         * S3 = DECIMAL
         * S6 = CADENA
         * S8 = IDENTIFICADOR
         */

        /* L = Letra
         * E = Entero
         * P = Punto
         * B = Blank
         * U = Guion bajo
         * C = Comillas
         * S = Simbolo
         */
        private AnalizadorSintactico analizador;
        public AnalizadorLexico() {
            this.analizador = new AnalizadorSintactico();
        }
        public void analizar(RichTextBox textBox){
            analizador = new AnalizadorSintactico();
            char[] chars = textBox.Text.ToCharArray();
            int posicion = 0;
            int tamañoTemporal = 0;
            Boolean regreso = false;
            if (textBox.Lines.Length <= 0) {
                MessageBox.Show("Sin texto que analizar");
                return;
            }
            estadoActual = estadoInicial;
            for (int i = 0; i < textBox.Lines.Length; i++) {
                char[] linea = textBox.Lines[i].ToCharArray();
                for (int j = 0; j < linea.Length ; j++) {
                    preToken preToken = new preToken();
                    preToken.setValue(linea[j]);
                    char temporal = linea[j];
                    Console.WriteLine(temporal+"");
                    Console.WriteLine(posicion + "");
                    
                    if (preToken.setTipo(temporal) == false && !preToken.isSymbol()) {

                    }
                     else {
                        if (EncontrarSiguiente(preToken.getTipo()) ) {
                            valor += temporal;
                            tamañoTemporal++;
                            if (j == linea.Length-1 && aceptacion) {
                                Console.WriteLine("Si llegue a GUARDAR TOKEN" + tamañoTemporal);
                                Token token = new Token(tipo, valor, valor.Length, posicion - valor.Length,i+1);
                                guardarToken(token,ref tamañoTemporal);
                            }
                        } else {
                            if (aceptacion) {
                                Token token = new Token(tipo, valor, valor.Length, posicion - valor.Length,i+1);
                                guardarToken(token,ref tamañoTemporal);
                                j--;
                                posicion--;
                                
                                regreso = true;
                            }else if (preToken.isSymbol()) {
                                Token token = new Token(preToken.GetTipo(), temporal + "", 1, posicion - valor.Length,i+1);
                                guardarToken(token, ref tamañoTemporal);
                                
                                    
                            } else {
                                if (temporal != (char)32 && temporal != (char)9) {
                                    valor += temporal;
                                    Console.WriteLine("Si llegue a GUARDAR ERROR");
                                    Token token = new Token(preToken.GetTipo(), temporal + "", 1, posicion - valor.Length, i+1);
                                    errores.AddLast(token);
                                    valor = "";
                                    estadoActual = "S0";
                                    tamañoTemporal = 0;
                                }
                            }
                        }
                    }
                    posicion++;
                }
                posicion++;
            }
            imprimirTokens();
            
            Pintor pintor = new Pintor();
            pintor.pintar(textBox,tokens);
            
            analizador.analizar(false,tokens);
            tokens.Clear();
            }
        public void guardarToken(Token token, ref int tamañoTemporal) {
            Console.WriteLine("Si llegue a GUARDAR TOKEN" + tamañoTemporal);
            tokens.AddLast(token);
            valor = "";
            estadoActual = "S0";
            tamañoTemporal = 0;
        }
        public void imprimirTokens() {
            for (int i = 0; i < tokens.Count; i++) {
                tokens.ElementAt<Token>(i).revisarTipo();
                Console.WriteLine("Token:" + tokens.ElementAt<Token>(i).getValor() + " Tipo: " +
                    tokens.ElementAt<Token>(i).getTipo() + "  Posicion: " + tokens.ElementAt<Token>(i).getPosicion() +
                    "  Size: " + tokens.ElementAt<Token>(i).getSize());
            }
        }
        public Boolean EncontrarSiguiente(string tipo) {
            
            for (int i = 0; i<29;i++) {
                
                string c1 = this.funcionTransicion[i,0];
                string c2 = this.funcionTransicion[i,1];
                string c3 = this.funcionTransicion[i,2];
     
                if (c1 == estadoActual && c2 == tipo) {
                    estadoActual = c3;
                    verificarAceptacion(estadoActual);
                    return true;
                }
                verificarAceptacion(estadoActual);
            }
            
            return false;
        }
        public void verificarAceptacion(string estado) {

            if (estado.Equals("S1")) {
                tipo = Token.Tipo.VALOR_ENTERO;
                aceptacion = true;
            } else if (estado.Equals("S3")) {
                tipo = Token.Tipo.VALOR_DECIMAL;
                aceptacion = true;
            } else if (estado.Equals("S6")) {
                tipo = Token.Tipo.VALOR_CADENA;
                aceptacion = true;

            } else if (estado.Equals("S7")) {
                tipo = Token.Tipo.VALOR_CHART;
                aceptacion = true;
            } else if (estado.Equals("S8")) {
                tipo = Token.Tipo.IDENTIFICADOR;
                aceptacion = true;

            } else if (estado.Equals("S12")) {
                tipo = Token.Tipo.OPERADOR_LOGICO;
                aceptacion = true;
            } 
            else if (estado.Equals("S10") || estado.Equals("S11") ||
             estado.Equals("S14")) {
                tipo = Token.Tipo.OPERADOR_RELACIONAL;
                aceptacion = true;

            } else if (estado.Equals("S13")) {
                tipo = Token.Tipo.ASIGNACION;
                aceptacion = true;
            } else if (estado.Equals("S15")|| estado.Equals("S16")|| estado.Equals("S17")) {
                tipo = Token.Tipo.OPERADOR_LOGICO;
                aceptacion = true;
            } else {
                tipo = Token.Tipo.ERROR;
                aceptacion = false;
            }
            
        }
        public void mostrarErrores() {
            LinkedList<String> stringErrores = new LinkedList<string>();
            for (int i = 0; i < errores.Count; i++) {
                stringErrores.AddLast("Error: "
                    +errores.ElementAt<Token>(i).getValor()+" En linea: "
                    +errores.ElementAt<Token>(i).getLinea()+" En indice:"
                    + errores.ElementAt<Token>(i).getPosicion());
            }
            stringErrores.AddFirst("ERRORES LEXICOS:");
            Error error = new Error(stringErrores);
            error.Visible = true;
        }
        public AnalizadorSintactico GetAnalizadorSintactico() {
            return this.analizador;
        }


    }
}