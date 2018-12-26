using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Compi1_Proyecto1_201503600.Objetos
{
    class Background
    {
        private String nombre;
        private String pathImg;

        public Background(String nombre, String pathImg)
        {
            this.Nombre = nombre;
            this.PathImg = pathImg;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string PathImg { get => pathImg; set => pathImg = value; }
    }
}
