using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_compi111.Analizadores
{
     public class Errores
    {
        String Error;
        String ambiente;
        String tipo;
        string linea;
        string columna;

        public Errores(String Error, String ambiente)
        {
            this.Error = Error;
            this.ambiente = ambiente;
            this.tipo = "semantico";
        }

        public Errores(String Error, String ambiente, String tipo)
        {
            this.Error = Error;
            this.ambiente = ambiente;
            this.tipo = tipo;
            this.linea = "-";
            this.columna = "-";
        }

        public Errores(String Error, int linea, int columna, String tipo)
        {
            this.Error = Error;
            this.linea = linea.ToString();
            this.columna = columna.ToString();
            this.tipo = tipo;
        }

        public Errores()
        {

        }

        public void GraficarTabla(List<Errores> listaErrores)
        {

            String tablasimboloshtml = "";

            int año = DateTime.Now.Year;
            int mes = DateTime.Now.Month;
            int dia = DateTime.Now.Day;
            int hora = DateTime.Now.Hour;
            int minuto = DateTime.Now.Minute;
            int segundo = DateTime.Now.Second;

            tablasimboloshtml += "<html>\n\t<head>\n\t\t<title>Tabla de Simbolos</title>" + "<meta charset=" + "\"" + "utf-8" + "\"" + ">"
                    + "\n\t</head>\n\t<body>"
                    + "\n\t\t<div style=" + "\"" + "text-align:left;" + "\"" + ">"
                    + "\n\t\t\t<h1>TABLA DE ERRORES</h1>"
                    + "\n\t\t\t<h2>Dia de ejecución:" + dia + " de " + getMes(mes) + " de " + año + "</h2>"
                    + "\n\t\t\t<h2>Hora de ejecución:" + hora + ":" + minuto + ":" + segundo + " " + "</h2>"
                    + "\n\t\t\t<table style=\"margin: margin: 5 auto;\" border=\"2\">\n";
            tablasimboloshtml += "\t\t\t\t<TR>\n\t\t\t\t\t<TH>Linea</TH> <TH>Columna</TH> <TH>Tipo de Error</TH><TH>Descripción</TH>\n\t\t\t\t</TR>";

            foreach (Errores nodo in listaErrores)
            {
                tablasimboloshtml += "\n\t\t\t\t<TR>";
                tablasimboloshtml += "\n\t\t\t\t\t" + "<TD>" + nodo.linea + "</TD>" + "<TD>" + nodo.columna + "</TD>" + "<TD>" + nodo.tipo + "</TD>" + "<TD>" + nodo.Error + "</TD>";
                tablasimboloshtml += "\n\t\t\t\t</TR>";
            }

            tablasimboloshtml += "\n\t\t\t</table>\n\t\t</div>\n\t</body>\n</html>";

            System.IO.StreamWriter w = new System.IO.StreamWriter("TablaErrores.html");
            w.WriteLine(tablasimboloshtml);
            w.Close();
        }

        public String getMes(int mes)
        {
            String m = "";
            switch (mes)
            {
                case 1:
                    m = "Enero";
                    break;
                case 2:
                    m = "Febrero";
                    break;
                case 3:
                    m = "Marzo";
                    break;
                case 4:
                    m = "Abril";
                    break;
                case 5:
                    m = "Mayo";
                    break;
                case 6:
                    m = "Junio";
                    break;
                case 7:
                    m = "Julio";
                    break;
                case 8:
                    m = "Agosto";
                    break;
                case 9:
                    m = "Septiembre";
                    break;
                case 10:
                    m = "Octubre";
                    break;
                case 11:
                    m = "Noviembre";
                    break;
                default:
                    m = "Diciembre";
                    break;
            }
            return m;
        }
    }
}
