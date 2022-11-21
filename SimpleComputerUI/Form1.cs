using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Corex.UI;

namespace SimpleComputerUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Size = new Size(640, 220);
            genUI();
        }

        private CxTextBox InputNumberTextBox;

        private CxButton numberButton;
        private CxButton operatorButton;
        private CxButton equalsButton;

        private double number;
        private double number2 = 0;
        private double numberTrigger;
        private string operatorBefore;
        private string operatorAfter;
        private string operatorNumber;
        private bool deleteInputTextBox = false;
        private bool startInput = true;
        private bool confirmNumber = false;

        private void genUI()
        {
            LayoutControl lc = LayoutControl.NewV(23, 23, 23, 23);
            lc.Dock = DockStyle.Fill;
            lc.Gap = 90;
            lc.Padding = new Padding(5);
            Controls.Add(lc);

            // Textbox and C Button
            var row = lc.AddControl(LayoutControl.NewH(-3, -1));
            row.Gap = 30;

            InputNumberTextBox = row.AddControl(CxTextBox.New(""));
            operatorButton = row.AddControl(CxButton.New("C"));

            // 1 ~ 3 and + Button
            row = lc.AddControl(LayoutControl.NewH(-1, -1, -1, -1));
            row.Gap = 30;
            numberButton = row.AddControl(CxButton.New("1"));
            numberButton = row.AddControl(CxButton.New("2"));
            numberButton = row.AddControl(CxButton.New("3"));
            operatorButton = row.AddControl(CxButton.New("+"));

            // 4 ~ 6 and - Button
            row = lc.AddControl(LayoutControl.NewH(-1, -1, -1, -1));
            row.Gap = 30;
            numberButton = row.AddControl(CxButton.New("4"));
            numberButton = row.AddControl(CxButton.New("5"));
            numberButton = row.AddControl(CxButton.New("6"));
            operatorButton = row.AddControl(CxButton.New("-"));

            // 7 ~ 9 and * Button
            row = lc.AddControl(LayoutControl.NewH(-1, -1, -1, -1));
            row.Gap = 30;
            numberButton = row.AddControl(CxButton.New("7"));
            numberButton = row.AddControl(CxButton.New("8"));
            numberButton = row.AddControl(CxButton.New("9"));
            operatorButton = row.AddControl(CxButton.New("*"));

            // . 0 = and / Button
            row = lc.AddControl(LayoutControl.NewH(-1, -1, -1, -1));
            row.Gap = 30;
            numberButton = row.AddControl(CxButton.New("."));
            numberButton = row.AddControl(CxButton.New("0"));
            equalsButton = row.AddControl(CxButton.New("="));
            operatorButton = row.AddControl(CxButton.New("/"));

            lc.Render();
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            Button numberButton = (Button)sender;
            if (deleteInputTextBox)
            {
                InputNumberTextBox.Text = "";
                deleteInputTextBox = false;
            }
            InputNumberTextBox.Text += numberButton.Text;
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

            InputNumberTextBox.Text = calculateResult.ToString();
            number = calculateResult;
            numberTrigger = calculateResult;
            confirmNumber = false;
        }

        private void operatorButton_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "C")
            {
                InputNumberTextBox.Text = "0";
                startInput = true;
                confirmNumber = false;
                operatorBefore = null;
            }
            else if (startInput && !string.IsNullOrEmpty(InputNumberTextBox.Text))
            {
                number = Convert.ToDouble(InputNumberTextBox.Text);
                operatorNumber = ((Button)sender).Text;
                operatorAfter = operatorNumber;
                numberTrigger = number;
                startInput = false;
                confirmNumber = false;
                operatorBefore = operatorBefore == null ? operatorNumber : operatorBefore;
            }
            else if (!startInput && !string.IsNullOrEmpty(InputNumberTextBox.Text))
            {
                operatorNumber = ((Button)sender).Text;
                number2 = Convert.ToDouble(InputNumberTextBox.Text);
                operatorAfter = operatorNumber;

                if (confirmNumber)
                {
                    operatorFunction();
                }

                operatorBefore = operatorAfter;
            }
            deleteInputTextBox = true;
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InputNumberTextBox.Text) && confirmNumber)
            {
                number2 = Convert.ToDouble(InputNumberTextBox.Text);
                operatorFunction();
                startInput = true;
                deleteInputTextBox = true;
            }
        }
    }
}
