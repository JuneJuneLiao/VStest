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
        private TextBox inputNumberTextBox;

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

            Size = new Size(480, 220);
            genUI();
        }

        private void genUI()
        {
            CxButton numberButton;
            CxButton operatorButton;
            CxButton equalsButton;

            LayoutControl lc = LayoutControl.NewH(-3, -1);
            lc.Dock = DockStyle.Fill;
            lc.Gap = 10;
            lc.Padding = new Padding(5);
            Controls.Add(lc);

            var column = lc.AddControl(LayoutControl.NewV(-1, -1, -1, -1, -1));

            inputNumberTextBox = column.AddControl(new TextBox());
            column.Gap = 10;

            var row = column.AddControl(LayoutControl.NewH(-1, -1, -1));
            row.Gap = 10;
            string[] oneToThreeNumberButtonTexts = new string[] { "1", "2", "3" };
            for (int i = 0; i < oneToThreeNumberButtonTexts.Count(); i++)
            {
                numberButton = row.AddControl(CxButton.New(oneToThreeNumberButtonTexts[i]));
                numberButton.Click += new EventHandler(numberButton_Click);
            }

            row = column.AddControl(LayoutControl.NewH(-1, -1, -1));
            row.Gap = 10;
            string[] fourToSixNumberButtonTexts = new string[] { "4", "5", "6" };
            for (int i = 0; i < fourToSixNumberButtonTexts.Count(); i++)
            {
                numberButton = row.AddControl(CxButton.New(fourToSixNumberButtonTexts[i]));
                numberButton.Click += new EventHandler(numberButton_Click);
            }

            row = column.AddControl(LayoutControl.NewH(-1, -1, -1));
            row.Gap = 10;
            string[] sevenToNineNumberButtonTexts = new string[] { "7", "8", "9" };
            for (int i = 0; i < sevenToNineNumberButtonTexts.Count(); i++)
            {
                numberButton = row.AddControl(CxButton.New(sevenToNineNumberButtonTexts[i]));
                numberButton.Click += new EventHandler(numberButton_Click);
            }

            row = column.AddControl(LayoutControl.NewH(-1, -1, -1));
            row.Gap = 10;
            string[] pointAndZeroNumberButtonTexts = new string[] { ".", "0" };
            for (int i = 0; i < pointAndZeroNumberButtonTexts.Count(); i++)
            {
                numberButton = row.AddControl(CxButton.New(pointAndZeroNumberButtonTexts[i]));
                numberButton.Click += new EventHandler(numberButton_Click);
            }

            equalsButton = row.AddControl(CxButton.New("="));
            equalsButton.Click += new EventHandler(equalsButton_Click);

            column = lc.AddControl(LayoutControl.NewV(-1, -1, -1, -1, -1));
            column.Gap = 10;
            string[] operatorButtonText = new string[] { "C", "+", "-", "*", "/" };
            for (int i = 0; i < operatorButtonText.Count(); i++)
            {
                operatorButton = column.AddControl(CxButton.New(operatorButtonText[i]));
                operatorButton.Click += new EventHandler(operatorButton_Click);
            }

            lc.Render();
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
            else if (startInput && !string.IsNullOrEmpty(inputNumberTextBox.Text))
            {
                number = Convert.ToDouble(inputNumberTextBox.Text);
                operatorNumber = ((Button)sender).Text;
                operatorAfter = operatorNumber;
                numberTrigger = number;
                startInput = false;
                confirmNumber = false;
                operatorBefore = operatorBefore == null ? operatorNumber : operatorBefore;
            }
            else if (!startInput && !string.IsNullOrEmpty(inputNumberTextBox.Text))
            {
                operatorNumber = ((Button)sender).Text;
                number2 = Convert.ToDouble(inputNumberTextBox.Text);
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
            if (!string.IsNullOrEmpty(inputNumberTextBox.Text) && confirmNumber)
            {
                number2 = Convert.ToDouble(inputNumberTextBox.Text);
                operatorFunction();
                startInput = true;
                deleteInputTextBox = true;
            }
        }
    }
}
