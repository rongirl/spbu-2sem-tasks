namespace Task7_1;

public partial class CalculatorForm : Form
{
    public CalculatorForm()
    {
        InitializeComponent();
    }

    private Calculator calculator = new();
    private string input = string.Empty;
    private bool isOperationSelected = false;

    /// <summary>
    /// Обрабатывает нажатие на кнопку с цифрой
    /// </summary>
    private void DigitButtonClick(object sender, EventArgs e)
    {
        textBox.Text += (sender as Button)?.Text;
        input += (sender as Button)?.Text;
    }

    /// <summary>
    /// Обрабатывает нажатие на кнопку с операцией
    /// </summary>
    private void OperationButtonClick(object sender, EventArgs e)
    {   
        if (input == "")
        {
            return;
        }
        if (isOperationSelected)
        {
            string[] signs = input.Split(' ');
            calculator.AddNumber(Convert.ToDouble(signs[0]));   
            calculator.AddOperation(Convert.ToChar(signs[1]));
            calculator.AddNumber(Convert.ToDouble(signs[2]));
            textBox.Text = "";
            input = calculator.Calculate().ToString()!;
            textBox.Text = input;
            calculator.Clear();
            isOperationSelected = false;
        }
        textBox.Text += ' ' + (sender as Button)?.Text + ' ';
        input += ' ' + (sender as Button)?.Text + ' ';
        isOperationSelected = true;
    }

    /// <summary>
    /// Обрабатывает нажатие на кнопку с запятой
    /// </summary>
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
    }

    /// <summary>
    /// Обрабатывает нажатие на кнопку изменения знака
    /// </summary>
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
        else if (signs.Length == 3 && signs[2] != "")
        {
            if (!signs[2].Contains('-'))
            {
                input = input.Insert(signs[0].Length + signs[1].Length + 2, "-");
                textBox.Text = input;
                return;
            }
            input = input.Remove(signs[0].Length + signs[1].Length + 2, 1);
            textBox.Text = input;
        }
    }

    /// <summary>
    /// Обрабатывает нажатие на кнопку удаления
    /// </summary>
    private void DeleteButtonClick(object sender, EventArgs e)
    {   
        if (input == "")
        {
            return;
        }
        string[] signs = input.Split(' ');
        if (signs.Length == 1 && signs[0].Length == 2 && signs[0][0] == '-')
        {
            input = input.Remove(0, 2);
            textBox.Text = input;
        }
        else if (signs.Length == 3 && signs[2].Length == 2 && signs[2][0] == '-')
        {
            input = input.Remove(signs[0].Length + signs[1].Length + 2, 2);
            textBox.Text = input;
        }
        else
        {
            input = input.Remove(input.Length - 1, 1);
            textBox.Text = input;
        }
    }

    /// <summary>
    /// Обрабатывает нажатие на кнопку удаления строки
    /// </summary>
    private void ClearAllButtonClick(object sender, EventArgs e)
    {
        input = "";
        textBox.Text = input;
        calculator.Clear();
        isOperationSelected = false;
    }

    /// <summary>
    /// Обрабатывает нажатие на кнопку удаления числа
    /// </summary>
    private void ClearButtonClick(object sender, EventArgs e)
    {
        string[] signs = input.Split(' ');
        if (signs.Length == 1)
        {
            input = input.Remove(0, signs[0].Length);
            textBox.Text = input;
        }
        else if (signs.Length == 3)
        {
            input = input.Remove(signs[0].Length + signs[1].Length + 2, signs[2].Length);
            textBox.Text = input;
        }
    }

    /// <summary>
    /// Обрабатывает нажатие на кнопку со знаком равно
    /// </summary>
    private void EqualButtonClick(object sender, EventArgs e)
    {
        if (isOperationSelected)
        {
            string[] signs = input.Split(' ');
            calculator.AddNumber(Convert.ToDouble(signs[0]));
            calculator.AddOperation(Convert.ToChar(signs[1]));
            calculator.AddNumber(Convert.ToDouble(signs[2]));
            textBox.Text = "";
            input = "";
            input = calculator.Calculate().ToString()!;
            textBox.Text = input;
            calculator.Clear();
            isOperationSelected = false;
        }
    }
}