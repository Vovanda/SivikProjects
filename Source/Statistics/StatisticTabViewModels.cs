using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Statistics.Context;

namespace Statistics
{
  internal class StatisticTabViewModel : INotifyPropertyChanged
  {
    public StatisticTabViewModel() : this(null)
    { }

    public StatisticTabViewModel(IEnumerable<QueryForGroup> queryItems)
    {
      QueryItems = queryItems?.ToArray();
      SelectedQuery = (QueryItems != null && QueryItems.Length > 0) ? QueryItems[0] : null;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public QueryForGroup[] QueryItems { get; }

    public void OnPropertyChanged(string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    public ObservableCollection<CountItemsInGroup> Statistic { get; set; }

    public QueryForGroup SelectedQuery
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

    private QueryForGroup _selectedQuery;
  }
}
