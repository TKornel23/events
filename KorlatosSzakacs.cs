using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class KorlatosSzakacs: Szakacs
    {
        public int mennyiseg;

        public KorlatosSzakacs(string nev, string specialitas, int mennyiseg) 
            :base(nev, specialitas)
        {
            this.mennyiseg = mennyiseg;
        }

        public event HozzavaloElkeszultKezelo HozzavaloNemKeszithetoEl;

        protected override void Foz()
        {
            mennyiseg--;
            if(mennyiseg >= 0)
            {
                base.Foz();
            }
            else
            {
                HozzavaloNemKeszithetoEl.Invoke(specialitas);
            }        
        }
    }
}
