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

        private Button tureZeroButton;
        private Button numberOneButton;
        private Button numberTwoButton;
        private Button numberThreeButton;
        private Button numberFourButton;
        private Button numberFiveButton;
        private Button numberSixButton;
        private Button numberSevenButton;
        private Button numberEightButton;
        private Button numberNineButton;
        private Button numberZeroButton;
        private Button pointButton;

        private Button addButton;
        private Button subtractButton;
        private Button multiplyButton;
        private Button dividedButton;
        private Button equalsButton;

        private double number = 0;
        private int calculateNumber;
        
        public Form1()
        {
            InitializeComponent();
            Size = new System.Drawing.Size(410,220);
            inputNumberTextBox = new TextBox();
            inputNumberTextBox.Location = new Point(10, 15);
            inputNumberTextBox.Size = new Size(260, 70);
            Controls.Add(inputNumberTextBox);

            numberOneButton = new Button();
            numberOneButton.Location = new Point(10, 50);
            numberOneButton.Text = "1";
            numberOneButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberOneButton);

            numberTwoButton = new Button();
            numberTwoButton.Location = new Point(110, 50);
            numberTwoButton.Text = "2";
            numberTwoButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberTwoButton);

            numberThreeButton = new Button();
            numberThreeButton.Location = new Point(210, 50);
            numberThreeButton.Text = "3";
            numberThreeButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberThreeButton);

            numberFourButton = new Button();
            numberFourButton.Location = new Point(10, 80);
            numberFourButton.Text = "4";
            numberFourButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberFourButton);

            numberFiveButton = new Button();
            numberFiveButton.Location = new Point(110, 80);
            numberFiveButton.Text = "5";
            numberFiveButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberFiveButton);

            numberSixButton = new Button();
            numberSixButton.Location = new Point(210, 80);
            numberSixButton.Text = "6";
            numberSixButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberSixButton);

            numberSevenButton = new Button();
            numberSevenButton.Location = new Point(10, 110);
            numberSevenButton.Text = "7";
            numberSevenButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberSevenButton);

            numberEightButton = new Button();
            numberEightButton.Location = new Point(110, 110);
            numberEightButton.Text = "8";
            numberEightButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberEightButton);

            numberNineButton = new Button();
            numberNineButton.Location = new Point(210, 110);
            numberNineButton.Text = "9";
            numberNineButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberNineButton);

            numberZeroButton = new Button();
            numberZeroButton.Location = new Point(110, 140);
            numberZeroButton.Text = "0";
            numberZeroButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberZeroButton);

            pointButton = new Button();
            pointButton.Location = new Point(10, 140);
            pointButton.Text = ".";
            pointButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(pointButton);

            tureZeroButton = new Button();
            tureZeroButton.Location = new Point(295, 10);
            tureZeroButton.Size = new Size(90, 30);
            tureZeroButton.Text = "C";
            tureZeroButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(tureZeroButton);

            addButton = new Button();
            addButton.Location = new Point(310, 50);
            addButton.Text = "+";
            addButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(addButton);

            subtractButton = new Button();
            subtractButton.Location = new Point(310, 80);
            subtractButton.Text = "-";
            subtractButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(subtractButton);

            multiplyButton = new Button();
            multiplyButton.Location = new Point(310, 110);
            multiplyButton.Text = "*";
            multiplyButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(multiplyButton);

            dividedButton = new Button();
            dividedButton.Location = new Point(310, 140);
            dividedButton.Text = "/";
            dividedButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(dividedButton);

            equalsButton = new Button();
            equalsButton.Location = new Point(210, 140);
            equalsButton.Text = "=";
            equalsButton.Click += new EventHandler(equalsButton_Click);
            Controls.Add(equalsButton);
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            Button numberButton = (Button)sender;
            inputNumberTextBox.Text += numberButton.Text;
        }

        private void operatorButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputNumberTextBox.Text))
            {
                number = Convert.ToDouble(inputNumberTextBox.Text);
                inputNumberTextBox.Text = "";
                if (((Button)sender).Name == "+")
                {
                    calculateNumber = 0;
                }
                else if (((Button)sender).Name == "-")
                {
                    calculateNumber = 1;
                }
                else if (((Button)sender).Name == "*")
                {
                    calculateNumber = 2; ;
                }
                else if (((Button)sender).Name == "/")
                {
                    calculateNumber = 3;
                }
                else if (((Button)sender).Name == "C")
                {
                    inputNumberTextBox.Text = "";
                }
            }
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(inputNumberTextBox.Text))
            {
                double calculateResult;
                if (calculateNumber == 0)
                {
                    calculateResult = number + Convert.ToDouble(inputNumberTextBox.Text);
                    inputNumberTextBox.Text = calculateResult.ToString();
                }
                if (calculateNumber == 1)
                {
                    calculateResult = number - Convert.ToDouble(inputNumberTextBox.Text);
                    inputNumberTextBox.Text = calculateResult.ToString();
                }
                if (calculateNumber == 2)
                {
                    calculateResult = number * Convert.ToDouble(inputNumberTextBox.Text);
                    inputNumberTextBox.Text = calculateResult.ToString();
                }
                if (calculateNumber == 3)
                {
                    calculateResult = number / Convert.ToDouble(inputNumberTextBox.Text);
                    inputNumberTextBox.Text = calculateResult.ToString();
                }
            }
        }
    }
}
