using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Compi1_Proyecto1_201503600.Objetos
{
    class Arma
    {
        private String nombre;
        private String pathImg;
        private int destruir;

        public Arma(string nombre, string pathImg, int destruir)
        {
            this.Nombre = nombre;
            this.PathImg = pathImg;
            this.Destruir = destruir;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string PathImg { get => pathImg; set => pathImg = value; }
        public int Destruir { get => destruir; set => destruir = value; }
    }
}
