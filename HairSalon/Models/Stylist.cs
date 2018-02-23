using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _name;
    private int _id;
    private string _rawDate;
    private DateTime _formattedDate;

    public Stylist(string name, string rawDate, int Id = 0)
    {
      _name = name;
      _id = Id;
      _rawDate = rawDate;
      _formattedDate = new DateTime();
    }




    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
          conn.Dispose();
      }
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Stylist> GetAllStylists()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int stylistId = rdr.GetInt32(1);
        string stylistName = rdr.GetString(0);
        string stylistRawDate = rdr.GetString(2);
        Stylist newStylist = new Stylist(stylistName, stylistRawDate, stylistId);
        newStylist.SetDate();
        allStylists.Add(newStylist);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if (!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        return this.GetId().Equals(newStylist.GetId());
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `stylists` (`name`, `raw_date`, `formatted_date`) VALUES (@Name, @RawDate, @FormattedDate);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._name;

            MySqlParameter rawDate = new MySqlParameter();
            rawDate.ParameterName = "@RawDate";
            rawDate.Value = this._rawDate;

            MySqlParameter formattedDate = new MySqlParameter();
            formattedDate.ParameterName = "@FormattedDate";
            formattedDate.Value = this._formattedDate;


            cmd.Parameters.Add(name);
            cmd.Parameters.Add(rawDate);
            cmd.Parameters.Add(formattedDate);


            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Client> GetClients()
    {
      List<Client> allStylistClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `clients` WHERE `stylist_id` = @stylist_id;";

      MySqlParameter stylistId = new MySqlParameter();
      stylistId.ParameterName = "@stylist_id";
      stylistId.Value = this._id;
      cmd.Parameters.Add(stylistId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string clientRawDate = rdr.GetString(2);
        int clientStylistId = rdr.GetInt32(4);
        Client newClient = new Client(clientName, clientRawDate, clientId, clientStylistId);
        newClient.SetAppt();
        allStylistClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return allStylistClients;
    }

    public DateTime GetFormattedDate()
    {
      return _formattedDate;
    }

    public string GetRawDate()
    {
      return _rawDate;
    }

    public void SetDate()
    {
      string[] dateArray = _rawDate.Split('-');
      List<int> intDateList = new List<int>{};
      foreach (string num in dateArray)
      {
        intDateList.Add(Int32.Parse(num));
      }
      _formattedDate = new DateTime(intDateList[0], intDateList[1], intDateList[2]);
    }

    public static Stylist Find(int id)
    {
        MySqlConnection conn = DB.Connection();
        conn.Open();

        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * from `stylists` WHERE id = @thisId;";

        MySqlParameter thisId = new MySqlParameter();
        thisId.ParameterName = "@thisId";
        thisId.Value = id;
        cmd.Parameters.Add(thisId);


        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        int stylistId = 0;
        string stylistName = "";
        string stylistRawDate = "";

        while (rdr.Read())
        {
            stylistId = rdr.GetInt32(1);
            stylistName = rdr.GetString(0);
            stylistRawDate = rdr.GetString(2);

        }

        Stylist foundStylist = new Stylist(stylistName, stylistRawDate, stylistId);

        conn.Close();
        if (conn != null)
        {
        conn.Dispose();
        }

        return foundStylist;
    }

  }
}
