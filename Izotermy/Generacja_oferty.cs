using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;

namespace Izotermy
{
    class Generacja_oferty
    {
        string wypunktowanie = "•    ";
        float leading=1.2f;
        public void Generuj_oferte()
        {
            Tworzenie_pdf oferta = new Tworzenie_pdf();
            //Tworzenie_pdf.

            Document doc = oferta.Inicjalizacja("test");
            
            oferta.Open_file(doc);
          //  doc.Open();

            Paragraph paragraf = new Paragraph("OFERTA HANDLOWA", oferta.font_oferta);
            paragraf.Alignment = Element.ALIGN_CENTER;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

           
            paragraf = new Paragraph("Nr oferty " + "08/2014/NSP/RO", oferta.font_punkty);
            paragraf.Alignment = Element.ALIGN_RIGHT;
            doc.Add(paragraf);

            paragraf = new Paragraph("Data oferty", oferta.font_gora_prawa);
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Ważność oferty: 7 dni");
            paragraf.Alignment = Element.ALIGN_RIGHT;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            paragraf = new Paragraph("Oferta", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            doc.Add(paragraf);
            string Dealer = "Tandem";
            string Handlowiec = " Michał Drabik";
            string e_mail = "michal@drabik.pl";
            string nr_telefonu = " 543-232-122";
            string Marka = "Renault";
            string Model = "Master L3";
            string r_o = "4332";
            string Kabina = "Pojedyncza";
            string Kola = "Bliźniacze";
            string wypunktowanie = "•    ";

            paragraf = new Paragraph(wypunktowanie + Dealer, oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + Handlowiec);
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + e_mail);
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + nr_telefonu);
            paragraf.Add(Environment.NewLine);
            paragraf.IndentationLeft = 15;
            paragraf.Alignment = Element.ALIGN_LEFT;
            doc.Add(paragraf);


            //•	
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Ważność oferty: 7 dni");


