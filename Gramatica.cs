using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Irony.Ast;
using Irony;
using Irony.Parsing;
using Irony.Interpreter;
using System.Windows.Forms;

namespace proyecto_compi111.Analizadores
{
    class Gramatica  : Grammar
    {

        public static List<Analizadores.Errores> lista = new List<Analizadores.Errores>();

        public Gramatica() : base(false) {
            #region Terminales
            #region PalabrasReservada
            KeyTerm TK_CONFIGURATION = ToTerm("CONFIGURATION"),
                    TK_BACKGROUND = ToTerm("BACKGROUND"),
                    TK_FIGURE = ToTerm("FIGURE"),
                    TK_DESIGN = ToTerm("DESIGN"),
                    TK_X_NOMBRE = ToTerm("X-NOMBRE"),
                    TK_X_IMAGEN = ToTerm("X-IMAGEN"),
                    TK_X_VIDA = ToTerm("X-VIDA"),
                    TK_X_TIPO = ToTerm("X-TIPO"),
                    TK_X_DESTRUIR = ToTerm("X-DESTRUIR"),
                    TK_X_DESCRIPCION = ToTerm("X-DESCRIPCION"),
                    TK_X_CREDITOS = ToTerm("X-CREDITOS"),
                    TK_X_META = ToTerm("X-META"),
                    TK_X_BOMBA = ToTerm("X-BOMBA"),
                    TK_X_BLOQUE = ToTerm("X-BLOQUE"),
                    TK_X_BONUS = ToTerm("X-BONUS"),
                    TK_X_ARMA = ToTerm("X-ARMA"),
                    TK_X_HEROE = ToTerm("X-HEROE"),
                    TK_X_ENEMIGO = ToTerm("X-ENEMIGO"),

                    /*TERMINALES PARA EL ARCHIVO NO.2*/

                    TK_X_ESCENARIOS = ToTerm("X-ESCENARIOS"),
                    TK_ANCHO = ToTerm("ANCHO"),
                    TK_ALTO = ToTerm("ALTO"),
                    TK_X_PERSONAJES = ToTerm("X-PERSONAJES"),
                    TK_X_HEROES = ToTerm("X-HEROES"),
                    TK_X_VILLANOS = ToTerm("X-VILLANOS"),
                    TK_X_PAREDES = ToTerm("X-PAREDES"),
                    TK_X_EXTRAS = ToTerm("X-EXTRAS"),
                    TK_X_ARMAS = ToTerm("X-ARMAS");

            MarkReservedWords("CONFIGURATION", "BACKGROUND", "FIGURE", "DESIGN", "X-NOMBRE", "X-IMAGEN", "X-VIDA", " X-TIPO", "X-DESTRUIR", "X-DESCRIPCION", "X-CREDITOS",
                "X-META", "X-BOMBA", "X-BLOQUE", "X-BONUS", "X-ARMA", "X-HEROE", "X-ENEMIGO", "X-ESCENARIOS", "ANCHO", "ALTO",
                "X-PERSONAJES", "X-HEROES", "X-VILLANOS", "X-PAREDES", "X-EXTRAS", "X-ARMAS");

            #endregion

            #endregion


            #region OperadoresSimbolos
            Terminal TK_COMA = ToTerm(","),
                     TK_PUNTOYCOMA = ToTerm(";"),
                     TK_PARENTESIS_A = ToTerm("("),
                     TK_PARENTESIS_C = ToTerm(")"),
                     TK_LLAVE_A = ToTerm("{"),
                     TK_LLAVE_C = ToTerm("}"),


                     TK_MENOS = ToTerm("-"),

                     TK_DIAGONAL = ToTerm("/"),

                     TK_MAYOR = ToTerm(">"),
                     TK_MENOR = ToTerm("<"),
                     TK_COMILLA = ToTerm("\""),
                     TK_O = ToTerm("|"),
                     TK_IGUAL = ToTerm("="),
                     TK_PUNTO_PUNTO = ToTerm("..");

            MarkPunctuation(TK_COMA, TK_PUNTOYCOMA, TK_PARENTESIS_A, TK_PARENTESIS_C, TK_LLAVE_A, TK_LLAVE_C, TK_IGUAL, TK_MENOR, TK_MAYOR, TK_DIAGONAL, TK_X_PAREDES);
            #endregion


            #region ExpresionesRegulares

            var TK_ENTERO = TerminalFactory.CreateCSharpNumber("TK_ENTERO");


            var TK_IDENTIFICADOR = new IdentifierTerminal("TK_IDENTIFICADOR", "_", "");
            RegexBasedTerminal TK_RUTA = new RegexBasedTerminal("TK_RUTA", "[A-Za-z0-9_:./]*");
            RegexBasedTerminal TK_LETRA = new RegexBasedTerminal("TK_LETRA", "[A-Za-z0-9_ ]*");
            RegexBasedTerminal TK_LETRAS = new RegexBasedTerminal("TK_LETRA", "[A-Za-z0-9_. ]*");
            RegexBasedTerminal TK_NUMEROS = new RegexBasedTerminal("TK_LETRA", "[0-9]*");
            RegexBasedTerminal TK_NUM = new RegexBasedTerminal("TK_LETRA", "[0-9]");
            var TK_CADENA = TerminalFactory.CreateCSharpString("TK_CADENA");
            #endregion

            #region No Terminales
            NonTerminal INICIO = new NonTerminal("INICIO"),
                SENTENCIAS_ARCHIVO1 = new NonTerminal("SENTENCIA_ARCHIVO1"),
                SENTENCIAS_DATOS = new NonTerminal("SENTENCIAS_DATOS"),
                SENETENCIAS_DATOS2 = new NonTerminal("SENETENCIAS_DATOS2"),
                LISTA_SENETENCIAS_DATOS2 = new NonTerminal("LISTA_SENETENCIAS_DATOS2"),
                LISTA_SENTENCIAS_FIGURE = new NonTerminal("LISTA_SENTENCIAS_FIGURE"),
                 SENTENCIAS_FIGURE = new NonTerminal("SENTENCIAS_FIGURE"),
                 LISTA_PARAM_FIGURE = new NonTerminal("LISTA_PARAM_FIGURE"),
                 PARAM_FIGURE = new NonTerminal("PARAM_FIGURE"),
                  
                   SENTENCIAS_DE_ARCHIVO = new NonTerminal("SENTENCIAS_DE_ARCHIVO"),
                   SENTENCIAS_ARCHIVO2 = new NonTerminal("SENTENCIAS_ARCHIVO2"),
                   LISTA_MODULOS = new NonTerminal("LISTA_MODULOS"),
                   MODULOS = new NonTerminal("MODULOS"),
                   SENTENCIAS_PERSONAJES = new NonTerminal("SENTENCIAS_PERSONAJES"),
                   LISTA_SENTENCIAS_PERSONAJES = new NonTerminal("LISTA_SENTENCIAS_PERSONAJES"),
                  SENTENCIAS_TIPOS = new NonTerminal("SENTENCIAS_TIPOS"),
                  LISTA_SENTENCIAS_DESIGN = new NonTerminal("LISTA_SENTENCIAS_DESIGN"),
                  SENTENCIAS_DESIGN = new NonTerminal("SENTENCIAS_DESIGN"),
                  LISTA_PARAM_DESIGN = new NonTerminal("LISTA_PARAM_DESIGN"),
                  PARAM_DESIGN = new NonTerminal("PARAM_DESIGN"),
                  LISTA_SENTENCIAS_BACKGROUND = new NonTerminal("LISTA_SENTENCIAS_BACKGROUND"),
                   SENTENCIAS_HEROES = new NonTerminal(" SENTENCIAS_HEROES"),
                   LISTA_SENTENCIAS_HEROES = new NonTerminal("LISTA_SENTENCIAS_HEROES"),
                   LISTA_SENTENCIAS_DATOS_PAREDES = new NonTerminal("LISTA_SENTENCIAS_DATOS_PAREDES"),
                   SENTENCIAS_DATOS_PAREDES = new NonTerminal("SENTENCIAS_DATOS_PAREDES"),
                   SENTENCIAS_PAREDES = new NonTerminal("SENTENCIAS_PAREDES"),
                   SENTENCIAS_EXTRAS = new NonTerminal("SENTENCIAS_EXTRAS"),
                   SENTENCIAS_META = new NonTerminal("SENTENCIAS_META"),
                   LISTA_SENTENCIAS_ARMAS = new NonTerminal("LISTA_SENTENCIAS_ARMAS"),
                   SENTENCIAS_ARMAS = new NonTerminal("SENTENCIAS_ARMAS"),
                   LISTA_SENTENCIAS_BONUS = new NonTerminal("LISTA_SENTENCIAS_BONUS"),
                   SENTENCIAS_BONUS = new NonTerminal("SENTENCIAS_BONUS"),
                   SENTENCIAS_DATOS_EXTRAS = new NonTerminal("SENTENCIAS_DATOS_EXTRAS"),
                    SENTENCIAS_VILLANOS = new NonTerminal(" SENTENCIAS_VILLANOS"),
                    LISTA_SENTENCIAS_VILLANOS = new NonTerminal("LISTA_SENTENCIAS_VILLANOS"),
                  DESTRUCCION = new NonTerminal("DESTRUCCION"),
                  RANGO = new NonTerminal("RANGO"),
                  XTIPOS = new NonTerminal("XTIPOS"),
            SENTENCIAS_BACKGROUND = new NonTerminal("SENTENCIAS_BACKGROUND");
            #endregion

            #region Gramatica 
            INICIO.Rule = SENTENCIAS_DE_ARCHIVO;

            SENTENCIAS_DE_ARCHIVO.Rule = SENTENCIAS_ARCHIVO1 | SENTENCIAS_ARCHIVO2;

            SENTENCIAS_ARCHIVO1.Rule = TK_MENOR + TK_CONFIGURATION + TK_MAYOR + SENTENCIAS_DATOS + TK_MENOR +TK_DIAGONAL + TK_CONFIGURATION + TK_MAYOR;


            SENTENCIAS_DATOS.Rule = TK_MENOR + TK_BACKGROUND + TK_MAYOR + LISTA_SENTENCIAS_BACKGROUND + TK_MENOR + TK_DIAGONAL + TK_BACKGROUND + TK_MAYOR 
                                  + TK_MENOR +TK_FIGURE+ TK_MAYOR + LISTA_SENTENCIAS_FIGURE + TK_MENOR + TK_DIAGONAL +TK_FIGURE+TK_MAYOR 
                                  + TK_MENOR + TK_DESIGN +TK_MAYOR + LISTA_SENTENCIAS_DESIGN +  TK_MENOR +TK_DIAGONAL+TK_DESIGN + TK_MAYOR

                                  | TK_MENOR + TK_BACKGROUND + TK_MAYOR /*+ SENTENCIAS_BACKGROUND*/ + TK_MENOR + TK_DIAGONAL + TK_BACKGROUND + TK_MAYOR
                                  + TK_MENOR + TK_DESIGN + TK_MAYOR /*+ SENTENCIAS_DESIGN*/ + TK_MENOR + TK_DIAGONAL + TK_DESIGN + TK_MAYOR
                                  + TK_MENOR + TK_FIGURE + TK_MAYOR /*+ SENTENCIAS_FIGURE*/ + TK_MENOR + TK_DIAGONAL + TK_FIGURE + TK_MAYOR

                                  | TK_MENOR + TK_FIGURE + TK_MAYOR /*+ SENTENCIAS_FIGURE*/ + TK_MENOR + TK_DIAGONAL + TK_FIGURE + TK_MAYOR
                                  + TK_MENOR + TK_BACKGROUND + TK_MAYOR /*+ SENTENCIAS_BACKGROUND*/ + TK_MENOR + TK_DIAGONAL + TK_BACKGROUND + TK_MAYOR
                                  + TK_MENOR + TK_DESIGN + TK_MAYOR  /*+ SENTENCIAS_DESIGN*/ + TK_MENOR + TK_DIAGONAL + TK_DESIGN + TK_MAYOR
                       
                                  | TK_MENOR + TK_FIGURE + TK_MAYOR /*+ SENTENCIAS_FIGURE*/ + TK_MENOR + TK_DIAGONAL + TK_FIGURE + TK_MAYOR
                                  + TK_MENOR + TK_DESIGN + TK_MAYOR /*+ SENTENCIAS_DESIGN*/ + TK_MENOR + TK_DIAGONAL + TK_DESIGN + TK_MAYOR
                                  + TK_MENOR + TK_BACKGROUND + TK_MAYOR /*+ SENTENCIAS_BACKGROUND*/ + TK_MENOR + TK_DIAGONAL + TK_BACKGROUND + TK_MAYOR
                        
                                  | TK_MENOR + TK_DESIGN + TK_MAYOR /*+ SENTENCIAS_DESIGN*/ + TK_MENOR + TK_DIAGONAL + TK_DESIGN + TK_MAYOR
                                  + TK_MENOR + TK_FIGURE + TK_MAYOR /*+ SENTENCIAS_FIGURE*/ + TK_MENOR + TK_DIAGONAL + TK_FIGURE + TK_MAYOR
                                  + TK_MENOR + TK_BACKGROUND + TK_MAYOR /*+ SENTENCIAS_BACKGROUND*/ + TK_MENOR + TK_DIAGONAL + TK_BACKGROUND + TK_MAYOR

                                  | TK_MENOR + TK_DESIGN + TK_MAYOR /*+ SENTENCIAS_DESIGN */ + TK_MENOR + TK_DIAGONAL + TK_DESIGN + TK_MAYOR
                                  + TK_MENOR + TK_BACKGROUND + TK_MAYOR /*+ SENTENCIAS_BACKGROUND */ + TK_MENOR + TK_DIAGONAL + TK_BACKGROUND + TK_MAYOR
                                  + TK_MENOR + TK_FIGURE + TK_MAYOR /*+ SENTENCIAS_FIGURE */ + TK_MENOR + TK_DIAGONAL + TK_FIGURE + TK_MAYOR;

            LISTA_SENTENCIAS_BACKGROUND.Rule = MakePlusRule(LISTA_SENTENCIAS_BACKGROUND, TK_COMA, SENTENCIAS_BACKGROUND);

            SENTENCIAS_BACKGROUND.Rule = TK_LLAVE_A + TK_X_NOMBRE + TK_IGUAL + TK_IDENTIFICADOR + TK_PUNTOYCOMA
                                         + TK_X_IMAGEN + TK_IGUAL + TK_COMILLA  + TK_RUTA + TK_COMILLA + TK_PUNTOYCOMA + TK_LLAVE_C;

            LISTA_SENTENCIAS_FIGURE.Rule = MakePlusRule(LISTA_SENTENCIAS_FIGURE, TK_COMA, SENTENCIAS_FIGURE);
                
            SENTENCIAS_FIGURE.Rule = TK_LLAVE_A + LISTA_PARAM_FIGURE + TK_LLAVE_C;

            LISTA_PARAM_FIGURE.Rule = MakePlusRule(LISTA_PARAM_FIGURE, PARAM_FIGURE);

            PARAM_FIGURE.Rule = TK_X_NOMBRE + TK_IGUAL + TK_IDENTIFICADOR + TK_PUNTOYCOMA
                              | TK_X_VIDA + TK_IGUAL + TK_NUMEROS + TK_PUNTOYCOMA
                              | TK_X_IMAGEN + TK_IGUAL + TK_COMILLA + TK_RUTA + TK_COMILLA + TK_PUNTOYCOMA
                              | TK_X_TIPO + TK_IGUAL + SENTENCIAS_TIPOS + TK_PUNTOYCOMA
                              | TK_X_DESTRUIR + TK_IGUAL + TK_NUMEROS + TK_PUNTOYCOMA
                              | TK_X_DESCRIPCION + TK_IGUAL + TK_COMILLA + TK_LETRAS + TK_COMILLA;

            
            SENTENCIAS_TIPOS.Rule = TK_X_ENEMIGO | TK_X_HEROE ;

            LISTA_SENTENCIAS_DESIGN.Rule = MakePlusRule(LISTA_SENTENCIAS_DESIGN, TK_COMA, SENTENCIAS_DESIGN);


            SENTENCIAS_DESIGN.Rule = TK_LLAVE_A + LISTA_PARAM_DESIGN + TK_LLAVE_C;

            LISTA_PARAM_DESIGN.Rule = MakePlusRule(LISTA_PARAM_DESIGN, PARAM_DESIGN);

            PARAM_DESIGN.Rule = TK_X_NOMBRE + TK_IGUAL + TK_IDENTIFICADOR + TK_PUNTOYCOMA
                              | TK_X_DESTRUIR + TK_IGUAL + TK_NUMEROS + TK_PUNTOYCOMA
                              | TK_X_IMAGEN + TK_IGUAL + TK_COMILLA + TK_RUTA + TK_COMILLA + TK_PUNTOYCOMA
                              | TK_X_TIPO + TK_IGUAL + XTIPOS + TK_PUNTOYCOMA
                              | TK_X_CREDITOS + TK_IGUAL + TK_NUMEROS + TK_PUNTOYCOMA;

            XTIPOS.Rule = TK_X_BOMBA
                        | TK_X_ARMA
                        | TK_X_META
                        | TK_X_BONUS
                        | TK_X_BLOQUE;

            /*Parte 2 de la gramatica */

            SENTENCIAS_ARCHIVO2.Rule  = TK_MENOR + TK_X_ESCENARIOS + TK_BACKGROUND + TK_IGUAL + TK_IDENTIFICADOR + TK_PUNTOYCOMA +TK_ANCHO +TK_IGUAL+ TK_NUMEROS +TK_PUNTOYCOMA +TK_ALTO+ TK_IGUAL + TK_NUMEROS +TK_MAYOR + LISTA_MODULOS + TK_MENOR + TK_DIAGONAL + TK_X_ESCENARIOS + TK_MAYOR;

            LISTA_MODULOS.Rule = MakePlusRule(LISTA_MODULOS, MODULOS);

            MODULOS.Rule = SENETENCIAS_DATOS2
                         | SENTENCIAS_PAREDES
                         | SENTENCIAS_EXTRAS
                         | SENTENCIAS_META;

            SENETENCIAS_DATOS2.Rule = TK_MENOR + TK_X_PERSONAJES + TK_MAYOR + SENTENCIAS_PERSONAJES + TK_MENOR + TK_DIAGONAL + TK_X_PERSONAJES + TK_MAYOR;

            SENTENCIAS_PERSONAJES.Rule = TK_MENOR + TK_X_HEROES + TK_MAYOR + SENTENCIAS_HEROES + TK_MENOR + TK_DIAGONAL + TK_X_HEROES + TK_MAYOR
                                       + TK_MENOR + TK_X_VILLANOS + TK_MAYOR + LISTA_SENTENCIAS_VILLANOS +TK_MENOR + TK_DIAGONAL + TK_X_VILLANOS + TK_MAYOR
                                       | TK_MENOR + TK_X_VILLANOS + TK_MAYOR + LISTA_SENTENCIAS_VILLANOS + TK_MENOR + TK_DIAGONAL + TK_X_VILLANOS + TK_MAYOR
                                       + TK_MENOR + TK_X_HEROES + TK_MAYOR + SENTENCIAS_HEROES + TK_MENOR + TK_DIAGONAL + TK_X_HEROES + TK_MAYOR;

            SENTENCIAS_HEROES.Rule = TK_IDENTIFICADOR + TK_PARENTESIS_A + TK_NUMEROS + TK_COMA + TK_NUMEROS + TK_PARENTESIS_C + TK_PUNTOYCOMA;

            LISTA_SENTENCIAS_VILLANOS.Rule = MakeStarRule(LISTA_SENTENCIAS_VILLANOS, SENTENCIAS_VILLANOS);

            SENTENCIAS_VILLANOS.Rule = TK_IDENTIFICADOR + TK_PARENTESIS_A + TK_NUMEROS + TK_COMA + TK_NUMEROS + TK_PARENTESIS_C + TK_PUNTOYCOMA;

            SENTENCIAS_PAREDES.Rule = TK_MENOR + TK_X_PAREDES + TK_MAYOR + LISTA_SENTENCIAS_DATOS_PAREDES + TK_MENOR + TK_DIAGONAL + TK_X_PAREDES + TK_MAYOR;

            LISTA_SENTENCIAS_DATOS_PAREDES.Rule = MakePlusRule(LISTA_SENTENCIAS_DATOS_PAREDES, SENTENCIAS_DATOS_PAREDES);

            SENTENCIAS_DATOS_PAREDES.Rule = TK_IDENTIFICADOR + TK_PARENTESIS_A + RANGO + TK_PARENTESIS_C + TK_PUNTOYCOMA;

            RANGO.Rule = TK_NUMEROS + TK_COMA + TK_NUMEROS
                       | TK_NUMEROS + TK_PUNTO_PUNTO + TK_NUMEROS + TK_COMA + TK_NUMEROS
                       | TK_NUMEROS + TK_COMA + TK_NUMEROS + TK_PUNTO_PUNTO + TK_NUMEROS;

            SENTENCIAS_EXTRAS.Rule = TK_MENOR + TK_X_EXTRAS + TK_MAYOR + SENTENCIAS_DATOS_EXTRAS + TK_MENOR + TK_DIAGONAL + TK_X_EXTRAS + TK_MAYOR;

            SENTENCIAS_DATOS_EXTRAS.Rule = TK_MENOR + TK_X_ARMAS + TK_MAYOR + LISTA_SENTENCIAS_ARMAS + TK_MENOR + TK_DIAGONAL + TK_X_ARMAS + TK_MAYOR
                                         + TK_MENOR + TK_X_BONUS + TK_MAYOR + LISTA_SENTENCIAS_BONUS + TK_MENOR + TK_DIAGONAL + TK_X_BONUS + TK_MAYOR
                                         | TK_MENOR + TK_X_BONUS + TK_MAYOR + LISTA_SENTENCIAS_BONUS + TK_MENOR + TK_DIAGONAL + TK_X_BONUS + TK_MAYOR
                                         + TK_MENOR + TK_X_ARMAS + TK_MAYOR + LISTA_SENTENCIAS_ARMAS + TK_MENOR + TK_DIAGONAL + TK_X_ARMAS + TK_MAYOR;

            LISTA_SENTENCIAS_ARMAS.Rule = MakePlusRule(LISTA_SENTENCIAS_ARMAS,SENTENCIAS_ARMAS);

            SENTENCIAS_ARMAS.Rule = TK_IDENTIFICADOR + TK_PARENTESIS_A + TK_NUMEROS + TK_COMA + TK_NUMEROS + TK_PARENTESIS_C + TK_PUNTOYCOMA;

            LISTA_SENTENCIAS_BONUS.Rule = MakePlusRule(LISTA_SENTENCIAS_BONUS, SENTENCIAS_BONUS);

            SENTENCIAS_BONUS.Rule = TK_IDENTIFICADOR + TK_PARENTESIS_A + TK_NUMEROS + TK_COMA + TK_NUMEROS + TK_PARENTESIS_C + TK_PUNTOYCOMA;

            SENTENCIAS_META.Rule = TK_MENOR + TK_X_META + TK_MAYOR + TK_IDENTIFICADOR + TK_PARENTESIS_A + TK_NUMEROS + TK_COMA + TK_NUMEROS + TK_PARENTESIS_C + TK_PUNTOYCOMA + TK_MENOR + TK_DIAGONAL + TK_X_META + TK_MAYOR;

            #region 
            #endregion

            #endregion

            MarkTransient(MODULOS,SENTENCIAS_PAREDES);

            #region Precedencia y Asociatividad
            RegisterOperators(1, Associativity.Right, TK_IGUAL);
            RegisterOperators(2, Associativity.Left, TK_MAYOR, TK_MENOR);
            RegisterOperators(3, Associativity.Left,  TK_MENOS);
            RegisterOperators(4, Associativity.Left,  TK_DIAGONAL);
            RegisterOperators(5, Associativity.Neutral, TK_PARENTESIS_A, TK_PARENTESIS_C);
            #endregion



            this.Root = INICIO;
        }

        public override void ReportParseError(ParsingContext context)
        {
            String error = (String)context.CurrentToken.ValueString;
            String tipo;
            int fila;
            int columna;

            if (error.Contains("Invalid character"))
            {
                tipo = "Error Lexico";
                string delimStr = ":";
                char[] delimiter = delimStr.ToCharArray();
                string[] division = error.Split(delimiter, 2);
                division = division[1].Split('.');
                error = "Caracter Invalido " + division[0];
            }
            else
            {
                tipo = "Error Sintactico";
            }

            fila = context.Source.Location.Line + 1;
            columna = context.Source.Location.Column + 1;
            //Errores nuevo = new Errores(tipo, error, fila, columna, "sintactico");
            Analizadores.Errores nuevo = new Analizadores.Errores(error, fila, columna, tipo);
            Gramatica.lista.Add(nuevo);

            base.ReportParseError(context);
        }
    }
}

