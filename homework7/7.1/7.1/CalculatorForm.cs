namespace Task7_1;

public partial class CalculatorForm : Form
{
    public CalculatorForm()
    {
        InitializeComponent();
    }
    private Calculator calculator = new Calculator();
    private string input = string.Empty;
    private bool isOperationSelected = false;
    private bool needNewNumber = false;

    private void DigitButtonClick(object sender, EventArgs e)
    {
        textBox.Text += (sender as Button)?.Text;
        input += (sender as Button)?.Text;
    }

    private void OperationButtonClick(object sender, EventArgs e)
    {   
        if (input == "")
        {
            throw new InvalidOperationException();
        }
        if (isOperationSelected)
        {
            string[] signs = input.Split(' ');
            calculator.AddNumber(Convert.ToDouble(signs[0]));   
            calculator.AddOperation(Convert.ToChar(signs[1]));
            calculator.AddNumber(Convert.ToDouble(signs[2]));
            textBox.Text = "";
            input = "";
            input = calculator.Calculate().ToString();
            textBox.Text = input;
            calculator.Clear();
            isOperationSelected = false;
        }
        textBox.Text += ' ' + (sender as Button)?.Text + ' ';
        input += ' ' + (sender as Button)?.Text + ' ';
        isOperationSelected = true;
    }

    private void DoubleButtonClick(object sender, EventArgs e)
    {
        string[] signs = input.Split(' ');
        if (signs.Length == 1)
        {
            if (!signs[0].Contains(','))
            {
                textBox.Text += ',';
                input += ',';
            }
        }
        else if (signs.Length == 3)
        {
            if (!signs[2].Contains(','))
            {
                textBox.Text += ',';
                input += ',';
            }
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    private void ChangeSignButtonClick(object sender, EventArgs e)
    {
        string[] signs = input.Split(' ');
        if (signs.Length == 1)
        {
            if (!signs[0].Contains('-'))
            {
                input = input.Insert(0, "-");
                textBox.Text = input;
                return;
            }
            input = input.Remove(0, 1);
            textBox.Text = input;
        }
        else if (signs.Length == 3)
        {
            if (!signs[2].Contains('-'))
            {
                input = input.Insert(0, "-");
                textBox.Text = input;
                return;
            }
            input = input.Remove(0, 1);
            textBox.Text = input;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    private void DeleteButtonClick(object sender, EventArgs e)
    {
        string[] signs = input.Split(' ');
        if (signs.Length == 1)
        {
            
        }
        else if (signs.Length == 3)
        {
            
        }
    }
}
