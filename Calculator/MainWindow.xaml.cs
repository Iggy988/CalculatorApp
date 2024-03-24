
using System.Windows;
using System.Windows.Controls;

namespace Calculator;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    double lastNumber, result;
    SelectedOperator selectedOperator;

    public MainWindow()
    {
        InitializeComponent();

        // u constructoru dodajemo eventHandlere za elemente samo kad ih nismo dodali u XAML kao Click="..."
        //acButton.Click += AcButton_Click;
        //minusButton.Click += MinusButton_Click;
        //percentButton.Click += PercentButton_Click;
        //equalsButton.Click += EqualsButton_Click;
    }

    private void EqualsButton_Click(object sender, RoutedEventArgs e)
    {
        double newNumber;

        if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
        {
            switch (selectedOperator) 
            {
                case SelectedOperator.Addition:
                    result = SimpleMath.Add(lastNumber, newNumber);
                    break;
                case SelectedOperator.Subtraction:
                    result = SimpleMath.Subtract(lastNumber, newNumber);
                    break;
                case SelectedOperator.Division:
                    result = SimpleMath.Divide(lastNumber, newNumber);
                    break;
                case SelectedOperator.Multiplication:
                    result = SimpleMath.Multiply(lastNumber, newNumber);
                    break;

            }

            resultLabel.Content = result.ToString(); 
        }
    }

    private void PercentButton_Click(object sender, RoutedEventArgs e)
    {
        //50 + 5% (2.5) = 52.5
        //80 + 10% (8) = 88
        double tempNumber; //5, 8
        if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
        {
            tempNumber = (tempNumber / 100); // 5/100; 8/100
            if (lastNumber != 0)
            {
                tempNumber *= lastNumber;   //0.05 * 50 = 2.5
            }
            resultLabel.Content = tempNumber.ToString();
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
        result = 0;
        lastNumber = 0;
    }


    private void OperationButton_Click(object sender, RoutedEventArgs e)
    {
        //kad user pritisne broj, pa operationEvent, broj ce biti snimljen u lastNumber, resultLabel ce biti 0, da user moze unijeti sledeci broj
        if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
        {
            resultLabel.Content = "0";
        }

        if (sender == multiplyButton)
            selectedOperator = SelectedOperator.Multiplication;
        if (sender == divideButton)
            selectedOperator = SelectedOperator.Division;
        if (sender == plusButton)
            selectedOperator = SelectedOperator.Addition;
        if (sender == minus_button)
            selectedOperator = SelectedOperator.Subtraction;
    }

    private void dotButton_Click(object sender, RoutedEventArgs e)
    {
        if (resultLabel.Content.ToString().Contains("."))
        { 
            //do nothing
        }
        else
        {
            resultLabel.Content = $"{resultLabel.Content}.";
        }
        
    }

    private void NumberButton_Click(object sender, RoutedEventArgs e)
    {
        int selectedValue = int.Parse((sender as Button).Content.ToString());
        /*
        if (sender == oneButton)
            selectedValue = 1; 
        if (sender == twoButton)
            selectedValue = 2;
        ...
        */
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


public enum SelectedOperator
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}

public class SimpleMath
{
    public static double Add(double n1, double n2)
    {
        return n1 + n2;
    }
    public static double Subtract(double n1, double n2)
    {
        return n1 - n2;
    }
    public static double Multiply(double n1, double n2)
    {
        return n1 * n2;
    }
    public static double Divide(double n1, double n2)
    {
        if (n2 == 0)
        {
            MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
            return 0;
        }
        return n1 / n2;
    }
}