using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
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
  }
}
