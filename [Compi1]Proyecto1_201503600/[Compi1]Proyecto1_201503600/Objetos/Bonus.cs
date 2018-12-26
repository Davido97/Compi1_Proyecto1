using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Compi1_Proyecto1_201503600.Objetos
{
    class Bonus
    {
        private String nombre;
        private String pathImg;
        private int creditos;

        public Bonus(string nombre, string pathImg, int creditos)
        {
            this.Nombre = nombre;
            this.PathImg = pathImg;
            this.Creditos = creditos;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string PathImg { get => pathImg; set => pathImg = value; }
        public int Creditos { get => creditos; set => creditos = value; }
    }
}
