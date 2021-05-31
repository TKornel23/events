using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public delegate void RendelesTeljesitoKezelo(string etelNeve);
    public delegate void HozzavaloSzuksegesKezelo(string hozzavalo);
    public delegate void HozzavaloElkeszultKezelo(string hozzavalo);

    public class Etel
    {
        public string megnevezes;
        public string[] hozzavalok;

        public Etel(string megnevezes, string[] hozzavalok)
        {
            this.megnevezes = megnevezes;
            this.hozzavalok = hozzavalok;
        }
    }
}
