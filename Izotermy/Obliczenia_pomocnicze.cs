using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Izotermy
{
    public static class Obliczenia_pomocnicze
    {
     public static int Ilosc_europalet (Dane_podstawowe.Zabudowa zab)
        {
            int dlugosc;
             dlugosc = int.Parse(zab.Dlugosc);

         /*
         int lewa_strona = dlugosc/800;
         int prawa_strona = dlugosc / 1200;
         */
         /**** podzial zabudowy najpierw na 2400 => 5 palet 
          *  nastepnie 4 palety */

             int paczka_5;
             int paczka_4;
             int paczka_3;
             int paczka_2;
             int pozostalo_do_podzialu;

             paczka_5 = dlugosc / 2400;
             pozostalo_do_podzialu = dlugosc - paczka_5 * 2400;
             
            paczka_4 = pozostalo_do_podzialu / 2000;
            pozostalo_do_podzialu = dlugosc - (paczka_5 * 2400) - (paczka_4 * 2000);

            paczka_3 = pozostalo_do_podzialu / 1600;
            pozostalo_do_podzialu = pozostalo_do_podzialu - paczka_3 * 1600;

            paczka_2 = pozostalo_do_podzialu / 800;

            // paczka_3 = dlugosc - (paczka_5 * 2400) - (paczka_4 * 2000);
            // paczka_3 = paczka_3 / 1600;

             paczka_5 = paczka_5 * 5;
             paczka_4 = paczka_4 * 4;
             paczka_3 = paczka_3 * 3;
             paczka_2 = paczka_2 * 2;
            return paczka_5+paczka_4+paczka_3+paczka_2;
        }
     public static int Kubatura(Dane_podstawowe.Zabudowa zab)
     {
         int dlugosc,szerokosc,wysokosc;

         dlugosc = (int.Parse(zab.Dlugosc))/1000;
         szerokosc = (int.Parse(zab.Szerokosc))/1000;
         wysokosc = (int.Parse(zab.Wysokosc))/1000;


         return (dlugosc * szerokosc * wysokosc);
     }
        public static Dane_podstawowe.Numer_oferty Numer_oferty(Dane_podstawowe.Data data, Dane_podstawowe.Zabudowa zab, Dane_podstawowe.Zamawiajacy zam)
     {
         Dane_podstawowe.Numer_oferty nr_of = new Dane_podstawowe.Numer_oferty();
         nr_of.nr = DAL.G_Numer_oferty;
         nr_of.miesiac = data.miesiac;
         nr_of.rok = data.rok;
         nr_of.typ_zabudowy = zab.Typ_zabudowy_skrot;
         nr_of.przygotowanie_oferty = zam.Przygotowanie_oferty;
         nr_of.Nr_oferty = nr_of.nr + "/" + data.miesiac + "/" + data.rok + "/" + zab.Typ_zabudowy_skrot + "/" + zam.Przygotowanie_oferty;
         nr_of.Nazwa_pliku= nr_of.nr + "_" + data.miesiac + "_" + data.rok + "_" + zab.Typ_zabudowy_skrot + "_" + zam.Przygotowanie_oferty;

            return nr_of;
     }
        public static DataTable Opcje_dodatkowe()
        {
            DataTable opcje_dodatkowe = new DataTable();
            opcje_dodatkowe.Columns.Add("Nazwa", typeof(string));
            opcje_dodatkowe.Columns.Add("Cena", typeof(string));
            opcje_dodatkowe.Columns.Add("Waga", typeof(int));
            opcje_dodatkowe.Columns.Add("Nazwa_na_ofercie", typeof(string));

            return opcje_dodatkowe;
        }

        public static void Wymiary_zewnetrzne(Dane_podstawowe.Zabudowa zab)
        {
         
            DataTable wymiary = DAL.G_wymiary_zewnetrzne(zab);
         
            zab.Dlugosc_zew = ((int.Parse(zab.Dlugosc)) +  int.Parse(wymiary.Rows[0].ItemArray[0].ToString())).ToString();
            zab.Szerokosc_zew = ((int.Parse(zab.Szerokosc)) + int.Parse(wymiary.Rows[0].ItemArray[1].ToString())).ToString();
            zab.Wysokosc_zew = ((int.Parse(zab.Wysokosc)) + int.Parse(wymiary.Rows[0].ItemArray[2].ToString())).ToString();

        }
    }
}
