using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using Microsoft.Win32;

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

    private void Load_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new()
        {
            Multiselect = false,
        };

        if (openFileDialog.ShowDialog() != true)
        {
            return;
        }

        foreach (string fullFileName in openFileDialog.FileNames)
        {
            var fileContent = ReadFileContent(fullFileName);
            AddFileContentToDataGridView1(fileContent);
        }
    }

    private void Save_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveFileDialog1 = new()
        {
            Filter = @"txt files (*.txt)|*.txt",
            FilterIndex = 2,
            RestoreDirectory = true
        };

        if (saveFileDialog1.ShowDialog() != true)
        {
            return;
        }

        using var file = new StreamWriter(saveFileDialog1.FileName);
        foreach (var point in dataSource)
        {
            file.Write(point.X + " " + point.Y);
            file.WriteLine("");
        }

        MessageBox.Show(@"File saved", @"Save successful", MessageBoxButton.OK);
    }

    private List<string> ReadFileContent(string filePath)
    {
        var fileContent = new List<string>();
        if (!File.Exists(filePath))
        {
            return fileContent;
        }

        using var reader = new StreamReader(filePath);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line != null)
            {
                fileContent.Add(line);
            }
        }

        return fileContent;
    }

    private void AddFileContentToDataGridView1(IReadOnlyList<string> fileContent)
    {
        dataSource.Clear();

        foreach (var values in fileContent.Select(line => line.Split(' ')))
        {
            var x = double.Parse(values[0]);
            var y = double.Parse(values[1]);

            dataSource.Add(new Data(x, y));
        }
    }
}