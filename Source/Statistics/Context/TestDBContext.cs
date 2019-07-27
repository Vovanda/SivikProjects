using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using Devart.Data.SQLite;
using Statistics.Data;

namespace Statistics.Context
{  
  //TODO: Rewrite TestDbContext.
  internal class TestDbContext
  {
    public TestDbContext()
    {
      _connection = new SQLiteConnection(@"DataSource=test.db; Password=secret_key; Encryption=SQLCipher;");
    }

    public List<CountItemsInGroup> GetStatisticOfRistrationsByCountry()
    {
      var resultList = new List<CountItemsInGroup>();
      string commandText = $@"
            SELECT COUNT(*) as count, is_owner, confirmed, role, country
            FROM user
            WHERE role = 'CUSTOMER' AND is_owner = 1 AND confirmed = 1
            GROUP BY country
            ORDER BY country DESC";

      _connection.Open();
      var command = new SQLiteCommand(commandText, _connection);
      foreach (DbDataRecord record in command.ExecuteReader())
      {
        int.TryParse(record["count"]?.ToString(), out int count);
        var value = record["country"]?.ToString();

        if (!string.IsNullOrEmpty(value))
        {
          resultList.Add(new CountItemsInGroup { GroupItemValue = value, Count = count});
        }
      }
      _connection.Close();
      return resultList;
    }

    public List<CountItemsInGroup> GetStatisticOfRistrationsByRegion(string country)
    {
      var resultList = new List<CountItemsInGroup>();
      string commandText = $@"
            SELECT COUNT(*) as count, is_owner, confirmed, role, country, region
            FROM user
            WHERE role = 'CUSTOMER' AND is_owner = 1 AND confirmed = 1 AND country = '{country}' 
            GROUP BY region
            ORDER BY region";

      _connection.Open();
      var command = new SQLiteCommand(commandText, _connection);
      foreach (DbDataRecord record in command.ExecuteReader())
      {
        int.TryParse(record["count"]?.ToString(), out int count);
        var value = record["region"]?.ToString();

        if (!string.IsNullOrEmpty(value))
        {
          resultList.Add(new CountItemsInGroup { GroupItemValue = value, Count = count, });
        }
      }
      _connection.Close();
      return resultList;
    }

    public List<CountItemsInGroup> GetStatisticOfRistrationsByMonth(string year)
    {
      var resultList = new List<CountItemsInGroup>();
      string commandText = $@"
            SELECT COUNT(*) as count, is_owner, confirmed, role, substr(purchase_date, 4, 2) as month, substr(purchase_date, 7, 4) as year
            FROM user
            WHERE role = 'CUSTOMER' AND is_owner = 1 AND confirmed = 1 AND year = '{year}'
            GROUP BY month
            ORDER BY month";

      _connection.Open();
      var command = new SQLiteCommand(commandText, _connection);
      foreach (DbDataRecord record in command.ExecuteReader())
      {
        int.TryParse(record["count"]?.ToString(), out int count);
        var value = record["month"]?.ToString();

        if (int.TryParse(value, out int month))
        {
          string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
          resultList.Add(new CountItemsInGroup { GroupItemValue = monthName, Count = count});
        }
      }
      _connection.Close();
      return resultList;
    }
 
    public List<string> GetYearList()
    {
      var resultList = new List<string>();
      _connection.Open();
      string commandText = @"
        SELECT DISTINCT role, substr(purchase_date, 7, 4) as year
        FROM user
        WHERE role = 'CUSTOMER'
        ORDER BY year";

      var command = new SQLiteCommand(commandText, _connection);
      var reader = command.ExecuteReader();
      foreach (DbDataRecord record in reader)
      {
        var year = record["year"]?.ToString();
        if (!string.IsNullOrEmpty(year))
        {
          resultList.Add(year);
        }
      }
      _connection.Close();
      return resultList;
    }

    public List<string> GetCountryList()
    {
      var resultList = new List<string>();
      _connection.Open();
      string commandText = @"
        SELECT DISTINCT role, country
        FROM user
        WHERE role = 'CUSTOMER'
        ORDER BY country DESC";

      var command = new SQLiteCommand(commandText, _connection);
      var reader = command.ExecuteReader();
      foreach (DbDataRecord record in reader)
      {
        var country = record["country"]?.ToString();
        if (!string.IsNullOrEmpty(country))
        {
          resultList.Add(country);
        }
      }
      _connection.Close();
      return resultList;
    }

    private readonly SQLiteConnection _connection;
  }
}