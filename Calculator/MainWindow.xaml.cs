
using System.Windows;

namespace Calculator;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        resultLabel.Content = "1234";
    }

    private void sevenButton_Click(object sender, RoutedEventArgs e)
    {
        if (resultLabel.Content.ToString() == "0")
        {
            resultLabel.Content = "7";
        }
        else
        {
            resultLabel.Content = $"{resultLabel.Content}7";
        }
    }
}