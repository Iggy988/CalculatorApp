
using System.Windows;

namespace Calculator;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    double lastNumber, result;

    public MainWindow()
    {
        InitializeComponent();

        acButton.Click += AcButton_Click;
        minusButton.Click += MinusButton_Click;
        percentButton.Click += PercentButton_Click;
        equalsButton.Click += EqualsButton_Click;
    }

    private void EqualsButton_Click(object sender, RoutedEventArgs e)
    {
        
    }

    private void PercentButton_Click(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
        {
            lastNumber = lastNumber / 100;
            resultLabel.Content = lastNumber.ToString();
        }
    }

    private void MinusButton_Click(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
        {
            lastNumber = lastNumber * -1;
            resultLabel.Content = lastNumber.ToString();
        }
    }

    private void AcButton_Click(object sender, RoutedEventArgs e)
    {
        resultLabel.Content = "0";
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