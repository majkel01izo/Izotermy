using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Base;
using System.Data;

namespace Izotermy
{
    public static class DAL
    {
        public static string G_Numer_oferty
        {
            get
            {
                
                DB_Connection db = new DB_Connection();
                string numer_oferty = db.DB_Select_string("numer_oferty", "MAX(idNumer_Oferty)");
                int nr_oferty;
                nr_oferty = int.Parse(numer_oferty);
                nr_oferty++;

                return nr_oferty.ToString();
            }
        }
        public static void S_Numer_oferty(Dane_podstawowe.Numer_oferty nr_of)
        {
            DB_Connection db = new DB_Connection();
            db.Insert_oferta(nr_of.miesiac, nr_of.rok, nr_of.typ_zabudowy, nr_of.przygotowanie_oferty);
         }
        public static string G_cena_podstawowa(Dane_podstawowe.Zabudowa zab)
        {
                DB_Connection db = new DB_Connection();
                   
                int dlugosc;
                int.TryParse(zab.Dlugosc, out dlugosc);
                int reszta = dlugosc % 200;
                

                if (reszta>=100)
                    {
                        dlugosc=dlugosc + 200-reszta;
                    }
                else
                {
                    dlugosc=dlugosc-reszta;

                }

                string cena;
                
            cena = db.DB_Select_string("cennik", zab.Typ_zabudowy_skrot, "dlugosc = " + dlugosc);

            return cena;
            
        }
    public static List <string> G_kabina_sypialna
        {
            get
            {
                using (DB_Connection db = new DB_Connection())
                {

                    return db.DB_Select_list("kabina_sypialna", "kabina_sypialna");
                }
            }

        }
    public static List<string> G_spoiler_dachowy
    {
        get
        {
            using (DB_Connection db = new DB_Connection())
            {

                return db.DB_Select_list("typ", "spoiler_dachowy");
            }
        }

    }
    public static List<string> G_system_firankowy
    {
        get
        {
            using (DB_Connection db = new DB_Connection())
            {

                return db.DB_Select_list("typ", "system_firankowy");
            }
        }

    }
    public static List<string> G_poduszki_powietrzne
    {
        get
        {
            using (DB_Connection db = new DB_Connection())
            {

                return db.DB_Select_list("typ", "poduszki_powietrzne");
            }
        }

    }
    public static List<string> G_plandeka_kolor
    {
        get
        {
            using (DB_Connection db = new DB_Connection())
            {

                return db.DB_Select_list("kolor", "plandeka_kolor");
            }
        }

    }
    public static List<string> G_skrzynka_narzedziowa
    {
        get
        {
            using (DB_Connection db = new DB_Connection())
            {

                return db.DB_Select_list("typ", "skrzynka_narzedziowa");
            }
        }

    }

    public static DataTable G_opcje_dodatkowe
    {
        get
        {
            using (DB_Connection db = new DB_Connection())
            {

                return db.DB_Select("opcje_dodatkowe_ceny");
            }
        }

    }
    public static DataTable G_wymiary_zewnetrzne(Dane_podstawowe.Zabudowa zab)
    {
        
        
            using (DB_Connection db = new DB_Connection())
            {

                return db.Select_where("Dlugosc,Szerokosc,Wysokosc", "wymiary_zewnetrzne", "Typ_zabudowy = '" + zab.Typ_zabudowy_skrot+"'");
            }
        

    }


    }
}
/*

                        tmp=db.DB_Select("kabina_sypialna");
                        NSP_kabina.ItemsSource = tmp.DefaultView;
                        NSP_kabina.DisplayMemberPath = tmp.Columns[1].ToString();

                        tmp = db.DB_Select("spoiler_dachowy");
                        NSP_spoiler.ItemsSource = tmp.DefaultView;
                        NSP_spoiler.DisplayMemberPath = tmp.Columns[1].ToString();

                        tmp = db.DB_Select("system_firankowy");
                        NSP_system_firankowy.ItemsSource = tmp.DefaultView;
                        NSP_system_firankowy.DisplayMemberPath = tmp.Columns[1].ToString();

                        tmp = db.DB_Select("poduszki_powietrzne");
                        NSP_poduszki_powietrzne.ItemsSource = tmp.DefaultView;
                        NSP_poduszki_powietrzne.DisplayMemberPath = tmp.Columns[1].ToString();

                        tmp = db.DB_Select("plandeka_kolor");
                        NSP_plandeka_kolor.ItemsSource = tmp.DefaultView;
                        NSP_plandeka_kolor.DisplayMemberPath = tmp.Columns[1].ToString();

                        tmp = db.DB_Select("skrzynka_narzedziowa");
                        NSP_skrzynka_narzedziowa.ItemsSource = tmp.DefaultView;
                        NSP_skrzynka_narzedziowa.DisplayMemberPath = tmp.Columns[1].ToString();
            
*/