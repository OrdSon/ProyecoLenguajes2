using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLenguaje {
     public class AnalizadorSintactico {
        string[,] funcionDeTransicion = {
            { "S0", "Principal", "S1"},//Reconoce principal
            { "S1","parentesis apertura","S2"},
            { "S2","parentesis cierre","S3"},
            //Reconoce Llaves
            {"S3","llave apertura","S4" },
            {"S4","llave cierre","S5" },//A
            /////////////////////////////
            //ESTADO INICIAL: S6
            {"S6","SI","S7"},
            //FIN SENTENCIA
            { "S34","FIN","S5"},
            //Mientras y hacer
            { "S6","MIENTRAS","S15"},
            { "S6","HACER","S15"},
            //DESDE
            { "S6","DESDE","S22"},
            //leer
            { "S6","leer","S31"},
            //imprimir
            {"S6","imprimir","S36" },
            /////////////////////////////
            //Condicional de IF
            { "S7","parentesis apertura","S8"},
            { "S8","verdadero","S9"},
            { "S8","falso","S9"},
            { "S8","valor boolean","S9"},
            { "S9","operador logico","S8"},
            { "S8","identificador","S10"},
            { "S10","operador relacional","S11"},
            { "S11","identificador","S9"},
            { "S8","Negacion","S12"},
            { "S12","verdadero","S9"},
            { "S12","falso","S9"},
            { "S12","valor boolean","S9"},
            { "S9","parentesis cierre","S13"},
            //resto
            {"S13","llave apertura","S14"},
            {"S14","llave cierre" ,"S15"},//A
            {"S15","SINOSI","S7"},
            { "S15","SINO","S3"},//A
            //CONDICION GENERAL
            { "S15","parentesis apertura","S16"},
            { "S16","Boolean","S17"},
            { "S16","verdadero","S17"},
            { "S16","falso","S17"},
            { "S17","operador logico","S16"},
            { "S16","identificador","S18"},
            { "S18","operador relacional","S19"},
            { "S19","identificador","S17"},
            { "S16","Negacion","S20"},
            { "S20","Boolean","S17"},
            { "S20","verdadero","S17"},
            { "S20","falso","S17"},
            { "S17","parentesis cierre","S3"},

            //FOR
            
            { "S22","identificador","S23"},
            { "S23","asignacion","S24"},
            { "S24","identificador","S25"},
            { "S24","valor entero","S25"},
            { "S25","HASTA","S26"},
            { "S26","identificador","S27"},
            { "S27","operador relacional","S28"},
            { "S28","identificador","S29"},
            { "S28","valor entero","S29"},
            { "S29","INCREMENTO","S30"},
            { "S30","identificador","S3"},
            { "S30","valor entero","S3"},

            { "S31","parentesis apretura","S32"},
            { "S32","identificador","S33"},
            { "S33","parentesis cierre","S34"},
            //IMPRIMIR
            
            {"S36","parentesis apertura","S37" },
            {"S37","valor entero","S38" },
            {"S37","identificador","S38" },
            {"S38","operador aritmetico","S39" },
            {"S38","parentesis cierre","S34" },
            {"S37","valor cadena","S39" },
            {"S37","Cadena","S39" },
            {"S39","operador aritmetico","S38" },
            {"S39","parentesis cierre","S34" },

            //VARIABLES
            {"S6","Entero","S40" },
            {"S40","identificador","S41" },
            {"S41","FIN","S5" },
            {"S41","coma","S42" },
            {"S42","identificador","S41" },
            {"S41","asignacion","S43" },
            {"S43","valor entero","S41" },

            {"S6","Decimal","SA0" },
            {"SA0","identificador","SA1" },
            {"SA1","FIN","S5" },
            {"SA1","coma","SA2" },
            {"SA2","identificador","SA1" },
            {"SA1","asignacion","SA3" },
            {"SA3","valor decimal","SA1" },

            {"S6","Cadena","SB0" },
            {"SB0","identificador","SB1" },
            {"SB1","FIN","S5" },
            {"SB1","coma","SB2" },
            {"SB2","identificador","SB1" },
            {"SB1","asignacion","SB3" },
            {"SB3","valor cadena","SB1" },

            {"S6","Chart","SC0" },
            {"SC0","identificador","SC1" },
            {"SC1","FIN","S5" },
            {"SC1","coma","SC2" },
            {"SC2","identificador","SC1" },
            {"SC1","asignacion","SC3" },
            {"SC3","valor chart","SC1" },

            {"S6","Boolean","SD0" },
            {"SD0","identificador","SD1" },
            {"SD1","FIN","S5" },
            {"SD1","coma","SD2" },
            {"SD2","identificador","SD1" },
            {"SD1","asignacion","SD3" },
            {"SD3","valor boolean","SD1" },
            //OPERACIONES
            {"S6","identificador","SF1" },
            {"SF1","asignacion","SF3" },//HERE
            {"SF3","valor entero","SF4" },
            {"SF3","valor decimal","SF4" },
            {"SF3","valor cadena","SF5" },
            {"SF3","valor chart","SF5" },
            {"SF3","identificador","SF6" },
            {"SF4","FIN","S5" },
            {"SF5","FIN","S5" },
            {"SF6","FIN","S5" },

            {"SF4","operador aritmetico","SF7" },
            {"SF5","operador aritmetico","SF7" },
            {"SF6","operador aritmetico","SF7" },

            {"SF7","valor decimal","SF4" },
            {"SF7","valor entero","SF4" },
            {"SF7","valor chart","SF5" },
            {"SF7","valor cadena","SF5" },
            {"SF7","identificador","SF6" },

            {"SF4","FIN","S5" },
            {"SF5","FIN","S5" },
            {"SF6","FIN","S5" },

        };
        LinkedList<string> errores = new LinkedList<string>();
        //Blue wednesday -introvert
        string estadosDeAceptacion = "S5";
        LinkedList<Token> tokens = new LinkedList<Token>();
        const string estadoInicial = "S0";
        const string estadoSubInicial = "S6";
        string estadoActual = "S0";
        string valorActual;
        Boolean aceptacion;
        AnalizadorSintactico analizador;

        public AnalizadorSintactico() {
            
        }
        
        public void analizar(Boolean reAnalisis, LinkedList<Token> tokens) {
            this.tokens = tokens;
            errores.Clear();
            if (reAnalisis) {
                estadoActual = estadoSubInicial;
            } else {
                estadoActual = estadoInicial;
            }
            for (int j = 0; j < tokens.Count; j++) {
                Token token = tokens.ElementAt<Token>(j);
                valorActual = token.getTipo();
                if (!EncontrarSiguiente(token.getTipo())) {
                    if (aceptacion) {
                        Console.WriteLine("TODO BIEN");
                        estadoActual = "S6";
                        j--;
                    } else {
                        guardarErrores();
                        break;
                    }
                }else if(valorActual.Equals("llave apertura")) {
                    LinkedList<Token> temporal = buscarLlaves(j);
                    if(temporal != null) {
                        this.analizador = new AnalizadorSintactico();
                        this.analizador.analizar(true, temporal);
                        j += temporal.Count;
                    } else {
                        Console.WriteLine("VACIA");
                    }
                }
            }
            estadoActual = estadoInicial;
        }
        public Boolean EncontrarSiguiente(string tipo) {

            for (int i = 0; i < 122; i++) {

                string c1 = this.funcionDeTransicion[i, 0];
                string c2 = this.funcionDeTransicion[i, 1];
                string c3 = this.funcionDeTransicion[i, 2];

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

            if (estado.Equals("S5")) {
                aceptacion = true;
            } else {
                aceptacion = false;
            }

        }

        private LinkedList<Token> buscarLlaves(int comienzo) {
            int llaves = 0;
            int cuenta = 0;
            LinkedList<Token> temporal = new LinkedList<Token>();
            for (int i = comienzo; i < tokens.Count; i++) {
                string actual = tokens.ElementAt<Token>(i).getTipo();
                if(actual.Equals("llave apertura")) {
                    Console.WriteLine("ABRE");
                    llaves += 1;
                }else if (actual.Equals("llave cierre")) {
                    Console.WriteLine("CIERRA");
                    llaves -= 1;
                    
                }

                if (llaves == 0) {
                    cuenta = i;
                    break;
                }

            }
            for (int i = comienzo+1; i < cuenta; i++) {
                temporal.AddLast(tokens.ElementAt<Token>(i));
            }

            if(temporal.Count == 0) {
                return null;
            } else if (llaves > 0) {
                MessageBox.Show("Error, llave sin cerrar");
                return null;
            } else if (llaves < 0) {
                MessageBox.Show("Error, llave sin cerrar");
                return null;
            } else {
                return temporal;
            }
           
        }
        public void guardarErrores() {
            String error = "";
            if (estadoActual.Equals("S6")) {
                error = "Token inserperado";
            }else if (estadoActual.Equals("S7") || estadoActual.Equals("S9")|| estadoActual.Equals("S36") ||
                estadoActual.Equals("S1")|| estadoActual.Equals("S2")|| estadoActual.Equals("S15") || estadoActual.Equals("S17")
                || estadoActual.Equals("S31") || estadoActual.Equals("S33") || estadoActual.Equals("S38") || estadoActual.Equals("S39")) {
                error = "Se esperaba parentesis";
            } else if (estadoActual.Equals("S3")) {
                error = "Falta llave";
            } else if (estadoActual.Equals("S34")|| estadoActual.Equals("S41") || estadoActual.Equals("SF4")
                || estadoActual.Equals("SF5") || estadoActual.Equals("SF6")) {
                error = "Se esperaba ; ";
            } else if (estadoActual.Equals("S10")|| estadoActual.Equals("S18")|| estadoActual.Equals("S27")|| estadoActual.Equals("S17")|| estadoActual.Equals("S9")) {
                error = "Se esperaba operador";
            } else if (estadoActual.Equals("S8")|| estadoActual.Equals("S12") || estadoActual.Equals("S16") || estadoActual.Equals("S20")) {
                error = "Se esperaba condicional O valor";
            } else if (estadoActual.Equals("S23") || estadoActual.Equals("S41") || estadoActual.Equals("SA1") || estadoActual.Equals("SB1")
                || estadoActual.Equals("SC1") || estadoActual.Equals("SD1") || estadoActual.Equals("SF1")) {
                error = "Se esperaba asignacion";
            } else if (estadoActual.Equals("S25") || estadoActual.Equals("S29")) {
                error = "Se esperaba palabra reservada";
            } else if (estadoActual.Equals("S37") || estadoActual.Equals("SF3") || estadoActual.Equals("SF7") || estadoActual.Equals("S24")) {
                error = "Se esperaba valor";
            } else if (estadoActual.Equals("S11") || estadoActual.Equals("S19") || estadoActual.Equals("S22") || estadoActual.Equals("S24")
                || estadoActual.Equals("S26") || estadoActual.Equals("S28") || estadoActual.Equals("S32")
                || estadoActual.Equals("S42") || estadoActual.Equals("S40") || estadoActual.Equals("SD2")
                || estadoActual.Equals("SA2") || estadoActual.Equals("SA0") || estadoActual.Equals("SD0")
                || estadoActual.Equals("SB2") || estadoActual.Equals("SB0") || estadoActual.Equals("SC0")
                || estadoActual.Equals("SC2")) {

                error = "Se esperaba identificador";
            } else if(estadoActual.Equals("S13") || estadoActual.Equals("S14") || estadoActual.Equals("S3") || estadoActual.Equals("S4")) {
                error = "Se esperaban llaves";
            } else if (estadoActual.Equals("S25") || estadoActual.Equals("S28") || estadoActual.Equals("30") 
                || estadoActual.Equals("S37")|| estadoActual.Equals("S43") || estadoActual.Equals("SA3")
                || estadoActual.Equals("SB3") || estadoActual.Equals("SC3") || estadoActual.Equals("SD3")
                || estadoActual.Equals("SF3") || estadoActual.Equals("SF7") ) {
                error = "Se esperaba valor";
            } else {
                error = "Error desconocido xD  ";
            }errores.AddLast(error + "   " + estadoActual);
        }
       
        public LinkedList<string> getErrores() {
            return this.errores;            
        }
        Boolean sinErrores = false;

        public LinkedList<string> encontrarErrores() {
            if (analizador == null) {
                return errores;
            }
            LinkedList<string> temporal = analizador.sumarErrores(); 
            for (int i = 0; i < temporal.Count; i++) {
                errores.AddLast(temporal.ElementAt<string>(i));
            }
            return errores;
            
        }
        public LinkedList<string> sumarErrores() {
            
            if (analizador == null) {
                return errores;
            }
            LinkedList<string> temporal = analizador.getErrores();
            for (int i = 0; i< temporal.Count; i++) {
                errores.AddLast(temporal.ElementAt<string>(i));
            }
            return errores;
        }

        public void mostrarErrores() {
            if (errores.Count > 0) {
                Error error = new Error(errores);
                error.Visible = true;
                return;
            }
            if(analizador == null) {
                MessageBox.Show("GRAMATICA ACEPTADA :D");
                return;
            }
            LinkedList<string> temporal = analizador.encontrarErrores();
            if (temporal.Count == 0) {
                MessageBox.Show("GRAMATICA ACEPTADA :D");
            } else {
                Error error = new Error(temporal);
                error.Visible = true;
            }
        }
    }
    
}


