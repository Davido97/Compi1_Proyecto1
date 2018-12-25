using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Globalization;
using Irony.Parsing;

using proyecto_compi111.Analizadores;
using System.Collections;

namespace proyecto_compi111
{
    public partial class Form1 : Form
    {
        public static LinkedList<String> nombrePersonaje = new LinkedList<string>();
        public static LinkedList<String> vidaPersonaje = new LinkedList<string>();
        public static LinkedList<String> imagenPersonaje = new LinkedList<string>();
        public static LinkedList<String> tipoPersonaje = new LinkedList<string>();
        public static LinkedList<String> descripcionPersonaje = new LinkedList<string>();


        public Form1()
        {
            InitializeComponent();
        }

        private void analizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            analizarTexto(txtentrada.Text);
        }
        public void analizarTexto(String cadena)
        {
            if (cadena.Equals(""))
            {
                MessageBox.Show("NO HAY TEXTO PARA ANALIZAR");

            }
            else
            {
                Gramatica.lista.Clear();
                LanguageData lenguaje = new LanguageData(new Gramatica());
                Parser parser = new Parser(lenguaje);
                ParseTree arbol = parser.Parse(cadena);

                if (arbol.Root != null)
                {
                    Analizadores.graficar ArbolGenerado = new Analizadores.graficar();
                    ArbolGenerado.ConstruirArbol(arbol.Root, "AST_Irony");
                    ArbolGenerado.GraficarArbol("AST_Irony");

                    txtsalida.AppendText("Sintaxis correcta \n");
                }
                else
                {
                    Errores errores = new Errores();
                    errores.GraficarTabla(Gramatica.lista);
                    txtsalida.AppendText("Sintaxis incorrecta \n");
                }

            }



            //ErrorEjecucion errores = new ErrorEjecucion();
            //errores.GraficarTabla(gram.lista);
        }
    }
}
