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

        private double number = 0;
        private string operatorNumber;
        private bool deleteInputTextBox = false;

        public Form1()
        {
            InitializeComponent();
            int startX = 20;
            int startY = 20;
            int GapX = 90;
            int GapY = 30;
            int LengthX = 75;
            int WidthY = 23;

            Size = new System.Drawing.Size(LengthX + GapX * 4, WidthY + GapY*7); //410,220
            inputNumberTextBox = new TextBox();
            inputNumberTextBox.Location = new Point(startX, startY);
            inputNumberTextBox.Size = new Size(LengthX + GapX*2, WidthY + GapY);
            Controls.Add(inputNumberTextBox);

            for (int i = 0; i < 11; i++) // 0 ~ 9,"."
            {
                numberButton = new Button();
                numberButton.Text = i.ToString();

                if (i == 0)
                {
                    numberButton.Location = new Point(startX + GapX, startY + GapY * 4);
                }
                else if (i == 1)
                {
                    numberButton.Location = new Point(startX, startY + GapY );
                }
                else if (i == 2)
                {
                    numberButton.Location = new Point(startX + GapX, startY + GapY);
                }
                else if (i == 3)
                {
                    numberButton.Location = new Point(startX + GapX * 2, startY + GapY);
                }
                else if (i == 4)
                {
                    numberButton.Location = new Point(startX, startY + GapY * 2);
                }
                else if (i == 5)
                {
                    numberButton.Location = new Point(startX + GapX, startY + GapY * 2);
                }
                else if (i == 6)
                {
                    numberButton.Location = new Point(startX + GapX * 2, startY + GapY * 2);
                }
                else if (i == 7)
                {
                    numberButton.Location = new Point(startX, startY + GapY * 3);
                }
                else if (i == 8)
                {
                    numberButton.Location = new Point(startX + GapX, startY + GapY * 3);
                }
                else if (i == 9)
                {
                    numberButton.Location = new Point(startX + GapX * 2, startY + GapY * 3);
                }
                else if (i == 10)
                {
                    numberButton.Text = ".";
                    numberButton.Location = new Point(startX, startY + GapY * 4);                   
                }
                numberButton.Size = new Size(LengthX, WidthY);
                numberButton.Click += new EventHandler(numberButton_Click);
                Controls.Add(numberButton);
            }

            for (int j = 0; j < 5; j++) // C + - * / =
            {
                operatorButton = new Button();
                if (j == 0)
                {
                    operatorButton.Text = "C";
                }
                else if (j == 1)
                {
                    operatorButton.Text = "+";
                }
                else if (j == 2)
                {
                    operatorButton.Text = "-";
                }
                else if (j == 3)
                {
                    operatorButton.Text = "*";
                }
                else if (j == 4)
                {
                    operatorButton.Text = "/";
                }
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
        }

        private void operatorButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputNumberTextBox.Text))
            {
                double operatorResult = 0;
                number = Convert.ToDouble(inputNumberTextBox.Text);
                operatorNumber = ((Button)sender).Text;
                if (((Button)sender).Text == "C")
                {
                    inputNumberTextBox.Text = "0";
                }
                if (((Button)sender).Text == "+")
                {
                    operatorResult = number + Convert.ToDouble(inputNumberTextBox.Text);
                    inputNumberTextBox.Text = operatorResult.ToString();
                }
                deleteInputTextBox = true;
            }
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputNumberTextBox.Text))
            {  
                double calculateResult = 0;
                switch(operatorNumber)
                {
                    case "+":
                        calculateResult = number + Convert.ToDouble(inputNumberTextBox.Text);
                        break;
                    case "-":
                        calculateResult = number - Convert.ToDouble(inputNumberTextBox.Text);
                        break;
                    case "*":
                        calculateResult = number * Convert.ToDouble(inputNumberTextBox.Text);
                        break;
                    case "/":
                        calculateResult = number / Convert.ToDouble(inputNumberTextBox.Text);
                        break;
                }
                inputNumberTextBox.Text = calculateResult.ToString();
                number = calculateResult;
            }
        }
    }
}
