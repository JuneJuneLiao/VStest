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
        private bool deleteInputTextBox = false;
        
        public Form1()
        {
            InitializeComponent();
            // 開頭位置(i,j)
            int i = 20;
            int j = 20;

            // 運算式子(+、-、*、/) Button的x位置
            int m = 295;

            // Button size (l,w)
            int l = 265;
            int w = 23;
            Size = new System.Drawing.Size(410,220);
            inputNumberTextBox = new TextBox();
            inputNumberTextBox.Location = new Point(i, j);
            inputNumberTextBox.Size = new Size(l, w);
            Controls.Add(inputNumberTextBox);

            numberOneButton = new Button();
            numberOneButton.Location = new Point(i, j+30);
            numberOneButton.Size = new Size((l - 40) / 3, w);
            numberOneButton.Text = "1";
            numberOneButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberOneButton);

            numberTwoButton = new Button();
            numberTwoButton.Location = new Point(i + 95, j + 30);
            numberTwoButton.Size = new Size((l - 40) / 3, w);
            numberTwoButton.Text = "2";
            numberTwoButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberTwoButton);

            numberThreeButton = new Button();
            numberThreeButton.Location = new Point(i + 190, j + 30);
            numberThreeButton.Size = new Size((l - 40) / 3, w);
            numberThreeButton.Text = "3";
            numberThreeButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberThreeButton);

            numberFourButton = new Button();
            numberFourButton.Location = new Point(i, j + 60);
            numberFourButton.Size = new Size((l - 40) / 3, w);
            numberFourButton.Text = "4";
            numberFourButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberFourButton);

            numberFiveButton = new Button();
            numberFiveButton.Location = new Point(i + 95, j + 60);
            numberFiveButton.Size = new Size((l - 40) / 3, w);
            numberFiveButton.Text = "5";
            numberFiveButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberFiveButton);

            numberSixButton = new Button();
            numberSixButton.Location = new Point(i + 190, j + 60);
            numberSixButton.Size = new Size((l - 40) / 3, w);
            numberSixButton.Text = "6";
            numberSixButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberSixButton);

            numberSevenButton = new Button();
            numberSevenButton.Location = new Point(i, j + 90);
            numberSevenButton.Size = new Size((l - 40) / 3, w);
            numberSevenButton.Text = "7";
            numberSevenButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberSevenButton);

            numberEightButton = new Button();
            numberEightButton.Location = new Point(i + 95, j + 90);
            numberEightButton.Size = new Size((l - 40) / 3, w);
            numberEightButton.Text = "8";
            numberEightButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberEightButton);

            numberNineButton = new Button();
            numberNineButton.Location = new Point(i + 190, j + 90);
            numberNineButton.Size = new Size((l - 40) / 3, w);
            numberNineButton.Text = "9";
            numberNineButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberNineButton);

            numberZeroButton = new Button();
            numberZeroButton.Location = new Point(i + 95, j + 120);
            numberZeroButton.Size = new Size((l - 40) / 3, w);
            numberZeroButton.Text = "0";
            numberZeroButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberZeroButton);

            pointButton = new Button();
            pointButton.Location = new Point(i, j + 120);
            pointButton.Size = new Size((l - 40) / 3, w);
            pointButton.Text = ".";
            pointButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(pointButton);

            tureZeroButton = new Button();
            tureZeroButton.Location = new Point(m, j);
            tureZeroButton.Size = new Size((l - 40) / 3, w);
            tureZeroButton.Text = "C";
            tureZeroButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(tureZeroButton);

            addButton = new Button();
            addButton.Location = new Point(m, j + 30);
            addButton.Size = new Size((l - 40) / 3, w);
            addButton.Text = "+";
            addButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(addButton);

            subtractButton = new Button();
            subtractButton.Location = new Point(m, j + 60);
            subtractButton.Size = new Size((l - 40) / 3, w);
            subtractButton.Text = "-";
            subtractButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(subtractButton);

            multiplyButton = new Button();
            multiplyButton.Location = new Point(m, j + 90);
            multiplyButton.Size = new Size((l - 40) / 3, w);
            multiplyButton.Text = "*";
            multiplyButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(multiplyButton);

            dividedButton = new Button();
            dividedButton.Location = new Point(m, j + 120);
            dividedButton.Size = new Size((l - 40) / 3, w);
            dividedButton.Text = "/";
            dividedButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(dividedButton);

            equalsButton = new Button();
            equalsButton.Location = new Point(i + 190, j + 120);
            equalsButton.Size = new Size((l - 40) / 3, w);
            equalsButton.Text = "=";
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
                number = Convert.ToDouble(inputNumberTextBox.Text);
                if (((Button)sender).Text == "+")
                {
                    calculateNumber = 0;
                }
                else if (((Button)sender).Text == "-")
                {
                    calculateNumber = 1;
                }
                else if (((Button)sender).Text == "*")
                {
                    calculateNumber = 2;
                }
                else if (((Button)sender).Text == "/")
                {
                    calculateNumber = 3;
                }
                else if (((Button)sender).Text == "C")
                {
                    inputNumberTextBox.Text = "";
                }
                deleteInputTextBox = true;
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
                else if (calculateNumber == 1)
                {
                    calculateResult = number - Convert.ToDouble(inputNumberTextBox.Text);
                    inputNumberTextBox.Text = calculateResult.ToString();
                }
                else if (calculateNumber == 2)
                {
                    calculateResult = number * Convert.ToDouble(inputNumberTextBox.Text);
                    inputNumberTextBox.Text = calculateResult.ToString();
                }
                else if (calculateNumber == 3)
                {
                    calculateResult = number / Convert.ToDouble(inputNumberTextBox.Text);
                    inputNumberTextBox.Text = calculateResult.ToString();
                }
            }
        }
    }
}
