using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Computer
{
    public partial class Form1 : Form
    {
        private TextBox inputNumberTextBox;

        private Button numberButton;
        private Button operatorButton;
        private Button equalsButton;

        private double number;
        private double number2 = 0;
        private double numberTrigger;
        private string operatorBefore;
        private string operatorAfter;
        private string operatorNumber;
        private bool deleteInputTextBox = false;
        private bool startInput = true;
        private bool confirmNumber = false;

        public Form1()
        {
            InitializeComponent();
            int startX = 20;
            int startY = 20;
            int GapX = 90;
            int GapY = 30;
            int LengthX = 75;
            int WidthY = 23;

            Size = new System.Drawing.Size(LengthX + GapX * 4, WidthY + GapY * 7); // 410,220
            inputNumberTextBox = new TextBox();
            inputNumberTextBox.Location = new Point(startX, startY);
            inputNumberTextBox.Size = new Size(LengthX + GapX * 2, WidthY + GapY);
            Controls.Add(inputNumberTextBox);

            // 0 ~ 9,"."
            for (int i = 0; i < 11; i++)
            {
                numberButton = new Button();
                numberButton.Text = i.ToString();
                if (i == 10)
                {
                    numberButton.Text = ".";
                }

                int column = i % 3;
                int row = i / 3;

                if (i == 0)
                {
                    numberButton.Location = new Point(startX + GapX, startY + GapY * 4);
                }
                else
                {
                    if (column == 0)
                    {
                        column += 3;
                        row -= 1;
                    }
                    numberButton.Location = new Point(startX + GapX * (column - 1), startY + GapY * (row + 1));
                }
                numberButton.Size = new Size(LengthX, WidthY);
                numberButton.Click += new EventHandler(numberButton_Click);
                Controls.Add(numberButton);
            }

            string[] operatorButtonText = new string[] { "C", "+", "-", "*", "/" };

            // C, +, -, *, /, =
            for (int j = 0; j < operatorButtonText.Count(); j++)
            {
                operatorButton = new Button();
                operatorButton.Text = operatorButtonText[j];
                operatorButton.Location = new Point(startX + GapX * 3, startY + GapY * j);
                operatorButton.Size = new Size(LengthX, WidthY);
                operatorButton.Click += new EventHandler(operatorButton_Click);
                Controls.Add(operatorButton);
            }
            equalsButton = new Button();
            equalsButton.Text = "=";
            equalsButton.Location = new Point(startX + GapX * 2, startY + GapY * 4);
            equalsButton.Size = new Size(LengthX, WidthY);
            equalsButton.Click += new EventHandler(equalsButton_Click);
            Controls.Add(equalsButton);
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            Button numberButton = (Button)sender;
            if (deleteInputTextBox)
            {
                inputNumberTextBox.Text = "";
                deleteInputTextBox = false;
            }
            inputNumberTextBox.Text += numberButton.Text;
            confirmNumber = true;
        }

        private void operatorFunction()
        {
            double calculateResult = 0;
            operatorNumber = operatorBefore;

            switch (operatorNumber)
            {
                case "+":
                    calculateResult = number + number2;
                    break;
                case "-":
                    calculateResult = number - number2;
                    break;
                case "*":
                    calculateResult = number * number2;
                    break;
                case "/":
                    calculateResult = number / number2;
                    break;
            }
            inputNumberTextBox.Text = calculateResult.ToString();
            number = calculateResult;
            numberTrigger = calculateResult;
            confirmNumber = false;
        }

        private void operatorButton_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "C")
            {
                inputNumberTextBox.Text = "0";
                startInput = true;
                confirmNumber = false;
                operatorBefore = null;
            }
            else if (!string.IsNullOrEmpty(inputNumberTextBox.Text) && startInput)
            {
                number = Convert.ToDouble(inputNumberTextBox.Text);
                operatorNumber = ((Button)sender).Text;
                operatorAfter = operatorNumber;
                numberTrigger = number;
                startInput = false;
                confirmNumber = false;
                operatorBefore = operatorBefore == null ? operatorNumber : operatorBefore;
            }
            else if (!string.IsNullOrEmpty(inputNumberTextBox.Text) && !startInput)
            {
                operatorNumber = ((Button)sender).Text;
                number2 = Convert.ToDouble(inputNumberTextBox.Text);
                operatorAfter = operatorNumber;

                // 數字不相同
                if (inputNumberTextBox.Text != numberTrigger.ToString() && confirmNumber)
                {
                    operatorFunction();
                }
                // 數字相同、符號相同
                else if (operatorBefore == operatorAfter && inputNumberTextBox.Text == numberTrigger.ToString() && confirmNumber)
                {
                    operatorFunction();
                }
                // 符號不相同
                else if (operatorBefore != operatorAfter && confirmNumber)
                {
                    operatorFunction();
                }
                operatorBefore = operatorAfter;
            }
            deleteInputTextBox = true;
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputNumberTextBox.Text) && confirmNumber)
            {
                number2 = Convert.ToDouble(inputNumberTextBox.Text);
                operatorFunction();
                startInput = true;
            }
        }
    }
}
