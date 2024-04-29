using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using ProgramLowisko.Model;
namespace ProgramLowisko.Scripts
{
    public class DataBaseManagement
    {
        public List<Ryba> Ryby = new List<Ryba>();
        public List<Lowisko> Lowiska = new List<Lowisko>();
        public List<okersOchrony> okresyOchrony = new List<okersOchrony>();
        public List<LowiskoEx> LowiskoE= new List<LowiskoEx>();
        public List<Rybak> Rybacy = new List<Rybak>();


        public MySqlConnectionStringBuilder builder = new()

{

    Server = "localhost",

    Database = "cwiczenia_1",

    UserID = "root",

    Password = "",

};
        public MySqlConnection conn;

        public DataBaseManagement()
        {
    conn = new MySqlConnection(builder.ConnectionString);
        }
        public void ShowFishes()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM ryby", conn);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Ryba ryba = new Ryba
                    {
                        id = rdr.GetUInt16("id"),
                        nazwa = rdr.GetString("nazwa"),
                        wystepowanie = rdr.GetString("wystepowanie"),
                        styl_zycia = rdr.GetInt16("styl_zycia")
                    };
                    Ryby.Add(ryba);
                }
                rdr.Close();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ShowLowiska()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand($"SELECT lowisko.id, ryby.nazwa,lowisko.akwen,lowisko.wojewodztwo,lowisko.rodzaj FROM lowisko JOIN ryby ON lowisko.Ryby_id = ryby.id;", conn);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    LowiskoEx Lowisko = new LowiskoEx
                    {
                        id = rdr.GetUInt16("id"),
                        nazwa = rdr.GetString("nazwa"),
                        akwen = rdr.GetString("akwen"),
                        wojewodztwo = rdr.GetString("wojewodztwo"),
                        rodzaj = rdr.GetUInt16("rodzaj")
                    };
                    LowiskoE.Add(Lowisko);
                }
                rdr.Close();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ShowRybacy()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM rybak", conn);
                MySqlCommand cmd2 = new MySqlCommand($"SHOW TABLES;", conn);
                Tables t = new();
                MySqlDataReader rdr = cmd.ExecuteReader();
                MySqlDataReader rdr2 = cmd2.ExecuteReader();


                while (rdr.Read())
                {
                    Rybak Rybak = new Rybak
                    {
                        id = rdr.GetUInt16("id"),
                        nazwa = rdr.GetString("nazwa"),

                    };
                    Rybacy.Add(Rybak);
                }
                rdr.Close();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void ShowRybacy()
        {
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM rybak", conn);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Rybak Rybak = new Rybak
                    {
                        id = rdr.GetUInt16("id"),
                        nazwa = rdr.GetString("nazwa"),
 
                    };
                    Rybacy.Add(Rybak);
                }
                rdr.Close();

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
