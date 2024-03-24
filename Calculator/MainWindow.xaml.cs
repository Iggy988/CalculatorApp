
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

        acButton.Click += AcButton_Click;
        //minusButton.Click += MinusButton_Click;
        percentButton.Click += PercentButton_Click;
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
        return n1 / n2;
    }
}