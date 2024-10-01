using System.Collections.ObjectModel;
using System.Windows;

namespace RGINPO_WPF;

public partial class MainWindow : Window
{
    private ObservableCollection<Data> dataSource =
    [
        new Data(0,0),
        new Data(1,0),
    ];

    public MainWindow()
    {
        InitializeComponent();

        dataGridView.ItemsSource = dataSource;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        dataSource.Add(new Data(0, 0));

    }
}