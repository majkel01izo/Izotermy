using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Izotermy
{
    class Tworzenie_pdf
    {
        public Document Inicjalizacja(string nazwa)
        {
            Naglowek_Stopka page = new Naglowek_Stopka();

            FileStream fs = new FileStream(nazwa +".pdf", FileMode.Create, FileAccess.Write, FileShare.None);

            Rectangle rec2 = new Rectangle(PageSize.A4);

            //Document doc = new Document(rec2);
            //Document doc = new Document(PageSize.A4, 36, 72, 108, 180);
            //gora 3,24 cm = 1,28 cala => 94 punkty 95 +10 by zmiesicic sie w obszarze wydruku
            //dol  3,75 cm = 1,47 cala => 108 punkty 110
            // 2 cm = 0,79 cala => 58 punkty 60

            Document doc = new Document(rec2, 60, 60, 105, 80);

            PdfWriter writer = PdfWriter.GetInstance(doc, fs);  //.InitialLeading;

            writer.InitialLeading=20;
            
            writer.PageEvent = page;

            //PdfWriter.getInstance(document, new FileOutputStream(RESULT));


            return doc;

        }

        public void Open_file (Document doc)
        {
             doc.Open();
        }

        public void Close_file(Document doc)
        {
             doc.Close();
        }

        public Font font (int wielkosc, string S_styl)
        {
                // create a basecolor to use for the footer font, if needed.
                // BaseColor grey = new BaseColor(128, 128, 128);
            int I_styl;

            switch (S_styl)
            {
                case "NORMAL":
                        I_styl = 0;
                        break;
                case "BOLD":
                        I_styl = 1;
                        break;
                case "ITALIC":
                        I_styl = 2;
                        break;
                default:
                        I_styl = 0;
                        break;
            }

                Font font = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, wielkosc, I_styl);
                return font;
            
        }
        
        public Font font_oferta
        {
            get
            {
                //Font font = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 12, Font.BOLD);
                return font(12,"BOLD");
            }
        }
        public Font font_punkty
        {
            get
            {
                //Font font = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 12, Font.BOLD);
                return font(9, "BOLD");
            }
        }
        public Font font_gora_prawa
        {
            get
            {
                //Font font = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 12, Font.BOLD);
                return font(8, "NORMAL");
            }
        }
        public Font font_dane
        {
            get
            {
                //Font font = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 12, Font.BOLD);
                return font(9, "NORMAL");
            }
        }
        public void Linia_odstepu(Document doc)
        {
            Paragraph paragraf;
            paragraf = new Paragraph(Environment.NewLine);
            paragraf.Alignment = Element.ALIGN_LEFT;
            doc.Add(paragraf);
            
        }

    }
}
