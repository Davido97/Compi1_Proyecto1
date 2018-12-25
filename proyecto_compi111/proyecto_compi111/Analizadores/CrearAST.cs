using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
namespace proyecto_compi111.Analizadores
{
    class CrearAST
    {
        public static int pase;

        public Object Construir(ParseTreeNode raiz)
        {
            return (Object)auxiliar(raiz);
        }

        public object auxiliar(ParseTreeNode actual)
        {
            if (EstoyAca(actual, "configuracion"))
            {
                foreach (ParseTreeNode hijo in actual.ChildNodes)
                {
                    auxiliar(hijo);
                }
            }
            if (EstoyAca(actual, "figura"))
            {
                Form1.nombrePersonaje.AddLast(actual.ChildNodes[0].ToString());
                Form1.vidaPersonaje.AddLast(actual.ChildNodes[1].ToString());
                Form1.imagenPersonaje.AddLast(actual.ChildNodes[2].ToString());
                Form1.tipoPersonaje.AddLast(actual.ChildNodes[3].ToString());
                Form1.descripcionPersonaje.AddLast(actual.ChildNodes[4].ToString());

            }
            
            return null;
        }

        static bool EstoyAca(ParseTreeNode nodo, string nombre)
        {
            return nodo.Term.Name.Equals(nombre, System.StringComparison.InvariantCultureIgnoreCase);
        }

        static string getLexema(ParseTreeNode nodo)
        {

            return nodo.Token.Text;
        }
    }
}
