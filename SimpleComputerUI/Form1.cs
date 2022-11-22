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

            Size = new Size(480, 220);
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
            LayoutControl lc = LayoutControl.NewH(-3, -1);
            lc.Dock = DockStyle.Fill;
            lc.Gap = 10;
            lc.Padding = new Padding(5);
            Controls.Add(lc);

            var row = lc.AddControl(LayoutControl.NewV(-1, -1, -1, -1, -1));
            row.Gap = 10;

            InputNumberTextBox = row.AddControl(CxTextBox.New(""));
            // Textbox前的Labe
            InputNumberTextBox.LabelMinWidth = 0;

            var row1 = row.AddControl(LayoutControl.NewH(-1, -1, -1));
            row1.Gap = 10;
            string[] numberButtonText = new string[] { "1", "2", "3" };

            for (int i = 0; i < numberButtonText.Count(); i++)
            {
                numberButton = row1.AddControl(CxButton.New(numberButtonText[i]));
                numberButton.Click += new EventHandler(numberButton_Click);
            }

            row1 = row.AddControl(LayoutControl.NewH(-1, -1, -1));
            row1.Gap = 10;
            string[] numberButtonText2 = new string[] { "4", "5", "6" };

            for (int i = 0; i < numberButtonText2.Count(); i++)
            {
                numberButton = row1.AddControl(CxButton.New(numberButtonText2[i]));
                numberButton.Click += new EventHandler(numberButton_Click);
            }

            row1 = row.AddControl(LayoutControl.NewH(-1, -1, -1));
            row1.Gap = 10;
            string[] numberButtonText3 = new string[] { "7", "8", "9" };

            for (int i = 0; i < numberButtonText3.Count(); i++)
            {
                numberButton = row1.AddControl(CxButton.New(numberButtonText3[i]));
                numberButton.Click += new EventHandler(numberButton_Click);
            }

            row1 = row.AddControl(LayoutControl.NewH(-1, -1, -1));
            row1.Gap = 10;
            string[] numberButtonText4 = new string[] { ".", "0"};

            for (int i = 0; i < numberButtonText4.Count(); i++)
            {
                numberButton = row1.AddControl(CxButton.New(numberButtonText4[i]));
                numberButton.Click += new EventHandler(numberButton_Click);
            }

            equalsButton = row1.AddControl(CxButton.New("="));
            equalsButton.Click += new EventHandler(equalsButton_Click);

            row = lc.AddControl(LayoutControl.NewV(-1, -1, -1, -1, -1));
            row.Gap = 10;
            string[] operatorButtonText = new string[] { "C", "+", "-", "*", "/" };

            for (int i = 0; i < operatorButtonText.Count(); i++)
            {
                operatorButton = row.AddControl(CxButton.New(operatorButtonText[i]));
                operatorButton.Click += new EventHandler(operatorButton_Click);
            }

            lc.Render();
        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            Button numberButton = (Button)sender;

            if (deleteInputTextBox)
            {
                InputNumberTextBox.Value = "";
                deleteInputTextBox = false;
            }

            InputNumberTextBox.Value += numberButton.Text;
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

            InputNumberTextBox.Value = calculateResult.ToString();
            number = calculateResult;
            numberTrigger = calculateResult;
            confirmNumber = false;
        }

        private void operatorButton_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "C")
            {
                InputNumberTextBox.Value = "0";
                startInput = true;
                confirmNumber = false;
                operatorBefore = null;
            }
            else if (startInput && !string.IsNullOrEmpty(InputNumberTextBox.Value))
            {
                number = Convert.ToDouble(InputNumberTextBox.Value);
                operatorNumber = ((Button)sender).Text;
                operatorAfter = operatorNumber;
                numberTrigger = number;
                startInput = false;
                confirmNumber = false;
                operatorBefore = operatorBefore == null ? operatorNumber : operatorBefore;
            }
            else if (!startInput && !string.IsNullOrEmpty(InputNumberTextBox.Value))
            {
                operatorNumber = ((Button)sender).Text;
                number2 = Convert.ToDouble(InputNumberTextBox.Value);
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
            if (!string.IsNullOrEmpty(InputNumberTextBox.Value) && confirmNumber)
            {
                number2 = Convert.ToDouble(InputNumberTextBox.Value);
                operatorFunction();
                startInput = true;
                deleteInputTextBox = true;
            }
        }
    }
}
