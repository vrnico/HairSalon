using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private string _name;
    private int _id;

    public Stylist(string name, int Id = 0)
    {
      _name = name;
      _id = Id;

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
        Stylist newStylist = new Stylist(stylistName, stylistId);
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

    public override int GetHashCode()
   {
     return this.GetId().GetHashCode();
   }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `stylists` (`name`) VALUES (@Name);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@name";
      name.Value = this._name;

      cmd.Parameters.Add(name);
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
        int clientId = rdr.GetInt32(1);
        string clientName = rdr.GetString(0);
        string rawAppt = rdr.GetString(2);
        int clientStylistId = rdr.GetInt32(3);
        Client newClient = new Client(clientName, rawAppt, clientId, clientStylistId);
        // newClient.SetAppt();
        allStylistClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }

      return allStylistClients;
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

        while (rdr.Read())
        {
            stylistId = rdr.GetInt32(1);
            stylistName = rdr.GetString(0);

        }

        Stylist foundStylist = new Stylist(stylistName, stylistId);

        conn.Close();
        if (conn != null)
        {
        conn.Dispose();
        }

        return foundStylist;
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists WHERE id = @thisId;";

      var cmdClients = conn.CreateCommand() as MySqlCommand;
      cmdClients.CommandText = @"DELETE FROM clients WHERE stylist_id = @thisId;";

      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = _id;
      cmd.Parameters.Add(thisId);
      cmdClients.Parameters.Add(thisId);
      cmdClients.ExecuteNonQuery();

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
