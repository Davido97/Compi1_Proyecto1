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
         
        public Gramatica() : base(false){
            #region Terminales
            #region PalabrasReservada
            KeyTerm TK_CONFIGURATION = ToTerm("CONFIGURATION"),
                    TK_BACKGROUND = ToTerm("BACKGROUND"),
                    TK_FIGURE = ToTerm("FIGURE"),
                    TK_DESIGN = ToTerm("DESIGN"),
                    TK_X_TIPO = ToTerm("X-TIPO"),
                    TK_X_DESTRUIR = ToTerm("X-DESTRUIR"),
                    TK_X_HEROE = ToTerm("X-HEROE"),
                    
                    TK_X_ENEMIGO = ToTerm("X-ENEMIGO"),
                    TK_X_DESCRIPCION = ToTerm("X-DESCRIPCION"),
                    TK_X_NOMBRE = ToTerm("X-NOMBRE"),
                    TK_X_IMAGEN = ToTerm("X-IMAGEN"),
                    TK_X_CREDITOS = ToTerm("X-CREDITOS"),
                    TK_X_BOMBA = ToTerm("X-BOMBA"),
                    TK_X_ARMA = ToTerm("X-ARMA"),
                    TK_X_META = ToTerm("X-META"),
                    TK_X_BLOQUE = ToTerm("X-BLOQUE"),
                    TK_X_BONUS = ToTerm("X-BONUS"),
                    TK_X_VIDA = ToTerm("X-VIDA"),



            /*TERMINALES PARA EL ARCHIVO NO.2*/

                    TK_X_ESCENARIOS = ToTerm("X-ESCENARIOS"),
                    TK_ALTO = ToTerm("ALTO"),
                   TK_X_PERSONAJES = ToTerm("X-PERSONAJES"),
                   TK_X_HEROES = ToTerm("X-HEROES"),
                   TK_X_VILLANOS = ToTerm("X-VILLANOS"),
                   TK_X_PAREDES = ToTerm("PAREDES"),
                   TK_X_EXTRAS = ToTerm("EXTRAS"),
                   TK_X_ARMAS = ToTerm("X-ARMAS"),
                   TK_ARMAS = ToTerm("ARMAS"),
                   TK_BONUS = ToTerm("BONUS"),
                   TK_META = ToTerm("META"),

                    TK_ANCHO = ToTerm("ANCHO");
                 
           
            MarkReservedWords("CONFIGURATION", "BACKGROUND", "FIGURE", "DESIGN"," X-TIPO", "X_DESTRUIR", "X-DESCRIPCION", "X-NOMBRE", "X-IMAGEN", "X-CREDITOS", "X-BOMBA", "X-ARMA","X-VIDA");
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
                     TK_IGUAL = ToTerm("=");
          
            MarkPunctuation(TK_COMA, TK_PUNTOYCOMA, TK_PARENTESIS_A, TK_PARENTESIS_C, TK_LLAVE_A, TK_LLAVE_C, TK_IGUAL);
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
                SENTENCIAS_DATOS= new NonTerminal("SENTENCIAS_DATOS"),
                SENETENCIAS_DATOS2 = new NonTerminal("SENETENCIAS_DATOS2"),
                 SENTENCIAS_FIGURE = new NonTerminal("SENTENCIAS_FIGURE"),
                  SENTENCIAS_DESIGN = new NonTerminal("SENTENCIAS_DESIGN"),
                   SENTENCIAS_DE_ARCHIVO = new NonTerminal("SENTENCIAS_DE_ARCHIVO"),
                   SENTENCIAS_ARCHIVO2 = new NonTerminal ("SENTENCIAS_ARCHIVO2"),
                   SENTENCIAS_PERSONAJES = new NonTerminal("SENTENCIAS_PERSONAJES"),
                  SENTENCIAS_TIPOS = new NonTerminal("SENTENCIAS_TIPOS"),
                  SENTENCIAS_DESIGN_COMA = new NonTerminal("SENTENCIAS_DESIGN_COMA"),
                  SENTENCIAS_BACKGROUND_COMA = new NonTerminal("SENTENCIAS_BACKGROUND_COMA"),
                  SENTENCIAS_FIGURE_COMA = new NonTerminal("SENTECIAS_FIGURE_COMA"),
                   SENTENCIAS_HEROES = new NonTerminal(" SENTENCIAS_HEROES"),
                   SENTENCIAS_DATOS_PAREDES = new NonTerminal("SENTENCIAS_DATOS_PAREDES"),
                   SENTENCIAS_PAREDES = new NonTerminal("SENTENCIAS_PAREDES"),
                   SENTENCIAS_EXTRAS = new NonTerminal("SENTENCIAS_EXTRAS"),
                   SENTENCIAS_META = new NonTerminal("SENTENCIAS_META"),
                   SENTENCIAS_ARMAS = new NonTerminal("SENTENCIAS_ARMAS"),
                   SENTENCIAS_BONUS = new NonTerminal("SENTENCIAS_BONUS"),
                   SENTENCIA_BONUS = new NonTerminal("SENTENCIA_BONUS"),
                   SETENCIAS_CLICLO_BONUS  = new NonTerminal("SETENCIAS_CLICLO_BONUS"),
                   SENTENCIAS_DATOS_EXTRAS = new NonTerminal("SENTENCIAS_DATOS_EXTRAS"),
                   SENTENCIAS_CICLO_PAREDES = new NonTerminal("SENTENCIAS_CICLO_PAREDES"),
                   SENTENCIAS_CICLO_VILLANOS = new NonTerminal("SENTENCIAS_CICLO_VILLANOS"),
                    SENTENCIAS_VILLANOS = new NonTerminal(" SENTENCIAS_VILLANOS"),
                  DESTRUCCION = new NonTerminal("DESTRUCCION"),
                  XTIPOS = new NonTerminal ("XTIPOS"),
            SENTENCIAS_BACKGROUND = new NonTerminal("SENTENCIAS_BACKGROUND");
            #endregion

            #region Gramatica 
            INICIO.Rule = SENTENCIAS_DE_ARCHIVO;

            SENTENCIAS_DE_ARCHIVO.Rule = SENTENCIAS_ARCHIVO1 | SENTENCIAS_ARCHIVO2;

            SENTENCIAS_ARCHIVO1.Rule = TK_MENOR + TK_CONFIGURATION + TK_MAYOR  + SENTENCIAS_DATOS + TK_MENOR +TK_DIAGONAL + TK_CONFIGURATION + TK_MAYOR;

 SENTENCIAS_DATOS.Rule =  TK_MENOR + TK_BACKGROUND + TK_MAYOR + SENTENCIAS_BACKGROUND + TK_MENOR + TK_DIAGONAL + TK_BACKGROUND + TK_MAYOR 
                         +TK_MENOR +TK_FIGURE+ TK_MAYOR + SENTENCIAS_FIGURE  +TK_MENOR + TK_DIAGONAL +TK_FIGURE+TK_MAYOR 
                         +TK_MENOR + TK_DESIGN +TK_MAYOR + SENTENCIAS_DESIGN +  TK_MENOR +TK_DIAGONAL+TK_DESIGN + TK_MAYOR

                        | TK_MENOR + TK_FIGURE + TK_MAYOR + SENTENCIAS_FIGURE + TK_MENOR + TK_DIAGONAL + TK_FIGURE + TK_MAYOR
                         +TK_MENOR + TK_BACKGROUND + TK_MAYOR + SENTENCIAS_BACKGROUND + TK_MENOR + TK_DIAGONAL + TK_BACKGROUND + TK_MAYOR
                         +TK_MENOR + TK_DESIGN + TK_MAYOR  + SENTENCIAS_DESIGN + TK_MENOR + TK_DIAGONAL + TK_DESIGN + TK_MAYOR
                       
                        | TK_MENOR + TK_FIGURE + TK_MAYOR + SENTENCIAS_FIGURE + TK_MENOR + TK_DIAGONAL + TK_FIGURE + TK_MAYOR
                         + TK_MENOR + TK_DESIGN + TK_MAYOR + SENTENCIAS_DESIGN + TK_MENOR + TK_DIAGONAL + TK_DESIGN + TK_MAYOR
                         + TK_MENOR + TK_BACKGROUND + TK_MAYOR + SENTENCIAS_BACKGROUND + TK_MENOR + TK_DIAGONAL + TK_BACKGROUND + TK_MAYOR
                        
                        | TK_MENOR + TK_DESIGN + TK_MAYOR + SENTENCIAS_DESIGN + TK_MENOR + TK_DIAGONAL + TK_DESIGN + TK_MAYOR
                         +TK_MENOR + TK_FIGURE + TK_MAYOR + SENTENCIAS_FIGURE + TK_MENOR + TK_DIAGONAL + TK_FIGURE + TK_MAYOR
                         +TK_MENOR + TK_BACKGROUND + TK_MAYOR + SENTENCIAS_BACKGROUND + TK_MENOR + TK_DIAGONAL + TK_BACKGROUND + TK_MAYOR

                        | TK_MENOR + TK_DESIGN + TK_MAYOR + SENTENCIAS_DESIGN  + TK_MENOR + TK_DIAGONAL + TK_DESIGN + TK_MAYOR
                         +TK_MENOR + TK_BACKGROUND + TK_MAYOR + SENTENCIAS_BACKGROUND + TK_MENOR + TK_DIAGONAL + TK_BACKGROUND + TK_MAYOR
                         +TK_MENOR + TK_FIGURE + TK_MAYOR + SENTENCIAS_FIGURE + TK_MENOR + TK_DIAGONAL + TK_FIGURE + TK_MAYOR
                         
                        | TK_MENOR + TK_BACKGROUND + TK_MAYOR + SENTENCIAS_BACKGROUND + TK_MENOR + TK_DIAGONAL + TK_BACKGROUND + TK_MAYOR
                         +TK_MENOR + TK_DESIGN + TK_MAYOR + SENTENCIAS_DESIGN + TK_MENOR + TK_DIAGONAL + TK_DESIGN + TK_MAYOR
                         +TK_MENOR + TK_FIGURE + TK_MAYOR +  SENTENCIAS_FIGURE  + TK_MENOR + TK_DIAGONAL + TK_FIGURE + TK_MAYOR;

            SENTENCIAS_BACKGROUND.Rule = TK_LLAVE_A + TK_X_NOMBRE + TK_IGUAL + TK_LETRA + TK_PUNTOYCOMA
                                         + TK_X_IMAGEN + TK_IGUAL + TK_COMILLA  + TK_RUTA + TK_COMILLA + TK_PUNTOYCOMA + TK_LLAVE_C + SENTENCIAS_BACKGROUND_COMA;
                                         
            SENTENCIAS_BACKGROUND_COMA.Rule = TK_COMA+SENTENCIAS_BACKGROUND  | Empty;

            

            SENTENCIAS_FIGURE.Rule = TK_LLAVE_A + TK_X_NOMBRE + TK_IGUAL + TK_LETRA + TK_PUNTOYCOMA
                                     + TK_X_VIDA + TK_IGUAL + TK_NUMEROS + TK_PUNTOYCOMA
                                     + TK_X_IMAGEN + TK_IGUAL + TK_COMILLA + TK_RUTA + TK_COMILLA + TK_PUNTOYCOMA
                                     + TK_X_TIPO + TK_IGUAL + SENTENCIAS_TIPOS  + TK_X_DESCRIPCION
                                     + TK_IGUAL + TK_COMILLA +TK_LETRAS + TK_COMILLA + TK_LLAVE_C + SENTENCIAS_FIGURE_COMA;

                                    
            SENTENCIAS_FIGURE_COMA.Rule = TK_COMA + SENTENCIAS_FIGURE | Empty;

            
            SENTENCIAS_TIPOS.Rule = TK_X_ENEMIGO + TK_PUNTOYCOMA +DESTRUCCION | TK_X_HEROE + TK_PUNTOYCOMA ;
            
            DESTRUCCION.Rule = TK_X_DESTRUIR + TK_IGUAL + TK_NUMEROS + TK_PUNTOYCOMA | Empty;


           SENTENCIAS_DESIGN.Rule = TK_LLAVE_A + TK_X_NOMBRE + TK_IGUAL + TK_LETRA + TK_PUNTOYCOMA + DESTRUCCION
                                    + TK_X_IMAGEN + TK_IGUAL + TK_COMILLA + TK_RUTA + TK_COMILLA + TK_PUNTOYCOMA
                                    + TK_X_TIPO + TK_IGUAL + XTIPOS + TK_LLAVE_C + SENTENCIAS_DESIGN_COMA;

           SENTENCIAS_DESIGN_COMA.Rule = TK_COMA + SENTENCIAS_DESIGN | Empty;

            
            XTIPOS.Rule = TK_X_ARMA + TK_PUNTOYCOMA | TK_X_META + TK_PUNTOYCOMA | TK_X_BLOQUE + TK_PUNTOYCOMA
                            | TK_X_BOMBA + TK_PUNTOYCOMA | TK_X_BONUS + TK_PUNTOYCOMA + TK_X_CREDITOS + TK_IGUAL + TK_NUMEROS + TK_PUNTOYCOMA;


            /*Parte 2 de la gramatica */

            SENTENCIAS_ARCHIVO2.Rule  = TK_MENOR + TK_X_ESCENARIOS + TK_BACKGROUND + TK_IGUAL + TK_LETRAS + TK_PUNTOYCOMA +TK_ANCHO +TK_IGUAL+ TK_NUMEROS +TK_PUNTOYCOMA +TK_ALTO+ TK_IGUAL + TK_NUMEROS +TK_MAYOR +SENETENCIAS_DATOS2/*+SENTENCIAS_PAREDES+SENTENCIAS_EXTRAS+SENTENCIAS_META+ TK_MENOR+ TK_DIAGONAL +TK_X_ESCENARIOS +TK_MAYOR*/;

            SENETENCIAS_DATOS2.Rule =TK_MENOR +TK_X_PERSONAJES + TK_MAYOR +/*SENTENCIAS_PERSONAJES +*/ TK_MENOR +TK_DIAGONAL +TK_X_PERSONAJES+TK_MAYOR  ;

            SENTENCIAS_PERSONAJES.Rule = TK_MENOR + TK_X_HEROES +TK_MAYOR + SENTENCIAS_HEROES + TK_MENOR +TK_DIAGONAL + TK_X_HEROES +TK_MAYOR
                                    +   TK_MENOR + TK_X_VILLANOS + TK_MAYOR + SENTENCIAS_VILLANOS +TK_MENOR + TK_DIAGONAL + TK_X_VILLANOS + TK_MAYOR;

            SENTENCIAS_HEROES.Rule = TK_LETRAS + TK_PARENTESIS_A + TK_NUMEROS + TK_COMA + TK_NUMEROS + TK_PARENTESIS_C + TK_PUNTOYCOMA;



            SENTENCIAS_VILLANOS.Rule =   TK_LETRAS + TK_PARENTESIS_A + TK_NUMEROS + TK_COMA + TK_NUMEROS + TK_PARENTESIS_C + TK_PUNTOYCOMA ;

         /*   SENTENCIAS_CICLO_VILLANOS*/

            SENTENCIAS_PAREDES.Rule = TK_MENOR+ TK_X_PAREDES+ TK_MAYOR + SENTENCIAS_DATOS_PAREDES  + TK_MENOR+ TK_DIAGONAL + TK_X_PAREDES +TK_MAYOR  ;


            SENTENCIAS_DATOS_PAREDES.Rule = TK_LETRAS + TK_PARENTESIS_A + TK_NUMEROS + TK_COMA + TK_NUMEROS + TK_PARENTESIS_C + TK_PUNTOYCOMA /*+ SENTENCIAS_CICLO_PAREDES */;

            /* SENTENCIAS_CICLO_PAREDES.Rule = TK_PUNTOYCOMA +SENTENCIAS_DATOS_PAREDES | TK_PUNTOYCOMA+ Empty ;*/


            SENTENCIAS_EXTRAS.Rule = TK_MENOR + TK_X_EXTRAS + TK_MAYOR +SENTENCIAS_DATOS_EXTRAS + TK_MENOR +TK_DIAGONAL+TK_X_EXTRAS+TK_MAYOR ;

            /*SENTENCIAS_DATOS_EXTRAS.Rule = TK_MENOR +TK_ARMAS + TK_MAYOR + SENTENCIAS_ARMAS +  TK_MENOR + TK_DIAGONAL + TK_ARMAS+ TK_MAYOR + TK_MENOR + TK_BONUS +TK_MAYOR+SENTENCIAS_BONUS+TK_MENOR +TK_DIAGONAL+TK_BONUS+TK_MAYOR;


            SENTENCIAS_ARMAS.Rule = TK_LETRAS+ TK_PARENTESIS_A + TK_NUMEROS + TK_COMA + TK_NUMEROS +TK_PARENTESIS_C+ TK_PUNTOYCOMA ;

            SENTENCIAS_BONUS.Rule = MakePlusRule(SENTENCIAS_BONUS, SENTENCIA_BONUS);
                
            SENTENCIA_BONUS.Rule = TK_LETRAS + TK_PARENTESIS_A + TK_NUMEROS + TK_COMA + TK_NUMEROS + TK_PARENTESIS_C  + TK_PUNTOYCOMA;

            /*SETENCIA_BONUS.Rule =  TK_PUNTOYCOMA + SENTENCIAS_BONUS | TK_PUNTOYCOMA+ Empty ;*/

            SENTENCIAS_META.Rule  =  TK_MENOR  +TK_META +TK_MAYOR+TK_LETRAS+ TK_PARENTESIS_A+TK_NUMEROS+TK_COMA+TK_NUMEROS+TK_PARENTESIS_C+TK_PUNTOYCOMA +TK_MENOR +TK_DIAGONAL +TK_META +TK_MAYOR  ;

    



            #region 
            #endregion

            #endregion



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