            oferta.Close_file(doc);
            System.Diagnostics.Process.Start("test.pdf");
//            doc.Close();
        }
        public void Generuj_oferte(Dane_podstawowe.Pojazd poj,Dane_podstawowe.Zabudowa zab, Dane_podstawowe.Zamawiajacy zam,Dane_podstawowe.Numer_oferty nr_of,Dane_podstawowe.Ceny cena,DataTable wybrane_opcje_dodatkowe)
        {
            Tworzenie_pdf oferta = new Tworzenie_pdf();
            //Tworzenie_pdf.

            Document doc = oferta.Inicjalizacja(nr_of.Nazwa_pliku);

            oferta.Open_file(doc);
            //poj.
            
            Paragraph paragraf = new Paragraph("OFERTA HANDLOWA", oferta.font_oferta);
            paragraf.Alignment = Element.ALIGN_CENTER;
            doc.Add(paragraf);

         
            paragraf = new Paragraph("Nr oferty " + nr_of.Nr_oferty, oferta.font_punkty);
            paragraf.Alignment = Element.ALIGN_RIGHT;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            paragraf = new Paragraph("Data oferty: "+zam.Data_wyslania , oferta.font_gora_prawa);
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Ważność oferty: 7 dni");
            paragraf.Alignment = Element.ALIGN_RIGHT;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            oferta.Linia_odstepu(doc);

            /******************OFERTA***********************************/
            paragraf = new Paragraph("Oferta:", oferta.font_punkty);
            paragraf.Alignment = Element.ALIGN_LEFT;
            doc.Add(paragraf);
       //     string wypunktowanie = "•    ";
            string e_mail = "zrobic pole pod e-mail";
            string nr_telefonu = "zrobic pole pod nr_telefonu";
            
            paragraf = new Paragraph(wypunktowanie +"Do: "+zam.Dealer, oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + "Dla: " + zam.Handlowiec);
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + "E-mail: "+ e_mail);
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + "Telefon: "+ nr_telefonu);
            paragraf.Add(Environment.NewLine);
            paragraf.IndentationLeft = 15;
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

         //   oferta.Linia_odstepu(doc);

            /******************Dane podwozia***********************************/
            paragraf = new Paragraph("Dane podwozia:", oferta.font_punkty);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            paragraf = new Paragraph(wypunktowanie + "Marka i Model: " + poj.Marka+" "+poj.Model, oferta.font_dane);

            paragraf.Add(Environment.NewLine);
            
            /*
            paragraf = new Paragraph(wypunktowanie + "Marka: " + poj.Marka , oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            
            paragraf.Add(wypunktowanie + "Model: " + poj.Model);
            paragraf.Add(Environment.NewLine);
            */
            paragraf.Add(wypunktowanie + "Rozstaw osi: " + poj.Rozstaw_osi);
            paragraf.Add(Environment.NewLine);

            paragraf.Add(wypunktowanie + "Kabina: " + poj.Kabina+", Koła: "+poj.Kola );
            paragraf.Add(Environment.NewLine);
            
            /*
            paragraf.Add(wypunktowanie + "Kabina: " + poj.Kabina);
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + "Koła: " + poj.Kola);
            paragraf.Add(Environment.NewLine);
            */
            paragraf.IndentationLeft = 15;
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

          //  oferta.Linia_odstepu(doc);

            /***************** TYP i wymiary ***********************************/
            paragraf = new Paragraph("Nadwozie polegające na wykonaniu zabudowy typu "+ zab.Typ_zabudowy_nazwa_na_ofercie +" o wymiarach:", oferta.font_punkty);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
           // string bufor;
           // bufor=
            paragraf = new Paragraph(wypunktowanie + "Długość: wew. " + zab.Dlugosc + "mm / zew. " + zab.Dlugosc_zew + "mm", oferta.font_dane);
            //paragraf.Add(wypunktowanie + "Długość: wew." + zab.Dlugosc+" / zew."+ zab.Dlugosc_zew);
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + "Szerokość: wew. " + zab.Szerokosc + "mm / zew. " + zab.Szerokosc_zew + "mm");
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + "Wysokość: wew. " + zab.Wysokosc + "mm / zew. " + zab.Wysokosc_zew + "mm");
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + "Pojemność komory ładunkowej: "+zab.Euro_palet+ " EUROpalet; około "+ zab.Kubatura+" m3 ");
            paragraf.Add(Environment.NewLine);
          //  paragraf.Add(wypunktowanie + "Waga około (bez wyposażenia dodatkowego): " +zab.Waga+ " kg (+/- 5%): ");
          //  paragraf.Add(Environment.NewLine);
            paragraf.IndentationLeft = 15;
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
            
            switch (zab.Typ_zabudowy)
            {
                case "Nadwozie skrzyniowe":
                    {
                        NSP_opis_nadwozia(zab, doc, oferta);
                     //Cena nadwozia typu ……….. według podanej standaryzacji wynosi …… PLN netto
                        
                        break;
                    }
                case "Nadwozie skrzyniowe otwarte":
                    {
                        NS_opis_nadwozia(zab, doc, oferta);
                        break;
                    }

                case "Nadwozie kontenerowe":
                    {
                        break;
                    }
                case "Nadwozie izotermiczne":
                    {
                        break;
                    }
                case "Nadwozie chłodnicze":
                    {
                        break;
                    }
                case "Nadwozie izotermiczne piekarnicze":
                    {
                        break;
                    }
                case "Nadwozie typu wywrot":
                    {
                        break;
                    }
           
                    

            }
            
            paragraf = new Paragraph("Cena nadwozia typu " + zab.Typ_zabudowy_nazwa_na_ofercie + " według podanej standaryzacji",oferta.font_punkty);
            paragraf.SpacingBefore = 12;
            paragraf.Add(Environment.NewLine);
            string formatowanie_ceny;
            formatowanie_ceny = string.Format("wynosi: {0:n0} PLN netto.", int.Parse(cena.cena_podstawowa));
            //"-->{0,40}<--", "Słowo"
                //String.Format("{0,-10:C}", 126347.89m);  
           // paragraf.Add("wynosi: " + formatowanie_ceny + " PLN netto.");
            paragraf.Add(formatowanie_ceny);
            paragraf.Alignment = Element.ALIGN_CENTER;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
            
            doc.NewPage();

            //Wyposażone dodatkowe odpłatne: 
            Opcje_dodatkowe(wybrane_opcje_dodatkowe,doc,oferta);

            Informacje_dodatkowe(doc, oferta);
            //doc.Add(paragraf);

            oferta.Close_file(doc);

            System.Diagnostics.Process.Start(nr_of.Nazwa_pliku+".pdf");
        }
        /************RAMA ALUMINIOWA************/
        private void Rama_aluminiowa(Document doc, Tworzenie_pdf oferta)
        {
            Paragraph paragraf = new Paragraph(wypunktowanie + "Rama pośrednia. ", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            paragraf = new Paragraph("Wykonana z profili aluminiowych skręcanych.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
        }
        /************BURTY************/
        private void Burty(Document doc,Tworzenie_pdf oferta)
        {
            Paragraph paragraf = new Paragraph(wypunktowanie + "Burty aluminiowe 400mm. ", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            paragraf = new Paragraph("Burty dzielone ze słupkiem środkowym wypinanym (burty dzielone od długości 3500mm).", oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Na tylnej burcie znajduje się składany stopień wejściowy.");
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
        }
        /************PODLOGA************/
        private void Podloga(Document doc, Tworzenie_pdf oferta,Dane_podstawowe.Zabudowa zab)
        {
            Paragraph paragraf = new Paragraph(wypunktowanie + "Podłoga.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            paragraf = new Paragraph("Wykonana ze sklejki antypoślizgowej, dwustronnie foliowanej o grubości 15mm;", oferta.font_dane);
            
            if (zab.Rodziana_zabudow==1)
            {
                paragraf.Add(Environment.NewLine);
                paragraf.Add("W obrzeżu zamontowane są uchwyty do mocowania ładunku w odstępach (-/+) jednego metra.");
            }
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.SetLeading(0, leading);
            paragraf.IndentationLeft = 45;
            doc.Add(paragraf);
        }
        /************OSWIETLENIE************/
            private void Oswietlenie (Document doc,Tworzenie_pdf oferta,Dane_podstawowe.Zabudowa zab)
        {  
            Paragraph paragraf = new Paragraph(wypunktowanie + "Oświetlenie.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            paragraf.SetLeading(0, leading);
                doc.Add(paragraf);
            paragraf = new Paragraph("Lampy obrysowe zgodnie z przepisami Kodeksu Ruchu Drogowego.", oferta.font_dane);
            
            if(zab.Rodziana_zabudow==2)
            {
                paragraf.Add(Environment.NewLine);
                paragraf.Add("Lampa oświetleniowa wewnętrzna (led) załączana w kabinie kierowcy 1 szt.;");
                paragraf.Add(Environment.NewLine);
                paragraf.Add("Nad drzwiami tylnymi dodatkowe światło STOP (led).");
            }

                
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
         }
            /************OSPRZET************/
        private void Osprzet(Document doc,Tworzenie_pdf oferta, Dane_podstawowe.Zabudowa zab)
            {
                Paragraph  paragraf = new Paragraph(wypunktowanie + "Osprzęt.", oferta.font_dane);
                paragraf.Alignment = Element.ALIGN_LEFT;
                paragraf.IndentationLeft = 15;
                doc.Add(paragraf);
                paragraf = new Paragraph("Nadkola osi tylnej z tworzywa sztucznego w kolorze czarnym;", oferta.font_dane);
                paragraf.Add(Environment.NewLine);
                paragraf.Add("Fartuchy przeciw błotne;");
                paragraf.Add(Environment.NewLine);
                paragraf.Add("Osłony p/ najazdowe;");

                if (zab.Rodziana_zabudow == 1)
                {
                    paragraf.Add(Environment.NewLine);
                    paragraf.Add("Skrzynka narzędziowa z jednym zamknięciem o pojemności 35l.");
                }
                paragraf.Alignment = Element.ALIGN_LEFT;
                paragraf.IndentationLeft = 45;
                paragraf.SetLeading(0, leading);    
                doc.Add(paragraf);
            }
        
        /***************** Standardowy opis nadwozia  NSP  ***********************************/
        private void NSP_opis_nadwozia (Dane_podstawowe.Zabudowa zab, Document doc, Tworzenie_pdf oferta)
        {

            Paragraph paragraf = new Paragraph("Standardowy opis nadwozia typu "+zab.Typ_zabudowy_nazwa_na_ofercie+":", oferta.font_punkty);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
           // paragraf.IndentationLeft = 15;

            /************RAMA************/
            Rama_aluminiowa(doc, oferta);   
            /************BURTY************/
            Burty(doc, oferta);
            /************PODLOGA************/
            Podloga(doc, oferta,zab);
            /************STELAŻ************/
            paragraf = new Paragraph(wypunktowanie + "Stelaż.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.SetLeading(0, leading);
            paragraf.IndentationLeft = 15;
            doc.Add(paragraf);
            paragraf = new Paragraph("Wykonany z profili aluminiowych;", oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Słupy przednie i tylne montowane na stałe;");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Konstrukcja dachu stelaża wykonana z rur stalowych osadzonych w gumowych uchwytach;");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Nad burtą przednią montowana sklejka o grubości 15 mm na wysokości 1250mm;");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Trzy rzędy listew bocznych drewnianych w na każdej ścianie zabudowy.");
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
            /************OPONCZA************/
            paragraf = new Paragraph(wypunktowanie + "Opończa.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            doc.Add(paragraf);
            paragraf = new Paragraph("Wykonana w wersji z zapięciem celnym w kolorze standardowym o grubości 680g/m2.", oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Kolor standardowy (przy zamówieniu należy podać kolor):");
            paragraf.Add(Environment.NewLine);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
            paragraf = new Paragraph(wypunktowanie + "Czerwony", oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + "Srebrny");
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + "Czarny");
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + "Granatowy");
            paragraf.Add(Environment.NewLine);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 65;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
            paragraf = new Paragraph("Panel dachowy wykonany z materiału widnego.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
            /************OSWIETLENIE************/
            Oswietlenie(doc, oferta,zab);
            /************OSPRZET************/
            Osprzet(doc, oferta,zab);


        }
        /***************** Standardowy opis nadwozia  NS  ***********************************/
        private void NS_opis_nadwozia(Dane_podstawowe.Zabudowa zab, Document doc, Tworzenie_pdf oferta)
        {

            Paragraph paragraf = new Paragraph("Standardowy opis nadwozia skrzyniowego", oferta.font_punkty);
            paragraf.Alignment = Element.ALIGN_LEFT;
            doc.Add(paragraf);
            // paragraf.IndentationLeft = 15;

            /************RAMA************/
            paragraf = new Paragraph(wypunktowanie + "Rama pośrednia. ", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            paragraf = new Paragraph("Wykonana z profili aluminiowych skręcanych.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            /************BURTY************/
            paragraf = new Paragraph(wypunktowanie + "Burty aluminiowe 400mm. ", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
            
            paragraf = new Paragraph("Burty dzielone ze słupkiem środkowym wypinanym (burty dzielone od długości 3500mm).", oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Na tylnej burcie znajduje się składany stopień wejściowy.");
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            /************PODLOGA************/
            paragraf = new Paragraph(wypunktowanie + "Podłoga.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            paragraf = new Paragraph("Wykonana ze sklejki antypoślizgowej, dwustronnie foliowanej o grubości 15mm;", oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add("W obrzeżu zamontowane są uchwyty do mocowania ładunku w odstępach (-/+) jednego metra.");
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
           
            /************PAŁĄK************/
            paragraf = new Paragraph(wypunktowanie + "Pałąk.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
            paragraf = new Paragraph("Wykonany z profili aluminiowych za kabiną kierowcy.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            /************OSWIETLENIE************/
            paragraf = new Paragraph(wypunktowanie + "Oświetlenie.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
            paragraf = new Paragraph("Lampy obrysowe zgodnie z przepisami Kodeksu Ruchu Drogowego.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            /************OSPRZET************/
            paragraf = new Paragraph(wypunktowanie + "Osprzęt.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
            paragraf = new Paragraph("Nadkola osi tylnej z tworzywa sztucznego w kolorze czarnym;", oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Fartuchy przeciw błotne;");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Osłony p/ najazdowe;");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Skrzynka narzędziowa z jednym zamknięciem o pojemności 35l;");
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);


        }
        /***************** Standardowy opis nadwozia  NK  ***********************************/
        private void NK_opis_nadwozia(Dane_podstawowe.Zabudowa zab, Document doc, Tworzenie_pdf oferta)
        {

            Paragraph paragraf = new Paragraph("Standardowy opis nadwozia kontenerowego", oferta.font_punkty);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
            // paragraf.IndentationLeft = 15;

            /************RAMA************/
            paragraf = new Paragraph(wypunktowanie + "Rama pośrednia. ", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

            paragraf = new Paragraph("Wykonana z profili aluminiowych skręcanych.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
    
            /************SCIANY************/
            paragraf = new Paragraph(wypunktowanie + "Ściany.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            doc.Add(paragraf);

            paragraf = new Paragraph("Boczne oraz czołowa wykonane jako płyty warstwowe z laminatu wypełnione izolatorem STYROFOAM o grubości 35 mm (+/- 2mm);", oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Kątownik wewnętrzny przypodłogowy 60x30 mm;");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Listwa otworowa do mocowania drążka rozporowego montowany na pasie aluminiowym anodowanym.");
            
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            doc.Add(paragraf);
            
            
             /************SCIANY ZEWNETRZNE************/
            paragraf = new Paragraph(wypunktowanie + "Ściany zewnętrzne okute profilami aluminiowymi malowanymi na kolor biały.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            doc.Add(paragraf);

            /************DACH************/
            paragraf = new Paragraph(wypunktowanie + "Dach wykonany z laminatu widnego.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            doc.Add(paragraf);

            /************DRZWI TYLNE************/
            paragraf = new Paragraph(wypunktowanie + "Drzwi tylne dwuskrzydłowe.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            doc.Add(paragraf);
            paragraf = new Paragraph("Rama drzwi tylnych wykonana ze stali nierdzewnej z dwoma odbojnikami;", oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Drzwi tylne dwuskrzydłowe wykonane jako płyty warstwowe z laminatu wypełnione izolatorem STYROFOAM o grubości 35 mm (+/- 2mm) o kącie otwarcia 270 stopni;");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Zamknięcia zewnętrzne ze stali nierdzewnej;");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Zawiasy z blachy nierdzewnej INOX;");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Drabina ułatwiająca wejście;");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Łapacze ułatwiające zapięcie drzwi do ściany bocznej wraz z odbojami chroniącymi przed uderzeniem.");
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            doc.Add(paragraf);

          
            /************PODLOGA************/
            paragraf = new Paragraph(wypunktowanie + "Podłoga.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            doc.Add(paragraf);

            paragraf = new Paragraph("Wykonana ze sklejki antypoślizgowej, dwustronnie foliowanej o grubości 15mm;", oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.IndentationLeft = 45;
            doc.Add(paragraf);

            /************OSWIETLENIE************/
            paragraf = new Paragraph(wypunktowanie + "Oświetlenie.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            doc.Add(paragraf);
            paragraf = new Paragraph("Lampy obrysowe zgodnie z przepisami Kodeksu Ruchu Drogowego.", oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Lampa oświetleniowa wewnętrzna (led) załączana w kabinie kierowcy 1 szt.;");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Nad drzwiami tylnymi dodatkowe światło STOP (led).");
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 45;
            doc.Add(paragraf);

            /************OSPRZET************/
            paragraf = new Paragraph(wypunktowanie + "Osprzęt.", oferta.font_dane);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.IndentationLeft = 15;
            doc.Add(paragraf);
            paragraf = new Paragraph("Nadkola osi tylnej z tworzywa sztucznego w kolorze czarnym;", oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Fartuchy przeciw błotne;");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Osłony p/ najazdowe;");
            paragraf.Add(Environment.NewLine);
            paragraf.IndentationLeft = 45;
            doc.Add(paragraf);


        }
        //OPCJE DODATKOWE
        private void Opcje_dodatkowe(DataTable wybrane_opcje_dodatkowe, Document doc, Tworzenie_pdf oferta)
        {

            Paragraph paragraf = new Paragraph("Wyposażone dodatkowe odpłatne:", oferta.font_punkty);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);
          
            string formatowanie;
            //formatowanie_ceny = string.Format("wynosi: {0:n0} PLN netto.", int.Parse(cena.cena_podstawowa));
          
            foreach (DataRow row in wybrane_opcje_dodatkowe.AsEnumerable())
            {
              formatowanie=string.Format(wypunktowanie + row.ItemArray[3].ToString() + " - {0:n0} PLN netto" , int.Parse(row.ItemArray[1].ToString()));
                paragraf = new Paragraph(formatowanie, oferta.font_dane);
                paragraf.SetLeading(0, leading);
                doc.Add(paragraf);
                

            }
            //paragraf = new Paragraph("", oferta.font_dane);
            //paragraf.Add(Environment.NewLine);


        }
        //INFORMACJE DODATKOWE
        private void Informacje_dodatkowe(Document doc, Tworzenie_pdf oferta)
        {
            Paragraph paragraf = new Paragraph("Informacje dodatkowe:", oferta.font_punkty);
            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.SetLeading(0, leading);
            paragraf.SpacingBefore = 25;
            doc.Add(paragraf);

            //   public LineSeparator(float lineWidth, float percentage, BaseColor lineColor, int align, float offset);
            //dottedLineSeparator 
            //PdfLine linia = new PdfLine;
            //linia.
            //Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            //document.Add(p);
            //Chunk linia = new Chunk(new PdfLine(0.5f, 95, BaseColor.BLUE, Element.ALIGN_CENTER, 3.5f));
            /*
            DottedLineSeparator separator = new DottedLineSeparator();
            separator.setPercentage(59500f / 523f);
            Chunk linebreak = new Chunk(separator);
            document.add(linebreak);
            document.add(new Paragraph("After dotted line"));
            */

            paragraf = new Paragraph(wypunktowanie+ "Gwarancja na nadwozie: 24 miesiące;", oferta.font_dane);
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie+"Warunki realizacji: faktura VAT przelew 14 dni;");
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie+"Czas realizacji: około 2-3 tygodni od zamówienia oraz podstawienia podwozia do zabudowy.");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("Dokładny termin realizacji zostanie potwierdzony do dwóch dni roboczych po otrzymaniu");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("zamówienia. Przy składaniu zamówienia konieczne jest podanie daty / tygodnia w którym");
            paragraf.Add(Environment.NewLine);
            paragraf.Add("planowane jest dostarczenie podwozia do naszej firmy.");
            paragraf.Add(Environment.NewLine);
            paragraf.Add(wypunktowanie + "Do podanych cen należy doliczyć 23% VAT.");


            paragraf.Alignment = Element.ALIGN_LEFT;
            paragraf.SetLeading(0, leading);
            doc.Add(paragraf);

        }
    }
}
