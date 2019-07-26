using System.Windows;

namespace Statistics
{
  /// <summary>
  /// Логика взаимодействия для MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      DataContext = new AppViewModel(new Context.TestDbContext());
    }

  }
}
