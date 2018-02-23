using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Client
  {
    private string _name;
    private int _id;
    private string _rawAppt;
    private DateTime _formattedAppt;
    private int _stylistId;


    public Client(string name, string rawAppt, int Id = 0, int stylistId = 0)
    {
      _name = name;
      _id = Id;
      _rawAppt = rawAppt;
      _formattedAppt = new DateTime();
      _stylistId = stylistId;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM clients;";

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

    public int GetStylistId()
    {
      return _stylistId;
    }

    public void SetStylistId(int id)
    {
      _stylistId = id;
    }

    public static List<Client> GetAll()
    {
      List<Client> allClients = new List<Client> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM clients;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int clientId = rdr.GetInt32(0);
        string clientName = rdr.GetString(1);
        string clientRawAppt = rdr.GetString(2);
        int stylistId = rdr.GetInt32(4);
        Client newClient = new Client(clientName, clientRawAppt, clientId, stylistId);
        newClient.SetAppt();
        allClients.Add(newClient);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allClients;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `clients` (`name`, `raw_appt`, `formatted_appt`, `stylist_id`) VALUES (@Name, @RawAppt, @FormattedAppt, @StylistId);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._name;

            MySqlParameter rawAppt = new MySqlParameter();
            rawAppt.ParameterName = "@RawAppt";
            rawAppt.Value = this._rawAppt;

            MySqlParameter formattedAppt = new MySqlParameter();
            formattedAppt.ParameterName = "@FormattedAppt";
            formattedAppt.Value = this._formattedAppt;

            MySqlParameter stylistId = new MySqlParameter();
            stylistId.ParameterName = "@StylistId";
            stylistId.Value = this._stylistId;

            cmd.Parameters.Add(name);
            cmd.Parameters.Add(rawAppt);
            cmd.Parameters.Add(formattedAppt);
            cmd.Parameters.Add(stylistId);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

    public override bool Equals(System.Object otherClient)
    {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = (this.GetId() == newClient.GetId());
        bool nameEquality = (this.GetName() == newClient.GetName());
        bool stylistEquality = (this.GetStylistId() == newClient.GetStylistId());
        return (idEquality && nameEquality && stylistEquality);
      }
    }

    public DateTime GetFormattedAppt()
    {
      return _formattedAppt;
    }

    public string GetRawAppt()
    {
      return _rawAppt;
    }

    public void SetAppt()
    {
      string[] dateArray = _rawAppt.Split('-');
      List<int> intDateList = new List<int>{};
      foreach (string num in dateArray)
      {
        intDateList.Add(Int32.Parse(num));
      }
      _formattedAppt = new DateTime(intDateList[0], intDateList[1], intDateList[2]);
    }
  }
}
