using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLenguaje {


    class preToken {
        char valor;
        private Tipo tipo;
        Token.Tipo tokenTipo;
        public preToken() {

        }

        public enum Tipo {
            L,
            E,
            P,
            B,
            U,
            S,
            C,
            F,
            Mayor,
            Menor,
            Admiracion,
            Igual,
            And,
            Or
        }

        public string getTipo() {
            switch (tipo) {
                case Tipo.L:
                    return "L";
                case Tipo.E:
                    return "E";
                case Tipo.P:
                    return "P";
                case Tipo.B:
                    return "B";
                case Tipo.U:
                    return "U";
                case Tipo.S:
                    return "S";
                case Tipo.C:
                    return "C";
                case Tipo.Menor:
                    return "<";
                case Tipo.Mayor:
                    return ">";
                case Tipo.Igual:
                    return "=";
                case Tipo.Admiracion:
                    return "!";
                case Tipo.And:
                    return "&";
                case Tipo.Or:
                    return "|";
                default:
                    return "F";
            }
            
            
        }
        public void setValues(char valor, preToken.Tipo tipo) {
            this.valor = valor;
            this.tipo = tipo;
        }
            public void setValue(char valor) {
            this.valor = valor;
        }
        public void setTipo(preToken.Tipo tipo) {
            this.tipo = tipo;
        }
        public Boolean encontrarFin() {
            char actual = valor;
            int ascii = valor;
            if (ascii == 42 || ascii == 43 || ascii == 45 || ascii == 47
                ||ascii == 60 || ascii == 61 || ascii == 62) {
                return true;
            }
            return false;
        }

        public Boolean isSymbol() {
            switch (valor) {
                    
                case '+':
                    this.tokenTipo = Token.Tipo.OPERADOR_ARITMETICO;
                    return true;
                    
                case '-':
                    this.tokenTipo = Token.Tipo.OPERADOR_ARITMETICO;
                    return true;
                    
                case ';':
                    this.tokenTipo = Token.Tipo.FIN;
                    return true;
                    
                case '*':
                    this.tokenTipo = Token.Tipo.OPERADOR_ARITMETICO;
                    return true;
                    
                case '/':
                    this.tokenTipo = Token.Tipo.OPERADOR_ARITMETICO;
                    return true;
                          
                case '{':
                    this.tokenTipo = Token.Tipo.LLAVE_APERTURA;
                    return true;
                    
                case '}':
                    this.tokenTipo = Token.Tipo.LLAVE_CIERRE;
                    return true;
                    
                case '(':
                    this.tokenTipo = Token.Tipo.PARENTESIS_APERTURA;
                    return true;
                    
                case ')':
                    this.tokenTipo = Token.Tipo.PARENTESIS_CIERRE;
                    return true;
                case ',':
                    this.tokenTipo = Token.Tipo.COMMAS;
                    return true;

                default:
                    return false;
                    
            }
        }

        public Token.Tipo GetTipo() {
            return this.tokenTipo;
        }

        public Boolean setTipo(char charActual) {
            this.valor = charActual;
            if (char.IsNumber(charActual)) {
                this.tipo = Tipo.E;
                return true;
            } else if (char.IsLetter(charActual)) {
                this.tipo = Tipo.L;
                return true;
            } else if (char.IsWhiteSpace(charActual)) {
                this.tipo = Tipo.B;
                return true;
            } else if ((charActual) == (char)46) {
                this.tipo = Tipo.P;
                return true;
            } else if ((charActual) == (char)34) {
                this.tipo = Tipo.C;
                return true;
            } else if ((charActual) == (char)95) {
                this.tipo = Tipo.U;
                return true;
            } else if (charActual == (char)60) {
                this.tipo = Tipo.Menor;
                return true;
            } else if (charActual == (char)61) {
                this.tipo = Tipo.Igual;
                return true;
            } else if (charActual == (char)62) {
                this.tipo = Tipo.Mayor;
                return true;
            } else if (charActual == (char)33) {
                this.tipo = Tipo.Admiracion;
                return true;
            } else if (charActual == (char)38) {
                this.tipo = Tipo.And;
                return true;
            } else if (charActual == (char)124) {
                this.tipo = Tipo.Or;
                return true;
            } else if (charActual == (char)59) {
                this.tipo = Tipo.S;
                return true;
            } else if (char.IsSymbol(charActual)) {
                this.tipo = Tipo.S;
                return true;
            } else {
                this.tipo = Tipo.F;
                return false;
            }

        }
    }

    


}
