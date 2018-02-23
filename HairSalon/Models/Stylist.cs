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

    public static List<Stylist> GetAll()
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

  }
}
