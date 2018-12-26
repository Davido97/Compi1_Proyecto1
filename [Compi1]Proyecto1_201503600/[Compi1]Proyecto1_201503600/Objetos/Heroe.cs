using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Compi1_Proyecto1_201503600.Objetos
{
    class Heroe
    {

        private String nombre;
        private String pathImg;
        private int vida;
        private String descripcion;

        public Heroe(string nombre, string pathImg, string descripcion)
        {
            this.Nombre = nombre;
            this.PathImg = pathImg;
            this.Descripcion = descripcion;
            this.Vida = 100;
        }

        public Heroe(string nombre, string pathImg, int vida, string descripcion)
        {
            this.Nombre = nombre;
            this.PathImg = pathImg;
            this.Vida = vida;
            this.Descripcion = descripcion;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string PathImg { get => pathImg; set => pathImg = value; }
        public int Vida { get => vida; set => vida = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
