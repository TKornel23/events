using System;

namespace Events
{
    class Program
    {

        static void Main(string[] args)
        {
            Sef sef = new Sef();
            sef.RendelesTeljesitve += Sikerult;
            sef.RendelesNemTeljesitheto += NemSikerult;
            Szakacs Béla = new Szakacs("Béla", "viz");
            KorlatosSzakacs Róbert = new KorlatosSzakacs("Robert", "repa", 2);
            

            sef.Felvesz(Béla);
            sef.Megrendeles("poharviz");
            sef.Megrendeles("kecskesajt");

            sef.Felvesz(Róbert);
            sef.Megrendeles("fozelek");           
            sef.Megrendeles("fozelek");            
            sef.Megrendeles("fozelek");
            sef.Megrendeles("fozelek");
            sef.Megrendeles("fozelek");
            

            void Sikerult(string etel)
            {
                Console.WriteLine($"* Sikeres rendelés '{etel}'");
            }

            void NemSikerult(string etel)
            {
                Console.WriteLine($"* Sikertelen rendelés '{etel}'");
            }

        }
        

    }
}
