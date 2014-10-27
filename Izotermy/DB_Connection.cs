using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace Data_Base
 {
    class DB_Connection:IDisposable
    {
        private MySqlConnection polaczenie;
      //  private string server;
        private string baza;
        private string username;
        private string pass;
        
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DB_Connection()
        {
            //Initialize("localhost","izotermy");
            Initialize();
        }

        public DB_Connection(string login, string haslo)
        {
            username = login;
            pass = haslo;
         Initialize("localhost","izotermy");
        }
        
        private void Initialize()
        {
           // server = "localhost";
            //baza = "izotermy";

            
            server = "mysql.bmj.net.pl";
            baza = "izotermy2";
            username = "izotermy";
            pass = "am12dfg13p";
      
            string connection_string;
            connection_string = "SERVER= " + server + " ;" + "DATABASE= " + baza + " ;" +
                "UID= " + username + " ;" + "PASSWORD= " + pass + " ;";
         
            polaczenie = new MySqlConnection(connection_string);
           
           
          
        }
       
        private void Initialize(string server, string baza)
        {
           // server = "localhost";
           // baza = "izotermy";

            if (!(string.IsNullOrWhiteSpace(username)) || (string.IsNullOrWhiteSpace(pass)))
            {
                username = "alicja";
                pass = "";
            }
            string connection_string;
            connection_string = "SERVER=" + server + ";" + "DATABASE=" + baza + ";" +
                "UID=" + username + ";" + "PASSWORD=" + pass + ";";
            polaczenie = new MySqlConnection(connection_string);

        }
       
        public bool Open_connection()
        {

            try
            {
                polaczenie.Open();
                //       MessageBox.Show("polaczono pomyslnie");
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Nie mozna polaczyc z serwerem");
                        MessageBox.Show(ex.Message);
                        break;

                    case 1045:
                        MessageBox.Show("Zla nazwa uzytkownika lub haslo");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }

        }
        public bool Close_connection()
        {
            try
            {
                polaczenie.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Insert(string query)
        {
            // string query = "INSERT INTO Uzytkownicy (Login, Haslo) VALUES ('jabla', 'aaaja2')";
            // string dodaj = "grant all on * to alicja;";

            if (this.Open_connection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, polaczenie);
                //          MySqlCommand cmd = new MySqlCommand(dodaj, polaczenie);

                cmd.ExecuteNonQuery();
                this.Close_connection();
            }
        }

        public void Insert(DataTable tabela, string nazwa_tabeli, int liczba_kolumn)
        {
            // string query = "INSERT INTO Uzytkownicy (Login, Haslo) VALUES ('jabla', 'aaaja2')";
            // string dodaj = "grant all on * to alicja;";

            string polecenie = "INSERT INTO izotermy2." + nazwa_tabeli + " VALUES ";
            string obiekty = "";

            int i;
            i = 1;
            foreach (DataRow row in tabela.Rows)
            {
                obiekty += "(" + i + ", " + row.Field<int>(1)+" , " + row.Field<int>(2) + "),";
                i++;
            }
            
            
            obiekty = obiekty.Remove(obiekty.Length - 1);
            obiekty += ";";
            MessageBox.Show(obiekty);
            polecenie += obiekty;


            if (this.Open_connection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(polecenie, polaczenie);
                cmd.ExecuteNonQuery();
                this.Close_connection();
            }
        }
        public void Insert(DataTable tabela, string nazwa_tabeli)
        {
            // string query = "INSERT INTO Uzytkownicy (Login, Haslo) VALUES ('jabla', 'aaaja2')";
            // string dodaj = "grant all on * to alicja;";

            string polecenie = "INSERT INTO izotermy2." + nazwa_tabeli + " VALUES ";
            string obiekty = "";


            foreach (DataRow row in tabela.Rows)
            {
                obiekty += "(" + row.Field<int>(0) + ", '" + row.Field<string>(1) + "'),";
            }


            obiekty = obiekty.Remove(obiekty.Length - 1);
            obiekty += ";";
            polecenie += obiekty;


            if (this.Open_connection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(polecenie, polaczenie);
                cmd.ExecuteNonQuery();
                this.Close_connection();
            }
        }
        
        public string DB_Select_string(string tabela, string wyrazenie)
        {
           
            string query = "SELECT "+ wyrazenie+ " FROM izotermy2."+tabela;
            DataTable tabela_select = new DataTable();
            String str="ala";
            MessageBox.Show(query);

            List<string>[] list = new List< string >[1];
           
            if (this.Open_connection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, polaczenie);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        str = dataReader.GetString(0);
                    }
                    else
                        return "0";
                }
                
                dataReader.Close();

                this.Close_connection();

                return str;
            }
            else
            {
                return str ;
            }
        }
        public string DB_Select_string(string tabela, string wyrazenie, string warunek)
        {

            string query = "SELECT " + wyrazenie + " FROM izotermy2." + tabela + " Where "+warunek;
            DataTable tabela_select = new DataTable();
            String str = "ala";
            MessageBox.Show(query);
            List<string>[] list = new List<string>[1];

            if (this.Open_connection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, polaczenie);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        str = dataReader.GetInt32(0).ToString();
                    }
                    else
                        return "0";
                }

                dataReader.Close();

                this.Close_connection();

                return str;
            }
            else
            {
                return str;
            }
        }
        public void Insert_oferta(string month, string year, string typ, string osoba_oferujaca)
        {
            // string query = "INSERT INTO Uzytkownicy (Login, Haslo) VALUES ('jabla', 'aaaja2')";
            // string dodaj = "grant all on * to alicja;";

            string polecenie = "INSERT INTO izotermy2.numer_oferty VALUES ";
            string obiekty = "";

            //int i;
            //i = 1;

            obiekty = "( default" + ", " +month + " , " + year + " , '" + typ + "' , '" + osoba_oferujaca + "');";
            
            /*
            foreach (DataRow row in tabela.Rows)
            {
                obiekty += "( default" + ", " + row.Field<int>(1) + " , " + row.Field<int>(2) + " , " + row.Field<int>(3) + " , " + row.Field<int>(4) + "),";
                i++;
            }
            */

          //  obiekty = obiekty.Remove(obiekty.Length - 1);
           // obiekty += ";";
            //MessageBox.Show(obiekty);
            polecenie += obiekty;
           // MessageBox.Show(polecenie);

            if (this.Open_connection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(polecenie, polaczenie);
                cmd.ExecuteNonQuery();
                this.Close_connection();
            }
        }
        public void Create_table(string table_name, string kolumna_2)
        {

            string instruction;
            string kolumna_1;
            kolumna_1 = "id" + table_name;
            instruction = "CREATE TABLE IF NOT EXISTS `izotermy2`.`" + table_name + "` " +
                "( `" + kolumna_1 + "` INT UNSIGNED NOT NULL AUTO_INCREMENT,  " +
                "`" + kolumna_2 + "` VARCHAR(45) NOT NULL, " +
                "PRIMARY KEY (`" + kolumna_1 + "`),  UNIQUE INDEX `" + kolumna_1 + "_UNIQUE` (`" + kolumna_1 + "` ASC))" +
                "  ENGINE = InnoDB";
            /*
            instruction = "CREATE TABLE IF NOT EXISTS `Izotermy`.`"+table_name+
                        "` (`idtest` INT UNSIGNED NOT NULL AUTO_INCREMENT,"+
                        "`testcol` VARCHAR(45) NOT NULL,"+
                        "PRIMARY KEY (`idtest`))"+
                        " ENGINE = InnoDB;";
            instruction = "CREATE TABLE IF NOT EXISTS `Izotermy`.`" + table_name + "` " +
                "( `" + kolumna_1 + "` INT UNSIGNED NOT NULL AUTO_INCREMENT,  " +
                "`" + kolumna_2 + "` VARCHAR(45) NOT NULL, " +
                "PRIMARY KEY (`" + kolumna_1 + "`),  UNIQUE INDEX `" + kolumna_1 + "_UNIQUE` (`" + kolumna_1 + "` ASC)," +
                "  UNIQUE INDEX `" + kolumna_2 + "_UNIQUE` (`" + kolumna_2 + "` ASC))ENGINE = InnoDB";
      
             */
            //MessageBox.Show(instruction);
            if (this.Open_connection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(instruction, polaczenie);

                cmd.ExecuteNonQuery();
                this.Close_connection();
            }
            /*
                CREATE TABLE IF NOT EXISTS `Izotermy`.`Marka` ( `idMarka` INT UNSIGNED NOT NULL AUTO_INCREMENT,  `Marka` VARCHAR(45) NOT NULL,  PRIMARY KEY (`idMarka`),  UNIQUE INDEX `idMarka_UNIQUE` (`idMarka` ASC),  UNIQUE INDEX `Marka_UNIQUE` (`Marka` ASC))ENGINE = InnoDB;
     
             CREATE TABLE IF NOT EXISTS `Izotermy`.`test` (`idtest` INT UNSIGNED NOT NULL AUTO_INCREMENT,`testcol` VARCHAR(45) NOT NULL,PRIMARY KEY (`idtest`)) ENGINE = InnoDB;
             */

        }
        public void Create_table(string table_name, string kolumna_2, string kolumna_3)
        {
            string instruction;
            string kolumna_1="id" + table_name;
            
            instruction = "CREATE TABLE IF NOT EXISTS `izotermy2`.`" + table_name + "` " +
                "( `" + kolumna_1 + "` INT UNSIGNED NOT NULL AUTO_INCREMENT,  " +
                "`" + kolumna_2 + "` VARCHAR(45) NOT NULL, " +
                "`" + kolumna_3 + "` INT UNSIGNED NOT NULL, " +
                "PRIMARY KEY (`" + kolumna_1 + "`),  UNIQUE INDEX `" + kolumna_1 + "_UNIQUE` (`" + kolumna_1 + "` ASC))" +
                "  ENGINE = InnoDB";
            if (this.Open_connection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(instruction, polaczenie);
                cmd.ExecuteNonQuery();
                this.Close_connection();
            }
        }

        public void Update()
        {

            string query = "UPDATE Uzytkownicy SET Login='ala', Haslo='maaa' WHERE Login ='jabla'";

            if (this.Open_connection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandText = query;
                cmd.Connection = polaczenie;

                this.Close_connection();

            }
        }
        public void dodaj_uzytkownika(string login, string haslo)
        {
            string querry;
            querry = "grant all on izotermy2.* to " + login + " identified by '" + haslo + "';";
         //   MessageBox.Show(querry);
            Insert(querry);
        }
        public List<string> DB_Select_list(string szukana_fraza, string tabela)
        {
            string query = "SELECT " + szukana_fraza + " FROM " + tabela;
            //DataTable tabela_select = new DataTable();
            List<string> pobrane_dane = new List<string>();

            //Open connection
            if (this.Open_connection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, polaczenie);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //tabela_select.Columns.Add(dataReader);

                while (dataReader.Read())
                {
                    pobrane_dane.Add(dataReader.GetString(0));

                }


                //tabela_select.Load(dataReader);

                //close Data Reader
                //dataReader.Close();

                //close Connection
                this.Close_connection();

                //return list to be displayed
                return pobrane_dane;
            }
            else
            {
                return pobrane_dane;
            }
        }
        public List<string> DB_Select_list_where(string szukana_fraza, string tabela, string warunek)
        {
            string query = "SELECT " + szukana_fraza + " FROM " + tabela + " WHERE "+ warunek;
            //DataTable tabela_select = new DataTable();
            List<string> pobrane_dane = new List<string>();
         //   MessageBox.Show(query);
            //Open connection
            if (this.Open_connection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, polaczenie);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //tabela_select.Columns.Add(dataReader);

                while (dataReader.Read())
                {
                    pobrane_dane.Add(dataReader.GetString(0));

                }


                //tabela_select.Load(dataReader);

                //close Data Reader
                //dataReader.Close();

                //close Connection
                this.Close_connection();

                //return list to be displayed
                return pobrane_dane;
            }
            else
            {
                return pobrane_dane;
            }
        }
        public DataTable DB_Select(string szukana_fraza, string tabela)
        {
            //MessageBox.Show(tabela);

            string query = "SELECT " + szukana_fraza + " FROM izotermy2." + tabela;
            
    
            
            DataTable tabela_select = new DataTable();
        
            //Open connection
            if (this.Open_connection() == true)
            {
        
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, polaczenie);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //tabela_select.Columns.Add(dataReader);
                
                tabela_select.Load(dataReader);
      
                //close Data Reader
                dataReader.Close();

                //close Connection
                this.Close_connection();
                //return list to be displayed
                return tabela_select;
            }
            else
            {
              
                return tabela_select;
            }
        }
        public DataTable DB_Select(string tabela)
        {
            //MessageBox.Show(tabela);

            string query = "SELECT * FROM " + tabela;
            DataTable tabela_select = new DataTable();

            if (this.Open_connection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, polaczenie);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                tabela_select.Load(dataReader);

                dataReader.Close();

                this.Close_connection();

                return tabela_select;
            }
            else
            {
                return tabela_select;
            }
        }
        
        public DataTable Select_where(string szukana_fraza, string tabela, string warunek)
        {
            //  MessageBox.Show(tabela);

            string query = "SELECT " + szukana_fraza + " FROM " + tabela + " WHERE " + warunek;
            //string query="select idFiat \n from fiat \n where Fiat = 'DUCATO  L1'";
            //select idFiat from fiat where Fiat = 'DUCATO  L1'";
            DataTable tabela_select = new DataTable();
            //MessageBox.Show(query);
            //Open connection
            if (this.Open_connection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, polaczenie);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //tabela_select.Columns.Add(dataReader);
                tabela_select.Load(dataReader);

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.Close_connection();
                
                //MessageBox.Show(tabela_select.ToString());
                //return list to be displayed
                return tabela_select;
            }
            else
            {
                return tabela_select;
            }
        }


        public void Dispose()
        {
            this.Close_connection();
        }
    }


}

