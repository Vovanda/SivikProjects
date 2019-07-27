using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Statistics.Data;

namespace Statistics
{
  using StatisticQuery = Func<string, IEnumerable<CountItemsInGroup>>;

  internal class StatisticOfRegistarionsViewModel : INotifyPropertyChanged
  {
    public StatisticOfRegistarionsViewModel(StatisticQuery statisticQuery) : this(statisticQuery, null)
    { }

    public StatisticOfRegistarionsViewModel(StatisticQuery statisticQuery, IEnumerable<string> queryItems)
    {
      _getStatistic = statisticQuery ?? throw new ArgumentNullException(nameof(statisticQuery));
      QueryItems = queryItems?.ToArray();
      SelectedQuery = QueryItemsIsExist ? QueryItems[0] : null;
    }

    public void OnPropertyChanged(string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    public event PropertyChangedEventHandler PropertyChanged;
    
    public string TabHeader { get; private set; }

    public bool QueryItemsIsExist => QueryItems != null && QueryItems.Length > 0;

    public string[] QueryItems { get; }

    public string SelectedQuery
    {
      get => _selectedQuery;
      set
      {
        if(_selectedQuery != value)
        {
          _selectedQuery = value;
          OnPropertyChanged(nameof(SelectedQuery));
          OnPropertyChanged(nameof(Statistic));
        }
      }
    }

    public ObservableCollection<CountItemsInGroup> Statistic => new ObservableCollection<CountItemsInGroup>(_getStatistic(SelectedQuery));

    private readonly StatisticQuery _getStatistic;

    private string _selectedQuery;
  }
}
