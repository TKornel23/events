using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    class Sef
    {
        Etel[] receptek = new Etel[]
        {
            new Etel("poharviz", new string[] { "viz" } ),
            new Etel("leves", new string[] { "repa", "hus", "krumpli", "viz" } ),
            new Etel("rantothus", new string[] { "hus", "krumpli" } ),
            new Etel("fozelek", new string[] { "viz", "repa" } )

        };

        private Etel cel;
        private int szuksegesHozzavaloSzam;
            

        public event RendelesTeljesitoKezelo RendelesTeljesitve;
        public event RendelesTeljesitoKezelo RendelesNemTeljesitheto;
        public event HozzavaloSzuksegesKezelo HozzavaloSzukseges;

        public void Megrendeles(string etelNeve)
        {
            Console.WriteLine($"Séf: Rendelés beérkezett: '{etelNeve}'");
            int i = 0;
            while(i < receptek.Length && receptek[i].megnevezes != etelNeve)
            {
                i++;
            }
            if(i < receptek.Length)
            {
                Elkeszites(receptek[i]);
            }
            else
            {
                RendelesNemTeljesitheto.Invoke(etelNeve);
            }          
        }
        public void Elkeszites(Etel recept)
        {
            cel = recept;
            szuksegesHozzavaloSzam = cel.hozzavalok.Length;
            for (int i = 0; i <= szuksegesHozzavaloSzam; i++)
            {
                HozzavaloSzukseges.Invoke(recept.hozzavalok[i]);
            }
        }
        public void SzakacsElkeszult(string hozzavalo)
        {

            szuksegesHozzavaloSzam -= 1;
            Console.WriteLine($"Séf: Elkészül a '{hozzavalo}'");
            if (szuksegesHozzavaloSzam == 0)
            {
                RendelesTeljesitve.Invoke(cel.megnevezes);
            }       
        }
        public void Felvesz(Szakacs szakacs)
        {
            HozzavaloSzukseges += szakacs.SefKerValamit;
            szakacs.HozzavaloElkeszult += SzakacsElkeszult;
            if(szakacs is KorlatosSzakacs)
            {
                (szakacs as KorlatosSzakacs).HozzavaloNemKeszithetoEl += SzakacsHibatJelez;
            }
        }
        
        public void SzakacsHibatJelez(string hozzavalo)
        {
            Console.WriteLine($"Séf: Szakács hibát jelzett '{hozzavalo}'");
            RendelesNemTeljesitheto.Invoke(cel.megnevezes);
        }
    }
}
