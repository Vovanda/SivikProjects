using Devart.Data.SQLite;
using Statistics.Context;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Statistics
{
  internal class AppViewModel : IDisposable
  {
    public AppViewModel(TestDbContext dbContext)
    {
      _dbContext = dbContext;
     
      var StatisticByCountries = new StatisticTabViewModel()
      {
        Statistic = new ObservableCollection<CountItemsInGroup>(dbContext.GetStatisticOfCountInGroup(new QueryForGroup {GroupingType = GroupingType.Country }))
      };
      var StatisticByRegions = new StatisticTabViewModel(dbContext.GetQueriesForGroupByRegion());
      var StatisticByMonths = new StatisticTabViewModel(dbContext.GetQueriesForGroupByMonth());

      StatisticTabs = new ObservableCollection<StatisticTabViewModel> { StatisticByCountries, StatisticByRegions, StatisticByMonths };

      foreach(var tab in StatisticTabs)
      {
        tab.PropertyChanged += StatisticByRegions_PropertyChanged;
      }
    }

    #region Dispose
    public void Dispose()
    {
      Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposed)
      {
        foreach (var tab in StatisticTabs)
        {
          tab.PropertyChanged -= StatisticByRegions_PropertyChanged;
        }
        disposed = false;
      }
    }
    private bool disposed;

    #endregion

    public ObservableCollection<StatisticTabViewModel> StatisticTabs { get; set; }

    private void StatisticByRegions_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (e.PropertyName == nameof(StatisticTabViewModel.SelectedQuery))
      {
        if (sender is StatisticTabViewModel statisticTab && statisticTab != null)
        {
          if (statisticTab.SelectedQuery != null)
          {
            statisticTab.Statistic = new ObservableCollection<CountItemsInGroup>(_dbContext.GetStatisticOfCountInGroup(statisticTab.SelectedQuery));
          }
        }
      }
    }

    private readonly TestDbContext _dbContext;
  }
}
