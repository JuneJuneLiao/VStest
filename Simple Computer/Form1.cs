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
        public TextBox inputNumberTextBox;

        public Button numberOneButton;
        public Button numberTwoButton;
        public Button numberThreeButton;
        public Button numberFourButton;
        public Button numberFiveButton;
        public Button numberSixButton;
        public Button numberSevenButton;
        public Button numberEightButton;
        public Button numberNineButton;
        public Button numberZeroButton;
        public Button pointButton;

        public Button addButton;
        public Button subtractButton;
        public Button multiplyButton;
        public Button dividedButton;
        public Button equalsButton;

        double num = 0;

        public Form1()
        {
            InitializeComponent();
            this.inputNumberTextBox = new TextBox();
            this.inputNumberTextBox.Location = new Point(100, 10);
            this.Controls.Add(inputNumberTextBox);

            this.numberOneButton = new Button();
            this.numberOneButton.Location = new Point(100, 40);
            this.numberOneButton.Text = "1";
            this.numberOneButton.Click += new EventHandler(this.numberOneButton_Click);
            this.Controls.Add(numberOneButton);

            this.numberTwoButton = new Button();
            this.numberTwoButton.Location = new Point(200, 40);
            this.numberTwoButton.Text = "2";
            this.numberTwoButton.Click += new EventHandler(this.numberTwoButton_Click);
            this.Controls.Add(numberTwoButton);

            this.numberThreeButton = new Button();
            this.numberThreeButton.Location = new Point(300, 40);
            this.numberThreeButton.Text = "3";
            this.numberThreeButton.Click += new EventHandler(this.numberThreeButton_Click);
            this.Controls.Add(numberThreeButton);

            this.numberFourButton = new Button();
            this.numberFourButton.Location = new Point(100, 80);
            this.numberFourButton.Text = "4";
            this.numberFourButton.Click += new EventHandler(this.numberFourButton_Click);
            this.Controls.Add(numberFourButton);

            this.numberFiveButton = new Button();
            this.numberFiveButton.Location = new Point(200, 80);
            this.numberFiveButton.Text = "5";
            this.numberFiveButton.Click += new EventHandler(this.numberFiveButton_Click);
            this.Controls.Add(numberFiveButton);

            this.numberSixButton = new Button();
            this.numberSixButton.Location = new Point(300, 80);
            this.numberSixButton.Text = "6";
            this.numberSixButton.Click += new EventHandler(this.numberSixButton_Click);
            this.Controls.Add(numberSixButton);

            this.numberSevenButton = new Button();
            this.numberSevenButton.Location = new Point(100, 120);
            this.numberSevenButton.Text = "7";
            this.numberSevenButton.Click += new EventHandler(this.numberSevenButton_Click);
            this.Controls.Add(numberSevenButton);

            this.numberEightButton = new Button();
            this.numberEightButton.Location = new Point(200, 120);
            this.numberEightButton.Text = "8";
            this.numberEightButton.Click += new EventHandler(this.numberEightButton_Click);
            this.Controls.Add(numberEightButton);

            this.numberNineButton = new Button();
            this.numberNineButton.Location = new Point(300, 120);
            this.numberNineButton.Text = "9";
            this.numberNineButton.Click += new EventHandler(this.numberNineButton_Click);
            this.Controls.Add(numberNineButton);

            this.numberZeroButton = new Button();
            this.numberZeroButton.Location = new Point(200, 160);
            this.numberZeroButton.Text = "0";
            this.numberNineButton.Click += new EventHandler(this.numberZeroButton_Click);
            this.Controls.Add(numberZeroButton);

            this.pointButton = new Button();
            this.pointButton.Location = new Point(100, 160);
            this.pointButton.Text = ".";
            this.pointButton.Click += new EventHandler(this.pointButton_Click);
            this.Controls.Add(pointButton);

            this.addButton = new Button();
            this.addButton.Location = new Point(400, 40);
            this.addButton.Text = "+";
            this.addButton.Click += new EventHandler(this.addButton_Click);
            this.Controls.Add(addButton);

            this.subtractButton = new Button();
            this.subtractButton.Location = new Point(400, 80);
            this.subtractButton.Text = "-";
            this.subtractButton.Click += new EventHandler(this.subtractButton_Click);
            this.Controls.Add(subtractButton);

            this.multiplyButton = new Button();
            this.multiplyButton.Location = new Point(400, 120);
            this.multiplyButton.Text = "*";
            this.multiplyButton.Click += new EventHandler(this.multiplyButton_Click);
            this.Controls.Add(multiplyButton);

            this.dividedButton = new Button();
            this.dividedButton.Location = new Point(400, 160);
            this.dividedButton.Text = "/";
            this.dividedButton.Click += new EventHandler(this.dividedButton_Click);
            this.Controls.Add(dividedButton);

            this.equalsButton = new Button();
            this.equalsButton.Location = new Point(300, 160);
            this.equalsButton.Text = "=";
            this.equalsButton.Click += new EventHandler(this.equalsButton_Click);
            this.Controls.Add(equalsButton);
        }

        private void numberOneButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += 1;
        }

        private void numberTwoButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += 2;
        }

        private void numberThreeButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += 3;
        }

        private void numberFourButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += 4;
        }

        private void numberFiveButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += 5;
        }

        private void numberSixButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += 6;
        }

        private void numberSevenButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += 7;
        }

        private void numberEightButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += 8;
        }

        private void numberNineButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += 9;
        }

        private void numberZeroButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += 0;
        }

        private void pointButton_Click(object sender, EventArgs e)
        {
            inputNumberTextBox.Text += ".";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            num = Convert.ToDouble(inputNumberTextBox.Text);  
            inputNumberTextBox.Text = "";
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            num = Convert.ToDouble(inputNumberTextBox.Text);
            inputNumberTextBox.Text = "";
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            num = Convert.ToDouble(inputNumberTextBox.Text);
            inputNumberTextBox.Text = "";
        }

        private void dividedButton_Click(object sender, EventArgs e)
        {
            num = Convert.ToDouble(inputNumberTextBox.Text);
            inputNumberTextBox.Text = "";
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            num = Convert.ToDouble(inputNumberTextBox.Text);
            inputNumberTextBox.Text = "";
        }
    }
}
