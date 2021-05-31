using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class Szakacs
    {
        public string nev { get; }
        public string specialitas;

        public Szakacs(string nev, string specialitas)
        {
            this.nev = nev;
            this.specialitas = specialitas;
        }

        public event HozzavaloElkeszultKezelo HozzavaloElkeszult;

        public void SefKerValamit(string hozzavalo)
        {
            if (hozzavalo == specialitas)
            {
                Foz();
            }
        }

        protected virtual void Foz()
        {
            Console.WriteLine($"{nev} főz {specialitas}-et");
            HozzavaloElkeszult.Invoke(specialitas);
        }
    }
}
