using System.Collections.ObjectModel;
using Statistics.Context;

namespace Statistics
{
  internal class AppViewModel
  {
    public AppViewModel(TestDbContext dbContext)
    {
      _dbContext = dbContext;

      StatisticByCountry = new StatisticOfRegistarionsViewModel((x) => dbContext.GetStatisticOfRistrationsByCountry()) { GroupColumnHeader = "Страна" };
      StatisticByRegion = new StatisticOfRegistarionsViewModel((country) => dbContext.GetStatisticOfRistrationsByRegion(country), dbContext.GetCountryList()) { GroupColumnHeader = "Регион" };
      StatisticByMonth = new StatisticOfRegistarionsViewModel((year) => dbContext.GetStatisticOfRistrationsByMonth(year), dbContext.GetYearList()) { GroupColumnHeader = "Месяц" };
    }

    public StatisticOfRegistarionsViewModel StatisticByCountry { get; }

    public StatisticOfRegistarionsViewModel StatisticByRegion{ get; }

    public StatisticOfRegistarionsViewModel StatisticByMonth { get; }


    private readonly TestDbContext _dbContext;

  }
}
