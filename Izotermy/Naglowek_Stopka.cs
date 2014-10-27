using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Izotermy
{
    class Naglowek_Stopka : iTextSharp.text.pdf.PdfPageEventHelper
    { 
    
        protected Font footer_Izotermy
        {
            get
               {
                
                BaseColor grey = new BaseColor(128, 128, 128);
                //BaseFont.CP1257
                //Font font = FontFactory.GetFont(BaseFont.TIMES_ROMAN, BaseFont.CP1257, 7, Font.BOLD, grey);
                Font font = FontFactory.GetFont("Calibri", BaseFont.CP1257, 7, Font.BOLD, grey);
                return font;
                }
        }
        protected Font footer_reszta
        {
            get
            {
                // create a basecolor to use for the footer font, if needed.
                BaseColor grey = new BaseColor(128, 128, 128);
                Font font = FontFactory.GetFont("Calibri", BaseFont.CP1257, 5, Font.BOLD, grey);
                return font;
            }
        }
     
    //override the OnStartPage event handler to add our header
    public override void OnStartPage(PdfWriter writer, Document doc)
        {
        //I use a PdfPtable with 1 column to position my header where I want it
            PdfPTable headerTbl = new PdfPTable(1);
        //float[] tb= { 75,doc.PageSize.Width,75};
        //char[] znaki = {‘T’,'o’,’ ‘,’j',’e',’s',’t',’ ‘,’t',’e',’k',’s',’t'} ;
        //tb={75;doc.PageSize.Width;75};

       // headerTbl.SetWidths(tb);
            //set the width of the table to be the same as the document
            headerTbl.TotalWidth = doc.PageSize.Width-100;
            headerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
        //headerTbl.
            Image logo = Image.GetInstance("Naglowek.png");

            //I used a large version of the logo to maintain the quality when the size was reduced. I guess you could reduce the size manually and use a smaller version, but I used iTextSharp to reduce the scale. As you can see, I reduced it down to 7% of original size.
            //logo.ScalePercent(7);
            //Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1F, 85.0F, BaseColor.BLUE, Element.ALIGN_CENTER, 0)));
            //create instance of a table cell to contain the logo
            PdfPCell cell = new PdfPCell(logo);

            cell.BorderWidthLeft = 0;
            cell.BorderWidthRight = 0;
            cell.BorderWidthTop = 0;
            cell.BorderWidthBottom = 1;
            cell.BorderColorBottom = BaseColor.BLUE;
           

            //align the logo to the right of the cell
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
 
            headerTbl.AddCell(cell);
           
 
           //cell.Add(p);
            //PdfPCell linia = new PdfPCell(p);
           //linia.HorizontalAlignment = Element.ALIGN_CENTER;
           //linia.h = 1;
            //remove the border
            //linia.Border = 0;

        //cell.AddElement(p);

            //Add the cell to the table
            //headerTbl.AddCell(linia);
 

            //write the rows out to the PDF output stream. I use the height of the document to position the table. Positioning seems quite strange in iTextSharp and caused me the biggest headache.. It almost seems like it starts from the bottom of the page and works up to the top, so you may ned to play around with this.
            headerTbl.WriteSelectedRows(0,-1, 50, (doc.PageSize.Height-10), writer.DirectContent);
         //   headerTbl.WriteSelectedRows(0, -1, 0, (doc.PageSize.Height), writer.DirectContent);
        }
 
        //override the OnPageEnd event handler to add our footer
        /*
         *tworzymy dwie tabele, jedna do wypelniania prawej strony druga do wypelniania lewej strony 
         * 
         * 
         */
    public override void OnEndPage(PdfWriter writer, Document doc)
        {
            PdfPTable footerTbl = new PdfPTable(2);
            //set the width of the table to be the same as the document
            footerTbl.TotalWidth = doc.PageSize.Width-100;
            float[] tb = new float[2] { 2, 1 };
            //tb=[2;1];

        footerTbl.SetWidths(tb);
            //Center the table on the page
            footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
            PdfPCell cell;
            //Create a paragraph that contains the footer text
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(1F,100F, BaseColor.BLUE, Element.ALIGN_CENTER, 0)));
            cell = new PdfPCell(p);
           // cell.Border = 0;   
            cell.Colspan=2;
            footerTbl.AddCell(cell);
       
            Paragraph para = new Paragraph("IZOTERMY TIM Sp. z o.o. Ul. Krzyżowa 2c, 41-909 Bytom", footer_Izotermy);
            //PdfPCell cell = new PdfPCell(para);
            //cell.Border = 0;
            //cell.PaddingLeft = 60;
            //footerTbl.AddCell(cell);
 
            
            //para = new Paragraph("Ul. Krzyżowa 2c, 41-909 Bytom", footer_reszta); 
            para.Add(Environment.NewLine);
            para.Add(Environment.NewLine);
            para.Add("KRS: 0000476193, Sąd Rejonowy Katowice-Wschód w Katowicach kapitał zakładowy: 90.000,00 zł");
            para.Add(Environment.NewLine);
            para.Add(Environment.NewLine);    
            para.Add("NIP: 498-020-75-67 REGON: 240407046");
            para.Add(Environment.NewLine);
            para.Add(Environment.NewLine);
            para.Add("www.izotermy.com.pl");
            cell = new PdfPCell(para);
        
        //    cell.Border = 0;
 
            //add some padding to bring away from the edge
            //cell.PaddingLeft = 50;
          //  cell.HorizontalAlignment = Element.ALIGN_LEFT;
            //add cell to able
          //  cell.Width = doc.PageSize.Width;
            footerTbl.AddCell(cell);

            Image Stopka = Image.GetInstance("Stopka.png");
            Stopka.ScalePercent(70);    
            cell = new PdfPCell(Stopka);
           // cell.PaddingRight = 50;  
        //    cell.Border = 0;
          //  Stopka.ScalePercent(7);
             cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //cell.PaddingBotto
            cell.VerticalAlignment = Element.ALIGN_BOTTOM;
        footerTbl.AddCell(cell);

            // cell.PaddingLeft = 60;
        footerTbl.WriteSelectedRows(0,-1, 50, (doc.BottomMargin), writer.DirectContent);
 /*
            footerTbl = new PdfPTable(2);
            //set the width of the table to be the same as the document
            footerTbl.TotalWidth = doc.PageSize.Width;

            //Center the table on the page
            footerTbl.HorizontalAlignment = Element.ALIGN_CENTER ;
            //Image Stopka = Image.GetInstance("Stopka.png");
            
            //Create a paragraph that contains the footer text
           
        //Paragraph para = new Paragraph("IZOTERMY TIM Sp. z o.o.", footer_Izotermy);
        //    cell = new PdfPCell(Stopka);
            PdfPCell Cell_pusta = new PdfPCell();
       //     Cell_pusta.Border = 0;
           // cell.PaddingLeft = 60;
            Cell_pusta.HorizontalAlignment =  Element.ALIGN_LEFT;
         //   Stopka.ScalePercent(7);
            footerTbl.AddCell(Cell_pusta);

            Image Stopka = Image.GetInstance("Stopka.png");



            cell = new PdfPCell(Stopka);

          //  cell.Border = 0;

            //add some padding to bring away from the edge
            cell.PaddingRight = 50;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //add cell to table
            footerTbl.AddCell(cell);


            footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin), writer.DirectContent);
        */
        
        }
    }
}