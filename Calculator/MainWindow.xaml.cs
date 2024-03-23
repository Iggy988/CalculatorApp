
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


    private void OperationButton_Click(object sender, RoutedEventArgs e)
    {
        //kad user pritisne broj, pa operationEvent, broj ce biti snimljen u lastNumber, resultLabel ce biti 0, da user moze unijeti sledeci broj
        if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
        {
            resultLabel.Content = "0";
        }
    }

    private void NumberButton_Click(object sender, RoutedEventArgs e)
    {
        int selectedValue = 0;

        if (sender == nullButton)
            selectedValue = 0;
        if (sender == oneButton)
            selectedValue = 1;
        if (sender == twoButton)
            selectedValue = 2;
        if (sender == threeButton)
            selectedValue = 3;
        if (sender == fourButton)
            selectedValue = 4;
        if (sender == fiveButton)
            selectedValue = 5;
        if (sender == sixButton)
            selectedValue = 6;
        if (sender == sevenButton)
            selectedValue = 7;
        if (sender == eightButton)
            selectedValue = 8;
        if (sender == nineButton)
            selectedValue = 9;

        if (resultLabel.Content.ToString() == "0")
        {
            resultLabel.Content = $"{selectedValue}";
        }
        else
        {
            resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
        }
    }
}