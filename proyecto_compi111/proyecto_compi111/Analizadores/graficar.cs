using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.IO;

namespace proyecto_compi111.Analizadores
{
    class graficar
    {
        protected String graph;

        public graficar() { }

        public void ConstruirArbol(ParseTreeNode raiz, String nombre)
        {
            //StreamWriter archivo = new StreamWriter("C:/precedencia/AST.dot");
            StreamWriter archivo = new StreamWriter(nombre + ".dot");
            archivo.Write("digraph lista{ \n\trankdir=TB;\n\tnode[shape = box, style = filled, color = white]; ");
            graph = "";
            GenerarNodo(raiz);
            archivo.Write(graph);
            archivo.Write("}");
            archivo.Close();
        }

        private void GenerarNodo(ParseTreeNode NodoActual)
        {
            graph += "\n\tnodo" + NodoActual.GetHashCode() + "[label=\"" + NodoActual.ToString().Replace("\"", "\\\"") + " \", fillcolor=\"LightBlue\", style =\"filled\", shape=\"box\"]; \n";

            if (NodoActual.ChildNodes.Count > 0)
            {
                ParseTreeNode[] NodosHijos = NodoActual.ChildNodes.ToArray();
                for (int i = 0; i < NodoActual.ChildNodes.Count; i++)
                {
                    GenerarNodo(NodosHijos[i]);
                    graph += "\"nodo" + NodoActual.GetHashCode() + "\"-> \"nodo" + NodosHijos[i].GetHashCode() + "\" \n";
                }
            }
        }

        public void GraficarArbol(String nombre)
        {
            try
            {
                //var command = string.Format("dot -Tjpg C:/precedencia/AST.dot -o C:/precedencia/AST.jpg");
                var command = string.Format("dot -Tjpg " + nombre + ".dot -o " + nombre + ".jpg");
                var procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C " + command);
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception x)
            {

            }
        }
    }

}
