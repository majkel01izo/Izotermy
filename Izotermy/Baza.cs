using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Windows;
using Data_Base;
using System.Data;



namespace Izotermy
{
    class Baza
    {
        public ArrayList odczyt_pliku_tekstowego(string nazwa_pliku)
        {
            //FileStream plik = new FileStream(nazwa_pliku+".txt",
              //                                      FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader objReader = new StreamReader("Lista_kolumn.txt");
            string sLine = "";
            ArrayList arrText = new ArrayList();
              
            try
            {
                
                while (sLine != null)
                {
                    sLine = objReader.ReadLine();
                    if (sLine != null)
                        arrText.Add(sLine);
                }
                objReader.Close();

                /*ArrayList arrText = new ArrayList();
                richText.Text = sr.ReadToEnd();
                sr.Close();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            return arrText;
        }




    }
}
