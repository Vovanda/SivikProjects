using System.Collections.ObjectModel;
using Statistics.Context;

namespace Statistics
{
  internal class AppViewModel
  {
    public AppViewModel(TestDbContext dbContext)
    {
      _dbContext = dbContext;

      var statisticByCountries = new StatisticOfRegistarionsViewModel((x) => dbContext.GetStatisticOfRistrationsByCountry());
      var statisticByMonths = new StatisticOfRegistarionsViewModel((year) => dbContext.GetStatisticOfRistrationsByMonth(year), dbContext.GetYearList());
      var statisticByRegions = new StatisticOfRegistarionsViewModel((country) => dbContext.GetStatisticOfRistrationsByRegion(country), dbContext.GetCountryList());
     
      StatisticTabs = new ObservableCollection<StatisticOfRegistarionsViewModel> { statisticByCountries, statisticByRegions, statisticByMonths };

      SelectedTab = statisticByCountries;
    }

    public StatisticOfRegistarionsViewModel SelectedTab { get; set; }
    public ObservableCollection<StatisticOfRegistarionsViewModel> StatisticTabs { get; set; }

    private readonly TestDbContext _dbContext;
  }
}
