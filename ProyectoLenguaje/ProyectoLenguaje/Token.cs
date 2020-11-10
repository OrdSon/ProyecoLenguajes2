using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLenguaje
{
    public class Token
    {
        public enum Tipo
        {
            PRINCIPAL,
            TIPO_OBJETO,
            IDENTIFICADOR,//PALABRA CUALQUIERA
            VALOR_ENTERO,//INT
            ENTERO,
            DECIMAL,
            BOOLEAN,
            CHART,
            CADENA,
            VALOR_DECIMAL,
            VALOR_CADENA,
            VALOR_BOOLEAN,
            VALOR_CHART,
            OPERADOR_ARITMETICO,//+ - / ++ -=
            OPERADOR_RELACIONAL,// == != < > <= >=
            OPERADOR_LOGICO,//|| && ! | &
            PARENTESIS_APERTURA,
            PARENTESIS_CIERRE,
            LLAVE_APERTURA,
            LLAVE_CIERRE,
            ASIGNACION,//SIGNO IGUAL
            SI,
            SI_NO,
            SINOSI,
            MIENTRAS,
            HACER,
            DESDE,
            HASTA,
            INCREMENTO,
            TRUE,
            FALSE,
            PRINT,
            READ,
            COMMAS,
            FIN,
            NEGACION,
            ERROR
        }

        private Tipo tipoToken;
        private String valor;
        int size;
        int posicion;
        Color color;
        public Token(Tipo tipoToken, String valor, int size, int posicion)
        {
            this.tipoToken = tipoToken;
            this.valor = valor;
            this.size = size;
            this.posicion = posicion;
            Console.WriteLine("guardado");
        }
        public Token() {
            
        }


        public Token.Tipo GetTipoToken() {
            return this.tipoToken;
        }

        public Color getColor() {
            return this.color;
        }

        public void revisarTipo() {
            Token.Tipo tipoActual = tipoToken;
            string valorActual = valor;
            if (tipoActual.Equals(Token.Tipo.IDENTIFICADOR)) {
                switch (valorActual) {
                    case "SI":
                        this.tipoToken = Tipo.SI;
                        break;
                    case "SI_NO":
                        this.tipoToken = Tipo.SI_NO;
                        break;
                    case "SINO_SI":
                        this.tipoToken = Tipo.SINOSI;
                        break;
                    case "MIENTRAS":
                        this.tipoToken = Tipo.MIENTRAS;
                        break;
                    case "HACER":
                        this.tipoToken = Tipo.HACER;
                        break;
                    case "DESDE":
                        this.tipoToken = Tipo.DESDE;
                        break;
                    case "HASTA":
                        this.tipoToken = Tipo.HASTA;
                        break;
                    case "INCREMENTO":
                        this.tipoToken = Tipo.INCREMENTO;
                        break;
                    case "Entero":
                        this.tipoToken = Tipo.ENTERO;
                        break;
                    case "Decimal":
                        this.tipoToken = Tipo.DECIMAL;
                        break;
                    case "Cadena":
                        this.tipoToken = Tipo.CADENA;
                        break;
                    case "Boolean":
                        this.tipoToken = Tipo.BOOLEAN;
                        break;
                    case "Chart":
                        this.tipoToken = Tipo.CHART;
                        break;
                    case "verdadero":
                        this.tipoToken = Tipo.TRUE;
                        break;
                    case "falso":
                        this.tipoToken = Tipo.FALSE;
                        break;
                    case "imprimir":
                        this.tipoToken = Tipo.PRINT;
                        break;
                    case "leer":
                        this.tipoToken = Tipo.READ;
                        break; 
                    case "Principal":
                        this.tipoToken = Tipo.PRINCIPAL;
                        break;
                    default:
                        
                        break;
                }
            }

            
        }

        public String getValor(){
            return valor;
        }

        public int getPosicion(){
            return posicion;
        }
        public int getSize() {
            return size;
        }
        public string getTipo()
        {  
            switch (tipoToken){
                case Tipo.TIPO_OBJETO:
                    return "tipo de objeto";                   
                case Tipo.IDENTIFICADOR:
                    this.color = Color.Cyan;
                    return "identificador";
                case Tipo.VALOR_ENTERO:
                    this.color = Color.MediumPurple;
                    return "valor entero";
                case Tipo.VALOR_DECIMAL:
                    this.color = Color.SkyBlue;
                    return "valor decimal";
                case Tipo.VALOR_CADENA:
                    this.color = Color.Yellow;
                    return "valor cadena";
                case Tipo.VALOR_BOOLEAN:
                    this.color = Color.Orange;
                    return "valor boolean";
                case Tipo.VALOR_CHART:
                    this.color = Color.RosyBrown;
                    return "valor chart";
                case Tipo.OPERADOR_ARITMETICO:
                    this.color = Color.DarkBlue;
                    return "operador aritmetico";
                case Tipo.OPERADOR_RELACIONAL:
                    this.color = Color.DarkBlue;
                    return "operador relacional";
                case Tipo.OPERADOR_LOGICO:
                    this.color = Color.DarkBlue;
                    return "operador logico";
                case Tipo.PARENTESIS_APERTURA:
                    this.color = Color.DarkBlue;
                    return "parentesis apertura";
                case Tipo.PARENTESIS_CIERRE:
                    this.color = Color.DarkBlue;
                    return "parentesis cierre";
                case Tipo.LLAVE_APERTURA:
                    this.color = Color.Black;
                    return "llave apertura";
                case Tipo.LLAVE_CIERRE:
                    this.color = Color.Black;
                    return "llave cierre";
                case Tipo.ASIGNACION:
                    this.color = Color.DarkBlue;
                    return "asignacion";
                case Tipo.SI:
                    this.color = Color.GreenYellow;
                    return "SI";
                case Tipo.SI_NO:
                    this.color = Color.GreenYellow;
                    return "SINO";
                case Tipo.SINOSI:
                    this.color = Color.GreenYellow;
                    return "SINOSI";
                case Tipo.MIENTRAS:
                    this.color = Color.GreenYellow;
                    return "MIENTRAS";
                case Tipo.HACER:
                    this.color = Color.GreenYellow;
                    return "HACER";
                case Tipo.DESDE:
                    this.color = Color.GreenYellow;
                    return "DESDE";
                case Tipo.HASTA:
                    this.color = Color.GreenYellow;
                    return "HASTA";
                case Tipo.INCREMENTO:
                    this.color = Color.GreenYellow;
                    return "INCREMENTO";
                case Tipo.FIN:
                    this.color = Color.Black;
                    return "FIN";
                case Tipo.COMMAS:
                    this.color = Color.Black;
                    return "coma";
                case Tipo.ENTERO:
                    this.color = Color.GreenYellow;
                    return "Entero";
                case Tipo.DECIMAL:
                    this.color = Color.GreenYellow;
                    return "Decimal";
                case Tipo.BOOLEAN:
                    this.color = Color.Black;
                    return "Boolean";
                case Tipo.CHART:
                    this.color = Color.Black;
                    return "Chart";
                case Tipo.TRUE:
                    this.color = Color.Black;
                    return "verdadero";
                case Tipo.FALSE:
                    this.color = Color.Black;
                    return "falso";
                case Tipo.PRINT:
                    this.color = Color.Black;
                    return "imprimir";
                case Tipo.READ:
                    this.color = Color.Black;
                    return "leer";
                case Tipo.PRINCIPAL:
                    this.color = Color.Cyan;
                    return "Principal";
                case Tipo.CADENA:
                    this.color = Color.Yellow;
                    return "Cadena";
                case Tipo.NEGACION:
                    this.color = Color.Yellow;
                    return "Negacion";
                default:
                    return "ERROR";
            }
        }

    }
}
