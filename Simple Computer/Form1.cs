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

        double number = 0;
        int calculateNumber;
        
        public Form1()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(410,220);
            this.inputNumberTextBox = new TextBox();
            this.inputNumberTextBox.Location = new Point(10, 15);
            this.inputNumberTextBox.Size = new Size(260, 70);
            this.Controls.Add(inputNumberTextBox);

            this.tureZeroButton = new Button();
            this.tureZeroButton.Location = new Point(295, 10);
            this.tureZeroButton.Size = new Size(90, 30);
            this.tureZeroButton.Text = "C";
            this.tureZeroButton.Click += new EventHandler(this.tureZeroButton_Click);
            this.Controls.Add(tureZeroButton);

            this.numberOneButton = new Button();
            this.numberOneButton.Location = new Point(10, 50);
            this.numberOneButton.Text = "1";
            this.numberOneButton.Click += new EventHandler(this.numberOneButton_Click);
            this.Controls.Add(numberOneButton);

            this.numberTwoButton = new Button();
            this.numberTwoButton.Location = new Point(110, 50);
            this.numberTwoButton.Text = "2";
            this.numberTwoButton.Click += new EventHandler(this.numberTwoButton_Click);
            this.Controls.Add(numberTwoButton);

            this.numberThreeButton = new Button();
            this.numberThreeButton.Location = new Point(210, 50);
            this.numberThreeButton.Text = "3";
            this.numberThreeButton.Click += new EventHandler(this.numberThreeButton_Click);
            this.Controls.Add(numberThreeButton);

            this.numberFourButton = new Button();
            this.numberFourButton.Location = new Point(10, 80);
            this.numberFourButton.Text = "4";
            this.numberFourButton.Click += new EventHandler(this.numberFourButton_Click);
            this.Controls.Add(numberFourButton);

            this.numberFiveButton = new Button();
            this.numberFiveButton.Location = new Point(110, 80);
            this.numberFiveButton.Text = "5";
            this.numberFiveButton.Click += new EventHandler(this.numberFiveButton_Click);
            this.Controls.Add(numberFiveButton);

            this.numberSixButton = new Button();
            this.numberSixButton.Location = new Point(210, 80);
            this.numberSixButton.Text = "6";
            this.numberSixButton.Click += new EventHandler(this.numberSixButton_Click);
            this.Controls.Add(numberSixButton);

            this.numberSevenButton = new Button();
            this.numberSevenButton.Location = new Point(10, 110);
            this.numberSevenButton.Text = "7";
            this.numberSevenButton.Click += new EventHandler(this.numberSevenButton_Click);
            this.Controls.Add(numberSevenButton);

            this.numberEightButton = new Button();
            this.numberEightButton.Location = new Point(110, 110);
            this.numberEightButton.Text = "8";
            this.numberEightButton.Click += new EventHandler(this.numberEightButton_Click);
            this.Controls.Add(numberEightButton);

            this.numberNineButton = new Button();
            this.numberNineButton.Location = new Point(210, 110);
            this.numberNineButton.Text = "9";
            this.numberNineButton.Click += new EventHandler(this.numberNineButton_Click);
            this.Controls.Add(numberNineButton);

            this.numberZeroButton = new Button();
            this.numberZeroButton.Location = new Point(110, 140);
            this.numberZeroButton.Text = "0";
            this.numberZeroButton.Click += new EventHandler(this.numberZeroButton_Click);
            this.Controls.Add(numberZeroButton);

            this.pointButton = new Button();
            this.pointButton.Location = new Point(10, 140);
            this.pointButton.Text = ".";
            this.pointButton.Click += new EventHandler(this.pointButton_Click);
            this.Controls.Add(pointButton);

            this.addButton = new Button();
            this.addButton.Location = new Point(310, 50);
            this.addButton.Text = "+";
            this.addButton.Click += new EventHandler(this.addButton_Click);
            this.Controls.Add(addButton);

            this.subtractButton = new Button();
            this.subtractButton.Location = new Point(310, 80);
            this.subtractButton.Text = "-";
            this.subtractButton.Click += new EventHandler(this.subtractButton_Click);
            this.Controls.Add(subtractButton);

            this.multiplyButton = new Button();
            this.multiplyButton.Location = new Point(310, 110);
            this.multiplyButton.Text = "*";
            this.multiplyButton.Click += new EventHandler(this.multiplyButton_Click);
            this.Controls.Add(multiplyButton);

            this.dividedButton = new Button();
            this.dividedButton.Location = new Point(310, 140);
            this.dividedButton.Text = "/";
            this.dividedButton.Click += new EventHandler(this.dividedButton_Click);
            this.Controls.Add(dividedButton);

            this.equalsButton = new Button();
            this.equalsButton.Location = new Point(210, 140);
            this.equalsButton.Text = "=";
            this.equalsButton.Click += new EventHandler(this.equalsButton_Click);
            this.Controls.Add(equalsButton);
        }

        private void numberOneButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += "1";
        }

        private void numberTwoButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += "2";
        }

        private void numberThreeButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += "3";
        }

        private void numberFourButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += "4";
        }

        private void numberFiveButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += "5";
        }

        private void numberSixButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += "6";
        }

        private void numberSevenButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += "7";
        }

        private void numberEightButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += "8";
        }

        private void numberNineButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += "9";
        }

        private void numberZeroButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += "0";
        }

        private void tureZeroButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text = "";
        }

        private void pointButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += ".";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            number = Convert.ToDouble(inputNumberTextBox.Text);  
            inputNumberTextBox.Text = "";
            calculateNumber = 0;
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            number = Convert.ToDouble(inputNumberTextBox.Text);
            inputNumberTextBox.Text = "";
            calculateNumber = 1;
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            number = Convert.ToDouble(inputNumberTextBox.Text);
            inputNumberTextBox.Text = "";
            calculateNumber = 2;
        }

        private void dividedButton_Click(object sender, EventArgs e)
        {
            number = Convert.ToDouble(inputNumberTextBox.Text);
            inputNumberTextBox.Text = "";
            calculateNumber = 3;
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            double calculateResult;
            if (calculateNumber == 0)
            {
                calculateResult = number + Convert.ToDouble(inputNumberTextBox.Text);
                inputNumberTextBox.Text = calculateResult.ToString();
            }
            if(calculateNumber == 1)
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
