using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Compi1_Proyecto1_201503600.Objetos
{
    class Enemigo
    {
        private String nombre;
        private String pathImg;
        private int vida;
        private int destruir;
        private String descripcion;

        public Enemigo(string nombre, string pathImg, int vida, int destruir, string descripcion)
        {
            this.Nombre = nombre;
            this.PathImg = pathImg;
            this.Vida = vida;
            this.Destruir = destruir;
            this.Descripcion = descripcion;
        }

        public Enemigo(string nombre, string pathImg, int destruir, string descripcion)
        {
            this.Nombre = nombre;
            this.PathImg = pathImg;
            this.Vida = 100;
            this.Destruir = destruir;
            this.Descripcion = descripcion;
        }
        
        public string Nombre { get => nombre; set => nombre = value; }
        public string PathImg { get => pathImg; set => pathImg = value; }
        public int Vida { get => vida; set => vida = value; }
        public int Destruir { get => destruir; set => destruir = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

    }
}
