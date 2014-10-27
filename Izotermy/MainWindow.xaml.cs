using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Izotermy;
using Data_Base;
using System.Data;
using Izotermy.Typy_zabudowy;


namespace Izotermy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dane_podstawowe.Pojazd poj = new Dane_podstawowe.Pojazd();
        Dane_podstawowe.Zabudowa zab = new Dane_podstawowe.Zabudowa();
        Dane_podstawowe.Zamawiajacy zam = new Dane_podstawowe.Zamawiajacy();
        Dane_podstawowe.Data data_obecna = new Dane_podstawowe.Data();
        Dane_podstawowe.Data data_wyslania = new Dane_podstawowe.Data();
        Dane_podstawowe.Numer_oferty nr_of = new Dane_podstawowe.Numer_oferty();
        Dane_podstawowe.Ceny cena = new Dane_podstawowe.Ceny();
        DataTable opcje_dodatkowe = Obliczenia_pomocnicze.Opcje_dodatkowe();
        Opcje_dodatkowe op_dod = new Opcje_dodatkowe();

        public MainWindow()
        {
            InitializeComponent();
          //  Baza init = new Baza();
            using (DB_Connection polaczenie = new DB_Connection())
            {
            //    int cena;// = "13332.33";
            //    //cena = cena + "m";
             //   cena = 13330;
           //     MessageBox.Show(string.Format("{0:n0}", cena));
                //formatowanie_ceny = string.Format("wynosi: {0:n0} PLN netto.",  cena.cena_podstawowa);
                Inicjalizacja(polaczenie);
                //Miasto.
                //po inicjazji zamknac polaczenie
                //polaczenie.Close_connection();
            }

            //DB_Connection polaczenie2 = null;
            //try
            //{
            //    polaczenie2 = new DB_Connection();
            //    throw new NotImplementedException();
            //    init.Inicjalizacja(polaczenie2);
            //    //Miasto.
            //    //po inicjazji zamknac polaczenie
            //    //polaczenie.Close_connection();
            //}
            //finally
            //{
            //    //po inicjazji zamknac polaczenie
            //    polaczenie2.Close_connection();
                
            //}
        }
       
        private void Inicjalizacja(DB_Connection polaczenie)
        {

            // DB_Connection polaczenie= new DB_Connection();
            DataTable tmp;
            zam.wypelnienie = 0;
            poj.wypelnienie = 0;
            
        

            //CB_Dealer.ItemsSource = polaczenie.DB_Select("Miasto", "Miasto" ).DefaultView;
            
            tmp= polaczenie.DB_Select("Miasto", "miasto");
            CB_Miasto.ItemsSource = tmp.DefaultView;
            CB_Miasto.DisplayMemberPath = tmp.Columns[0].ToString();

            

            tmp = polaczenie.DB_Select("Dealer", "dealer");
            CB_Dealer.ItemsSource = tmp.DefaultView;
            CB_Dealer.DisplayMemberPath = tmp.Columns[0].ToString();

            tmp = polaczenie.DB_Select("Handlowiec", "handlowiec");
            CB_Handlowiec.ItemsSource = tmp.DefaultView;
            CB_Handlowiec.DisplayMemberPath = tmp.Columns[0].ToString();
            //ChB_Handlowiec.auto
            
            tmp = polaczenie.DB_Select("Przygotowanie_oferty", "przygotowanie_oferty");
            CB_Przygotowanie_oferty.ItemsSource = tmp.DefaultView;
            CB_Przygotowanie_oferty.DisplayMemberPath = tmp.Columns[0].ToString();

          //DP_Data_wyslania.SelectedDateFormat = DatePickerFormat.cus

          Zamawiajacy.IsEnabled = false;
           Klient_bezposredni.IsEnabled = false;
            Pojazd.IsEnabled = false;
        //    Zabudowa.IsEnabled = false;
         
            
            Opis_NCH.Visibility = Visibility.Hidden;
            Opis_NI.Visibility = Visibility.Hidden;
            Opis_NK.Visibility = Visibility.Hidden;
            Opis_NKP.Visibility = Visibility.Hidden;
            Opis_NS.Visibility = Visibility.Hidden;
            Opis_NW.Visibility = Visibility.Hidden;
            Opis_NSP.Visibility = Visibility.Visible;
            Opis_NSP.IsEnabled = false;

            tmp = polaczenie.DB_Select("Marka", "marka");
            CB_Marka.ItemsSource = tmp.DefaultView;
            CB_Marka.DisplayMemberPath = tmp.Columns[0].ToString();

            tmp = polaczenie.DB_Select("Model", "model");
            CB_Model.ItemsSource = tmp.DefaultView;
            CB_Model.DisplayMemberPath = tmp.Columns[0].ToString();

            tmp = polaczenie.DB_Select("Rozstaw_osi", "rozstaw_osi");
            CB_Rozstaw_osi.ItemsSource = tmp.DefaultView;
            CB_Rozstaw_osi.DisplayMemberPath = tmp.Columns[0].ToString();

           
            List<string> kabina = new List<string>();
            kabina.Add("Pojedyncza");
            kabina.Add("Podwójna");
            CB_Kabina.ItemsSource = kabina;

            List<string> kola = new List<string>();
            kola.Add("Pojedyncze");
            kola.Add("Bliźniacze");
            CB_Kola.ItemsSource = kola;

            List<string> typ_zabudowy = new List<string>();
            typ_zabudowy.Add("Nadwozie skrzyniowe");
            typ_zabudowy.Add("Nadwozie skrzyniowe otwarte");
            typ_zabudowy.Add("Nadwozie kontenerowe");
            typ_zabudowy.Add("Nadwozie izotermiczne");
            typ_zabudowy.Add("Nadwozie izotermiczne piekarnicze");
            typ_zabudowy.Add("Nadwozie chłodnicze");
            typ_zabudowy.Add("Nadwozie typu wywrot");

            CB_Typ_zabudowy.ItemsSource = typ_zabudowy;
        
            //List<string> test2 = new List<string>();
            //tmp = polaczenie.DB_Select("Miasto");
            //DataRow[] rows = new DataRow[tmp.Rows.Count];
            //tmp.Rows.CopyTo(rows, 0);

            //var cos = rows.ToList();
            //var cos = rows.Where(r => ((int)r[0]) % 1 == 0).Select((r) => { return r[0].ToString() + " " + r[1].ToString(); }).ToList();
            

            //List<DataRow> list = new List<DataRow>(tmp.Select());
            //test2 = tmp.DefaultView
            //DataRow[] rows = new DataRow;//[tmp.Rows.Count];
           // List[] test = new List[tmp.Rows.Count];
            
           // tmp.Rows.CopyTo(test, 0);
           // data_grid.ItemsSource = test;
            //tmp.Rows.CopyTo(rows,0);
            //rows = rows.ToList();
            //data_grid.ItemsSource = cos;
            //CB_Dealer.ItemsSource = list;
            
            //tmp = polaczenie.DB_Select("Miasto");

            /*
            
            
            DataRow[] rows = new DataRow[tmp.Rows.Count];
            tmp.Rows.CopyTo(rows, 0);

            var cos = rows.Where(r=> ((int)r[0])%2 == 0).Select((r) => { return r[0].ToString() + " " + r[1].ToString(); }).ToList();
            
            */
            
        }

        private void CB_Handlowiec_DropDownClosed(object sender, EventArgs e)
        {
            string value_Handlowiec, valueMiasto, valueDealer;
            
            DataTable tmp;
            //value_Handlowiec = CB_Handlowiec.Text;
            DB_Connection db = new DB_Connection();
            //select wybranej wartosci w handlowcach;
            //MessageBox.Show(CB_Handlowiec.Text);
            
            if (CB_Handlowiec.Text != "")
            {
                tmp= db.Select_where("idHandlowiec", "handlowiec", "Handlowiec = '" + CB_Handlowiec.Text + "'");
               // data_grid.ItemsSource = tmp.DefaultView;
                //MessageBox.Show("stop");

                ChB_Handlowiec.IsChecked = true;
                
                zam.Handlowiec = CB_Handlowiec.Text;
                zam.wypelnienie++;
                //ChB_Handlowiec.IsEnabled = false;
                value_Handlowiec = tmp.Rows[0][0].ToString();

                int a;
                int.TryParse(value_Handlowiec, out a);

                valueMiasto = db.Select_where("idMiasto", "zamawiajacy", "idHandlowiec = " + a).Rows[0][0].ToString();
                CB_Miasto.ItemsSource = db.Select_where("Miasto", "miasto", "idMiasto = " + valueMiasto).DefaultView;
                CB_Miasto.DisplayMemberPath = db.Select_where("Miasto", "miasto", "idMiasto = " + valueMiasto).Columns[0].ToString();
                CB_Miasto.SelectedIndex = 0;
                zam.Miasto = CB_Miasto.Text;
                zam.wypelnienie++;
                ChB_Miasto.IsChecked = true;

                valueDealer = db.Select_where("idDealer", "zamawiajacy", "idHandlowiec = " + a).Rows[0][0].ToString();
                CB_Dealer.ItemsSource = db.Select_where("Dealer", "dealer", "idDealer = " + valueDealer).DefaultView;
                CB_Dealer.DisplayMemberPath = db.Select_where("Dealer", "dealer", "idDealer = " + valueDealer).Columns[0].ToString();
                CB_Dealer.SelectedIndex = 0;
                zam.Dealer = CB_Dealer.Text;
                zam.wypelnienie++;
                ChB_Dealer.IsChecked = true;
            }
            
            // data_grid.ItemsSource = tmp.DefaultView;
           // string test = tmp.Columns[0];
         //   value = tmp.Rows[0][0].ToString();
            //MessageBox.Show(test);
           //tmp= db.Select_where("Miasto", "Miasto",");
            
           // tmp = polaczenie.DB_Select("Miasto", "Miasto");
            //CB_Miasto.ItemsSource = tmp.DefaultView;
            //



            
         //   MessageBox.Show(a.ToString());
        }

        private void CB_Marka_DropDownClosed(object sender, EventArgs e)
        {
            string value_Model, value_Marka, value_Rozstaw_osi;

            DataTable tmp;
            //value_Handlowiec = CB_Handlowiec.Text;
            DB_Connection db = new DB_Connection();
            //select wybranej wartosci w handlowcach;
            //MessageBox.Show(CB_Handlowiec.Text);

            if (CB_Marka.Text != "")
            {
                ChB_Marka.IsChecked = true;
                poj.Marka = CB_Marka.Text;
                poj.wypelnienie++;
                tmp = db.Select_where("idMarka", "marka", "Marka = '" + CB_Marka.Text + "'");
           //     data_grid.ItemsSource = tmp.DefaultView;
                
                value_Marka = tmp.Rows[0][0].ToString();

                int a;
                int.TryParse(value_Marka, out a);
                                
                tmp = db.Select_where("Model", "model", "idMarka = " + value_Marka);
                CB_Model.ItemsSource = tmp.DefaultView;
                CB_Model.DisplayMemberPath = tmp.Columns[0].ToString();
        //        data_grid.ItemsSource = tmp.DefaultView;
                CB_Model.SelectedIndex = 0;

                
                
                
                
                //CB_Model.ItemsSource = db.Select_where("Model", "Model", "idModel = " + value_Model).DefaultView;
                //CB_Model.DisplayMemberPath = db.Select_where("Model", "Model", "idModel = " + value_Model).Columns[0].ToString();
                
                //

                /*
                valueDealer = db.Select_where("idDealer", "Zamawiajacy", "idHandlowiec = " + a).Rows[0][0].ToString();
                CB_Dealer.ItemsSource = db.Select_where("Dealer", "Dealer", "idDealer = " + valueDealer).DefaultView;
                CB_Dealer.DisplayMemberPath = db.Select_where("Dealer", "Dealer", "idDealer = " + valueDealer).Columns[0].ToString();
                CB_Dealer.SelectedIndex = 0;
            
                 */ }
            

        }


        private void CB_Model_DropDownClosed(object sender, EventArgs e)
        {
            DB_Connection db = new DB_Connection();

            if (CB_Model.Text != "")
            {
                ChB_Model.IsChecked = true;
                poj.Model = CB_Model.Text;
                poj.wypelnienie++;

                string value_Model;
                string number_Model;
                DataTable tmp;

                value_Model = CB_Model.Text;
                number_Model = db.Select_where("idModel", "model", "Model = '" + value_Model+"'").Rows[0][0].ToString();
                tmp = db.Select_where("idRozstaw_osi", "samochody", "idModel = " + number_Model);
                DataTable r_o_zawartosc = new DataTable();
                r_o_zawartosc.Columns.Add("rozstaw_osi",typeof(string));
                foreach (DataRow r in tmp.Rows)
                {
                    r_o_zawartosc.Rows.Add(db.Select_where("Rozstaw_osi", "rozstaw_osi", "idRozstaw_osi = '" + r.ItemArray[0].ToString() + "'").Rows[0][0].ToString());
                }
               
                CB_Rozstaw_osi.ItemsSource = r_o_zawartosc.DefaultView;
                CB_Rozstaw_osi.DisplayMemberPath = r_o_zawartosc.Columns[0].ToString();
                CB_Rozstaw_osi.SelectedIndex = 0;
            }
        }

       
        private void CB_Typ_zabudowy_DropDownClosed(object sender, EventArgs e)
        {
            DB_Connection db = new DB_Connection();
            string typ_zabudowy = CB_Typ_zabudowy.Text;
          /*  DataTable typy_zabudowy = new DataTable();
            typy_zabudowy.Columns.Add("nazwa_grida", typeof(string));
            typy_zabudowy.Columns.Add("nazwa_combobox", typeof(string));
            typy_zabudowy.Rows.Add("Opis_NCH", "Nadwozie chłodnicze");
            typy_zabudowy.Rows.Add("Opis_NI", "Nadwozie izotermiczne");
            typy_zabudowy.Rows.Add("Opis_NK", "Nadwozie kontenerowe");
            typy_zabudowy.Rows.Add("Opis_NKP", "Nadwozie izotermiczne piekarnicze");
            typy_zabudowy.Rows.Add("Opis_NSP", "Nadwozie skrzyniowe");
            typy_zabudowy.Rows.Add("Opis_NS", "Nadwozie skrzyniowe otwarte");
            typy_zabudowy.Rows.Add("Opis_NW", "Nadwozie typu wywrot");


            //DataTable test;
            var results =
                from DataRow row in typy_zabudowy.AsEnumerable()
                where row.Field<string>("nazwa_combobox") == CB_Typ_zabudowy.Text
                select row.Field<string>("nazwa_grida");
           */
            DataTable tmp;
            zab.Typ_zabudowy = typ_zabudowy;
            switch (typ_zabudowy)
            {
                case "Nadwozie skrzyniowe":
                    {
                        zab.Rodziana_zabudow = 1;
                        zab.Typ_zabudowy_skrot = "NSP";
                        zab.Typ_zabudowy_nazwa_na_ofercie = "skrzynia z plandeką";

                        Opis_NSP.IsEnabled = true;
                        Opis_NCH.Visibility = Visibility.Hidden;
                        Opis_NI.Visibility = Visibility.Hidden;
                        Opis_NK.Visibility = Visibility.Hidden;
                        Opis_NKP.Visibility = Visibility.Hidden;
                        Opis_NS.Visibility = Visibility.Hidden;
                        Opis_NW.Visibility = Visibility.Hidden;
                        Opis_NSP.Visibility = Visibility.Visible;
                  
            
                        NSP_kabina.ItemsSource = DAL.G_kabina_sypialna;
                        NSP_spoiler.ItemsSource = DAL.G_spoiler_dachowy;
                        NSP_poduszki_powietrzne.ItemsSource = DAL.G_poduszki_powietrzne;
                        NSP_system_firankowy.ItemsSource = DAL.G_system_firankowy;
                        NSP_plandeka_kolor.ItemsSource = DAL.G_plandeka_kolor;
                        NSP_skrzynka_narzedziowa.ItemsSource = DAL.G_skrzynka_narzedziowa;

                        NSP_kabina2.ItemsSource = DAL.G_kabina_sypialna;
                        NSP_spoiler2.ItemsSource = DAL.G_spoiler_dachowy;
                        NSP_poduszki_powietrzne2.ItemsSource = DAL.G_poduszki_powietrzne;
                        NSP_system_firankowy2.ItemsSource = DAL.G_system_firankowy;
                        NSP_plandeka_kolor2.ItemsSource = DAL.G_plandeka_kolor;
                        NSP_skrzynka_narzedziowa2.ItemsSource = DAL.G_skrzynka_narzedziowa;
                        

                        break;
                    }
                case "Nadwozie skrzyniowe otwarte":
                    {

                        zab.Rodziana_zabudow = 1;
                        zab.Typ_zabudowy_skrot = "NS";
                        Opis_NCH.Visibility = Visibility.Hidden;
                        Opis_NI.Visibility = Visibility.Hidden;
                        Opis_NK.Visibility = Visibility.Hidden;
                        Opis_NKP.Visibility = Visibility.Hidden;
                        Opis_NS.Visibility = Visibility.Visible;
                        Opis_NW.Visibility = Visibility.Hidden;
                        Opis_NSP.Visibility = Visibility.Hidden;
                        break;
                     }

                case "Nadwozie kontenerowe":
                    {
                        zab.Rodziana_zabudow = 2;
                        zab.Typ_zabudowy_skrot = "NK";
                        Opis_NCH.Visibility = Visibility.Hidden;
                        Opis_NI.Visibility = Visibility.Hidden;
                        Opis_NK.Visibility = Visibility.Visible;
                        Opis_NKP.Visibility = Visibility.Hidden;
                        Opis_NS.Visibility = Visibility.Hidden;
                        Opis_NW.Visibility = Visibility.Hidden;
                        Opis_NSP.Visibility = Visibility.Hidden;
                        break;
                    }
                case "Nadwozie izotermiczne":
                    {
                        zab.Rodziana_zabudow = 2;
                        zab.Typ_zabudowy_skrot = "NI";
                        Opis_NCH.Visibility = Visibility.Hidden;
                        Opis_NI.Visibility = Visibility.Visible;
                        Opis_NK.Visibility = Visibility.Hidden;
                        Opis_NKP.Visibility = Visibility.Hidden;
                        Opis_NS.Visibility = Visibility.Hidden;
                        Opis_NW.Visibility = Visibility.Hidden;
                        Opis_NSP.Visibility = Visibility.Hidden;
                        break;
                    }
                case "Nadwozie chłodnicze":
                    {
                        zab.Rodziana_zabudow = 2;
                        zab.Typ_zabudowy_skrot = "NCH";
                        Opis_NCH.Visibility = Visibility.Visible;
                        Opis_NI.Visibility = Visibility.Hidden;
                        Opis_NK.Visibility = Visibility.Hidden;
                        Opis_NKP.Visibility = Visibility.Hidden;
                        Opis_NS.Visibility = Visibility.Hidden;
                        Opis_NW.Visibility = Visibility.Hidden;
                        Opis_NSP.Visibility = Visibility.Hidden;
                        break;
                    }
                case "Nadwozie izotermiczne piekarnicze":
                    {
                        zab.Rodziana_zabudow = 2;
                        zab.Typ_zabudowy_skrot = "NKP";
                        Opis_NCH.Visibility = Visibility.Hidden;
                        Opis_NI.Visibility = Visibility.Hidden;
                        Opis_NK.Visibility = Visibility.Hidden;
                        Opis_NKP.Visibility = Visibility.Visible;
                        Opis_NS.Visibility = Visibility.Hidden;
                        Opis_NW.Visibility = Visibility.Hidden;
                        Opis_NSP.Visibility = Visibility.Hidden;
                        break;
                    }
                case "Nadwozie typu wywrot":
                    {
                        zab.Rodziana_zabudow = 1;
                        zab.Typ_zabudowy_skrot = "NW";
                        Opis_NCH.Visibility = Visibility.Hidden;
                        Opis_NI.Visibility = Visibility.Hidden;
                        Opis_NK.Visibility = Visibility.Hidden;
                        Opis_NKP.Visibility = Visibility.Hidden;
                        Opis_NS.Visibility = Visibility.Hidden;
                        Opis_NW.Visibility = Visibility.Visible;
                        Opis_NSP.Visibility = Visibility.Hidden;
                        break;
                    }

            }
          
        }

        private void BTN_przelicz_Click(object sender, RoutedEventArgs e)
        {


            //TB_nr_oferty.Text =

            DB_Connection db = new DB_Connection();
            string typ_zabudowy = CB_Typ_zabudowy.Text;
            DataTable tmp;
            switch (typ_zabudowy)
            {
                case "Nadwozie skrzyniowe":
                    {
                        tmp = db.DB_Select("opcje_dodatkowe_ceny");

                        data_grid.ItemsSource = tmp.DefaultView;

                        if(NSP_regulacja_manualna.IsChecked.Value)
                        {

                            var result =
                                from DataRow row in tmp.AsEnumerable()
                                where row.Field<string>("Nazwa") == "regulacja_manulana"
                                select row.Field<int>("cena");
                            MessageBox.Show(result.  ToString());
                        }
                        string value_kabina;
                        data_grid.ItemsSource = NSP_kabina.Items;
                        //NSP_
                      //  MessageBox.Show(NSP_kabina.Items.CurrentItem.ToString());
                     //   value_kabina = NSP_kabina.SelectedItem as string;
                       // tmp.it=NSP_kabina.Items;
                       // data_grid.ItemsSource = NSP_kabina.Items;
                       value_kabina= NSP_kabina.Text;
                       


                      //  MessageBox.Show(value_kabina);
                        //var result =
                          //  from 

             /*                       //DataTable test;
            var results =
                from DataRow row in typy_zabudowy.AsEnumerable()
                where row.Field<string>("nazwa_combobox") == CB_Typ_zabudowy.Text
                select row.Field<string>("nazwa_grida");
           */


                        break;
                    }
            }
        }

        private void CB_Przygotowanie_oferty_DropDownClosed(object sender, EventArgs e)
        {
            if (CB_Przygotowanie_oferty.Text != "")
            {
                zam.Przygotowanie_oferty = CB_Przygotowanie_oferty.Text;
                zam.wypelnienie++;
                ChB_Przygotowanie_oferty.IsChecked = true;



            }

            
        }

        private void DP_Data_wyslania_CalendarClosed(object sender, RoutedEventArgs e)
        {
            if (DP_Data_wyslania.SelectedDate != null)
            {
                //zam.Data_wyslania = 
                //zam.Data_wyslania = DP_Data_wyslania.SelectedDate.ToString();
                string day;
                if (DP_Data_wyslania.SelectedDate.Value.Day < 10)
                    day = "0" + DP_Data_wyslania.SelectedDate.Value.Day;
                else
                    day = DP_Data_wyslania.SelectedDate.Value.Day.ToString();
                string month;
                if (DP_Data_wyslania.SelectedDate.Value.Month < 10)
                    month = "0" + DP_Data_wyslania.SelectedDate.Value.Month;
                else
                    month = DP_Data_wyslania.SelectedDate.Value.Month.ToString();

                data_wyslania.dzien = day;
                data_wyslania.miesiac = month;
                data_wyslania.rok = DP_Data_wyslania.SelectedDate.Value.Year.ToString();

                zam.Data_wyslania = day + "/" + month + "/" + DP_Data_wyslania.SelectedDate.Value.Year;
                    //DP_Data_wyslania.SelectedDate.value.Day
            }
            zam.wypelnienie++;
            if (zam.wypelnienie >= 5)
                Pojazd.IsEnabled = true;
                ChB_Data_wyslania.IsChecked = true;
        }

        private void CB_Rozstaw_osi_DropDownClosed(object sender, EventArgs e)
        {
            if (CB_Rozstaw_osi.Text != null)
            {
                poj.wypelnienie++;
                poj.Rozstaw_osi = CB_Rozstaw_osi.Text;
                ChB_r_o.IsChecked = true;
            }
            
        }

        private void CB_Kabina_DropDownClosed(object sender, EventArgs e)
        {
            if (CB_Kabina.Text !=null)
            {
                poj.wypelnienie++;
                poj.Kabina = CB_Kabina.Text;
                ChB_Kabina.IsChecked = true;

            }
        }

        private void CB_Kola_DropDownClosed(object sender, EventArgs e)
        {
            if (CB_Kola.Text != null)
            {
                poj.wypelnienie++;
                poj.Kola = CB_Kola.Text;
                ChB_Kola.IsChecked = true;
                if (poj.wypelnienie >= 5)
                    Zabudowa.IsEnabled = true;

            }
        }

        
        private void Btn_Sprawdz_wymiary_click(object sender, RoutedEventArgs e)
        {
            zab.Typ_zabudowy = CB_Typ_zabudowy.Text;

            zab.Dlugosc= Dlugosc.Text;
            zab.Szerokosc = Szerokosc.Text;
            zab.Wysokosc = Wysokosc.Text;

            zab.Kubatura = Obliczenia_pomocnicze.Kubatura(zab).ToString();
            Tb_kubatura.Text = zab.Kubatura;
            zab.Euro_palet= Obliczenia_pomocnicze.Ilosc_europalet(zab).ToString();
            Tb_europalety.Text = zab.Euro_palet;

            Obliczenia_pomocnicze.Wymiary_zewnetrzne(zab);
          
        }

        private void ChB_Delaer_klient_Checked(object sender, RoutedEventArgs e)
        {
            bool? test = ChB_Klient.IsChecked;

            if (!test.HasValue)
            {
              test=IsInitialized;
            }
            if((bool)test) //now this cast is safe
            {
                ChB_Klient.IsChecked=false;
                // Do something.
            }
            

            if (!Zamawiajacy.IsEnabled)
            {
                Zamawiajacy.IsEnabled = true;
                Klient_bezposredni.Visibility = Visibility.Hidden;
                Zamawiajacy.Visibility = Visibility.Visible;
                Klient_bezposredni.IsEnabled = false;
            }
            else
            {
                Zamawiajacy.IsEnabled = false;
                Klient_bezposredni.IsEnabled = true;
            }
        }

        private void ChB_Klient_Checked(object sender, RoutedEventArgs e)
        {
            bool? test = ChB_Delaer_klient.IsChecked;
                

            if (!test.HasValue)
            {
                test = IsInitialized;
            }
            if ((bool)test) //now this cast is safe
            {
                ChB_Delaer_klient.IsChecked = false;
                // Do something.
            }
            


            if (!Klient_bezposredni.IsEnabled)
            {
                Klient_bezposredni.IsEnabled = true;
                Klient_bezposredni.Visibility = Visibility.Visible;
                Zamawiajacy.Visibility = Visibility.Hidden;
                Zamawiajacy.IsEnabled = false;
            }
            else
            {
                Klient_bezposredni.IsEnabled = false;
                Zamawiajacy.IsEnabled = true;
            }
        }
        
        private void Btn_podsumowanie_Click(object sender, RoutedEventArgs e)
        {
            /*
            nr_of = Obliczenia_pomocnicze.Numer_oferty(data_wyslania, zab, zam);
            TB_nr_oferty.Text = nr_of.Nr_oferty;
            
            zab.Dlugosc = Dlugosc.Text;
            
             */
            cena.cena_podstawowa=DAL.G_cena_podstawowa(zab);
            
           
            nr_of = Obliczenia_pomocnicze.Numer_oferty(data_wyslania, zab, zam);
            

            op_dod.op_wpisywane(NSP_uchwyty_miseczkowe.Text, NSP_uchwyty_w_obrzezu.Text, NSP_skrzynka_narzedziowa.Text,NSP_ilosc_skrzynek.Text);

           
            
          //  dt_grid.ItemsSource = op_dod.G_wybrane_opcje().DefaultView;
            TB_nr_oferty.Text = DAL.G_Numer_oferty;
            TB_cena_podstawowa.Text = cena.cena_podstawowa;
            TB_koszty_opcji_dodatkowcyh.Text = op_dod.G_koszt_wybranych_opcji();
            float suma;

            suma = int.Parse(cena.cena_podstawowa) + int.Parse(op_dod.G_koszt_wybranych_opcji()); 
            Tb_netto.Text = suma.ToString();
          

            
            DAL.S_Numer_oferty(nr_of);

        }

        private void NSP_kabina_DropDownClosed(object sender, EventArgs e)
        {
            op_dod.op_kabina(NSP_kabina.Text);
         }

        private void NSP_spoiler_DropDownClosed(object sender, EventArgs e)
        {
            op_dod.op_spoiler(NSP_spoiler.Text);
        }

        
        private void NSP_nadstawka_nad_kabine_Checked(object sender, RoutedEventArgs e)
        {
            op_dod.op_nadstawka_nad_kabine();
        }

        private void NSP_webasto_Checked(object sender, RoutedEventArgs e)
        {
            op_dod.op_webasto();
        }

        private void NSP_lakierowanie_akryl_Checked(object sender, RoutedEventArgs e)
        {
            op_dod.op_lakierowanie_spoilera_akryl();
        }

        private void NSP_lakierowanie_metalik_Checked(object sender, RoutedEventArgs e)
        {
            if (NSP_kabina.Text !=null)
            {
                op_dod.op_lakierowanie_kabiny();
            }
            else
            {
                op_dod.op_lakierowanie_spoilera_metalik();
            }

        }

        private void NSP_system_firankowy_DropDownClosed(object sender, EventArgs e)
        {
            op_dod.op_system_firankowy(NSP_system_firankowy.Text,zab);
        }

        private void NSP_regulacja_manualna_Checked(object sender, RoutedEventArgs e)
        {
            op_dod.op_regulacja_manualna();
        }

        private void NSP_regulacja_na_sprezynach_Checked(object sender, RoutedEventArgs e)
        {
            op_dod.op_regulacja_na_sprezynach();
        }

        private void NSP_rama_wzmacniana_Checked(object sender, RoutedEventArgs e)
        {
            op_dod.op_rama_wzmacniana();
        }

        private void NSP_klapa_pod_winde_Checked(object sender, RoutedEventArgs e)
        {
            op_dod.op_klapa_pod_winde();
        }

        private void NSP_burty_600_Checked(object sender, RoutedEventArgs e)
        {
            op_dod.op_burty_600();
        }

        private void NSP_poduszki_powietrzne_DropDownClosed(object sender, EventArgs e)
        {
            op_dod.op_poduszki_powietrzne(NSP_poduszki_powietrzne.Text);
        }

        private void NSP_plandeka_kolor_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void NSP_zbiornik_na_wode_Checked(object sender, RoutedEventArgs e)
        {
            op_dod.op_zbiornik_na_wode();
        }

        private void NSP_zbiornik_na_paliwo_Checked(object sender, RoutedEventArgs e)
        {
            op_dod.op_zbiornik_na_paliwo();
        }

        private void Btn_generuj_oferte_Click(object sender, RoutedEventArgs e)
        {
            DataTable wybrane_opcje_dodatkowe = op_dod.G_wybrane_opcje();
            Generacja_oferty gen = new Generacja_oferty();
            gen.Generuj_oferte(poj, zab, zam, nr_of, cena, wybrane_opcje_dodatkowe);
        }

   
       
      
       
        
        


    }
}
