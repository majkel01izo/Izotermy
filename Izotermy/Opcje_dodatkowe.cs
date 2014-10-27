using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Izotermy;

namespace Izotermy
{
    class  Opcje_dodatkowe
    {
       private DataTable opcje_z_formularza;
        private DataTable opcje_z_bazy;

        public Opcje_dodatkowe ()
        {
            opcje_z_formularza = new DataTable();
            opcje_z_formularza.Columns.Add("Nazwa", typeof(string));
            opcje_z_formularza.Columns.Add("Cena", typeof(int));
            opcje_z_formularza.Columns.Add("Waga", typeof(int));
            opcje_z_formularza.Columns.Add("Nazwa_na_ofercie", typeof(string));
            opcje_z_formularza.Columns.Add("Ilosc", typeof(int));

            opcje_z_bazy = DAL.G_opcje_dodatkowe;

        }

        private void dodaj_do_listy_wybranych_opcji(string nazwa)
        {
            var result =
                from opcje in opcje_z_bazy.AsEnumerable()
                where opcje.Field<string>("Nazwa") == nazwa
                select new
                {
                    Cena = opcje.Field<int>("Cena"),
                    Nazwa_na_oferte = opcje.Field<string>("Nazwa_na_ofercie")

                };

            foreach (var opcja in result)
            {
                opcje_z_formularza.Rows.Add(nazwa, opcja.Cena, 0, opcja.Nazwa_na_oferte,0);
            }
       
        }
        private void dodaj_do_listy_wybranych_opcji(string nazwa, int ilosc)
        {
            IEnumerable<DataRow> result =
                from opcje in opcje_z_bazy.AsEnumerable()
                where opcje.Field<string>("Nazwa") == nazwa
                select opcje;

           // opcje_z_formularza.Rows.Remove(result);
            

        }
        private void usun_z_listy_wybranych_opcji(string nazwa, int ilosc)
        {
            var result =
                from opcje in opcje_z_formularza.AsEnumerable()
                where opcje.Field<string>("Nazwa") == nazwa
                select new
                {
                    Cena = opcje.Field<int>("Cena"),
                    Nazwa_na_oferte = opcje.Field<string>("Nazwa_na_ofercie")

                };
            int cena;
            cena = 0;
            foreach (var opcja in result)
            {
                cena = opcja.Cena * ilosc;
                opcje_z_formularza.Rows.Add(nazwa, cena, 0, opcja.Nazwa_na_oferte, ilosc);
                //opcje_z_formularza.Rows.Remove
            }

        }
        public void op_webasto()
        {
            dodaj_do_listy_wybranych_opcji("webasto");
        }
        public void op_kabina(string kabina)
        {
           dodaj_do_listy_wybranych_opcji(kabina);
        }
       
        public void op_skrzynka_narzedziowa(string skrzynka_narzedziowa)
        {
            dodaj_do_listy_wybranych_opcji(skrzynka_narzedziowa);
        }

        public void op_spoiler(string spoiler)
        {
            dodaj_do_listy_wybranych_opcji(spoiler);
        }
        public void op_lakierowanie_kabiny()
        {
            dodaj_do_listy_wybranych_opcji("lakierowanie_kabiny_metalik");
        }

        public void op_nadstawka_nad_kabine()
        {
            dodaj_do_listy_wybranych_opcji("nadstawka_nad_kabine");
        }

        public void op_lakierowanie_spoilera_metalik()
        {
            dodaj_do_listy_wybranych_opcji("lakierowanie_spoilera_metalik");
        }
        
        public void op_lakierowanie_spoilera_akryl()
        {
            dodaj_do_listy_wybranych_opcji("lakierowanie_spoilera_AKRYL");
        }
        public string G_koszt_wybranych_opcji()
        {
            object sumObject;
            sumObject = opcje_z_formularza.Compute("Sum(Cena)","");

            return sumObject.ToString();

        }
        public DataTable G_wybrane_opcje()
        {

            return opcje_z_formularza;
        }

        public void op_system_firankowy(string sys_firankowy,Dane_podstawowe.Zabudowa zab)
        {

            int dlug;
            int.TryParse(zab.Dlugosc, out dlug);
            if((sys_firankowy=="prawa strona") || (sys_firankowy=="lewa strona"))
            {
                if (dlug<4250)
                {
                    dodaj_do_listy_wybranych_opcji("firanka_do_4200");
                }
                else if (dlug < 4550)
                {
                    dodaj_do_listy_wybranych_opcji("firanka_do_4500");
                }
                else 
                {
                    dodaj_do_listy_wybranych_opcji("firanka_do_4900");
                }
            }
            else
            {
                if (dlug < 4250)
                {
                    dodaj_do_listy_wybranych_opcji("firanka_dach_do_4200");
                }
                else if (dlug < 4550)
                {
                    dodaj_do_listy_wybranych_opcji("firanka_dach_do_4500");
                }
                else
                {
                    dodaj_do_listy_wybranych_opcji("firanka_dach_do_4900");
                }

            }
            
        }
        public void op_regulacja_manualna()
        {
            dodaj_do_listy_wybranych_opcji("regulacja_manualna");
        }
        public void op_regulacja_na_sprezynach()
        {
            dodaj_do_listy_wybranych_opcji("regulacja_na_sprezynach");
        }
        public void op_rama_wzmacniana()
        {
            dodaj_do_listy_wybranych_opcji("rama_wzmacniana");
        }
        public void op_klapa_pod_winde()
        {
            dodaj_do_listy_wybranych_opcji("klapa_pod_winde");
        }
        public void op_burty_600()
        {
            dodaj_do_listy_wybranych_opcji("burty_600");
        }
        public void op_poduszki_powietrzne(string poduszki)
        {
            dodaj_do_listy_wybranych_opcji(poduszki);
        }
        public void op_zbiornik_na_wode()
        {
            dodaj_do_listy_wybranych_opcji("zbiornik_na_wode");
        }
        public void op_zbiornik_na_paliwo()
        {
            dodaj_do_listy_wybranych_opcji("zbiornik_na_paliwo");
        }
       public void op_wpisywane(string uchwyty_miseczkowe, string uchwyty_w_obrzezu,string skrzynka_narzedziowa, string ilosc_skrzynek)
        {
          
            if (uchwyty_miseczkowe != "")
                op_uchwyty_miseczkowe(uchwyty_miseczkowe);
            if (uchwyty_w_obrzezu != "")
                op_uchwyty_w_obrzezu(uchwyty_w_obrzezu);
            if (skrzynka_narzedziowa != "")
                op_skrzynka_narzedziowa(skrzynka_narzedziowa,ilosc_skrzynek);

        }
        public void op_uchwyty_w_obrzezu(string ilosc)
       {
            int il;
            int.TryParse(ilosc, out il);
            dodaj_do_listy_wybranych_opcji("uchwyty_w_obrzezu", il);

       }
        public void op_uchwyty_miseczkowe(string ilosc)
        {
            int il;

            int.TryParse(ilosc, out il);
            dodaj_do_listy_wybranych_opcji("uchwyty_miseczkowe", il);

        }
        public void op_skrzynka_narzedziowa(string typ, string ilosc)
        {
            int il;
            int.TryParse(ilosc, out il);
            dodaj_do_listy_wybranych_opcji(typ, il);
        }
    }
}
