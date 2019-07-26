using System.Collections.Generic;
using System.Data.Common;
using Devart.Data.SQLite;
using System.ComponentModel;

namespace Statistics.Context
{  
  //TODO: Rewrite TestDbContext.
  internal class TestDbContext
  {
    public TestDbContext()
    {
      _connection = new SQLiteConnection(@"DataSource=test.db; Password=secret_key; Encryption=SQLCipher;");
    }

    public List<CountItemsInGroup> GetStatisticOfCountInGroup(QueryForGroup query)
    {
      var resultList = new List<CountItemsInGroup>();
      string commandText = GetSQLiteCommand(query);
      _connection.Open();
      var command = new SQLiteCommand(commandText, _connection);
      foreach (DbDataRecord record in command.ExecuteReader())
      {
        int.TryParse(record["count"]?.ToString(), out int count);
        var value = record[$"{query.GroupingType.GetDescription()}"]?.ToString();

        if (!string.IsNullOrEmpty(value))
        {
          resultList.Add(new CountItemsInGroup { GroupItemValue = value, Count = count, GroupingType = query.GroupingType });
        }
      }
      _connection.Close();
      return resultList;
    }

    private string GetSQLiteCommand(QueryForGroup query)
    {
      switch (query.GroupingType)
      {
        case GroupingType.Country:
          {
            return $@"
            SELECT COUNT(*) as count, is_owner, confirmed, role, country as {GroupingType.Country.GetDescription()}
            FROM user
            WHERE role = 'CUSTOMER' AND is_owner = 1 AND confirmed = 1
            GROUP BY {GroupingType.Country.GetDescription()}";
          }
        case GroupingType.Region:
          {
            return $@"
            SELECT COUNT(*) as count, is_owner, confirmed, role, country, region as {GroupingType.Region.GetDescription()}
            FROM user
            WHERE role = 'CUSTOMER' AND is_owner = 1 AND confirmed = 1 AND country = '{query}' 
            GROUP BY {GroupingType.Region.GetDescription()}";

          }
        case GroupingType.Month:
          {
            return $@"
            SELECT COUNT(*) as count, is_owner, confirmed, role, substr(purchase_date, 4, 2) as {GroupingType.Month.GetDescription()}, substr(purchase_date, 7, 4) as year
            FROM user
            WHERE role = 'CUSTOMER' AND is_owner = 1 AND confirmed = 1 AND year = '{query}'
            GROUP BY {GroupingType.Month.GetDescription()}";
          }
      }
      return string.Empty;
    }

    public List<QueryForGroup> GetQueriesForGroupByMonth()
    {
      var resultList = new List<QueryForGroup>();
      _connection.Open();
      string commandText = @"
        SELECT DISTINCT role, substr(purchase_date, 7, 4) as year
        FROM user
        WHERE role = 'CUSTOMER'";
      var command = new SQLiteCommand(commandText, _connection);
      var reader = command.ExecuteReader();
      foreach (DbDataRecord record in reader)
      {
        var year = record["year"]?.ToString();
        if (!string.IsNullOrEmpty(year))
        {
          resultList.Add( new QueryForGroup { QueryValue = year, GroupingType = GroupingType.Month });
        }
      }
      _connection.Close();
      return resultList;
    }

    public List<QueryForGroup> GetQueriesForGroupByRegion()
    {
      var resultList = new List<QueryForGroup>();
      _connection.Open();
      string commandText = @"
        SELECT DISTINCT role, country
        FROM user
        WHERE role = 'CUSTOMER'";
      var command = new SQLiteCommand(commandText, _connection);
      var reader = command.ExecuteReader();
      foreach (DbDataRecord record in reader)
      {
        var country = record["country"]?.ToString();
        if (!string.IsNullOrEmpty(country))
        {
          resultList.Add(new QueryForGroup {QueryValue = country, GroupingType = GroupingType.Region });
        }
      }
      _connection.Close();
      return resultList;
    }

    private readonly SQLiteConnection _connection;
  }

  internal class QueryForGroup
  {
    public string QueryValue { get; set; }

    public GroupingType GroupingType { get; set; }

    public override string ToString() => QueryValue;
  }

  internal class CountItemsInGroup
  {
    public int Count { get; set; }

    public string GroupItemValue { get; set; } 

    public GroupingType GroupingType { get; set; }
  }

  internal enum GroupingType
  {
    [Description("Country")]
    Country,

    [Description("Region")]
    Region,
  
    [Description("Month")]
    Month
  }
}