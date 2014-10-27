using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izotermy
{
   public class Dane_podstawowe
    {

       public string test { get; set; }

      public  class Zamawiajacy
        {
            /*
            CB_Miasto
           CB_Dealer
                CB_Przygotowanie_oferty
                CB_Handlowiec
                    CB_Data_wyslania
            */
            public string Miasto { get; set; }
            public string Dealer { get; set; }
            public string Przygotowanie_oferty { get; set; }
            public string Handlowiec { get; set; }
            public string Data_wyslania { get; set; }
            public string Nr_oferty { get; set; }
            public int wypelnienie { get; set; }

        }
      public  class Pojazd
        {
            public string Marka { get; set; }
            public string Model { get; set; }
            public string Rozstaw_osi { get; set; }
            public string Kabina { get; set; }
            public string Kola { get; set; }
            public int wypelnienie { get; set; }

        }
      public  class Zabudowa
        {
            public string Typ_zabudowy { get; set; }
            public string Typ_zabudowy_skrot { get; set; }
            public string Typ_zabudowy_nazwa_na_ofercie { get; set; }
          /*Rozdina zabudowy
           * NS, NSP, NW ze wzgledu na takie samo oswietlenie oraz osprzet dodatkowy =1
            * NI, NK, NKP, NCH =2
            */
            public int Rodziana_zabudow { get; set; }
            public string Dlugosc { get; set; }
            public string Szerokosc { get; set; }
            public string Wysokosc { get; set; }
            public int wypelnieni { get; set; }
            public string Dlugosc_zew { get; set; }
            public string Szerokosc_zew { get; set; }
            public string Wysokosc_zew { get; set; }
            public string Euro_palet { get; set; }
            public string Kubatura { get; set; }
            public string Waga { get; set; }
          

    }
       public class Data
       {
           public string dzien { get; set; }
           public string miesiac { get; set; }
           public string rok { get; set; }
       }

       public class Numer_oferty
       {
           public string Nr_oferty { get; set; }
           public string nr { get; set; }
           public string miesiac { get; set; }
           public string rok { get; set; }
           public string typ_zabudowy { get; set; }
           public string przygotowanie_oferty { get; set; }
           public string Nazwa_pliku { get; set; }
        }
       public class Ceny
       {
           public string cena_podstawowa { get; set; }
           public string cena_dodatkow { get; set; }
       }       
        

    }

}
