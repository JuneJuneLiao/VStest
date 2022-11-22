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
            LayoutControl lc = LayoutControl.NewV(23, 23, 23, 23, 23);
            lc.Dock = DockStyle.Fill;
            lc.Gap = 10;
            lc.Padding = new Padding(5);
            Controls.Add(lc);

            // Textbox and C Button
            var row = lc.AddControl(LayoutControl.NewH(-3, -1));
            row.Gap = 10;

            InputNumberTextBox = row.AddControl(CxTextBox.New(""));

            // Textbox 前的Labe
            InputNumberTextBox.LabelMinWidth = 0; 
            operatorButton = row.AddControl(CxButton.New("C"));
            operatorButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(operatorButton);

            // 1 ~ 3 and + Button
            row = lc.AddControl(LayoutControl.NewH(-1, -1, -1, -1));
            row.Gap = 10;
            numberButton = row.AddControl(CxButton.New("1"));
            numberButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberButton);

            numberButton = row.AddControl(CxButton.New("2"));
            numberButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberButton);

            numberButton = row.AddControl(CxButton.New("3"));
            numberButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberButton);

            operatorButton = row.AddControl(CxButton.New("+"));
            operatorButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(operatorButton);

            // 4 ~ 6 and - Button
            row = lc.AddControl(LayoutControl.NewH(-1, -1, -1, -1));
            row.Gap = 10;
            numberButton = row.AddControl(CxButton.New("4"));
            numberButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberButton);

            numberButton = row.AddControl(CxButton.New("5"));
            numberButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberButton);

            numberButton = row.AddControl(CxButton.New("6"));
            numberButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberButton);

            operatorButton = row.AddControl(CxButton.New("-"));
            operatorButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(operatorButton);

            // 7 ~ 9 and * Button
            row = lc.AddControl(LayoutControl.NewH(-1, -1, -1, -1));
            row.Gap = 10;
            numberButton = row.AddControl(CxButton.New("7"));
            numberButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberButton);

            numberButton = row.AddControl(CxButton.New("8"));
            numberButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberButton);

            numberButton = row.AddControl(CxButton.New("9"));
            numberButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberButton);

            operatorButton = row.AddControl(CxButton.New("*"));
            operatorButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(operatorButton);

            // . 0 = and / Button
            row = lc.AddControl(LayoutControl.NewH(-1, -1, -1, -1));
            row.Gap = 10;
            numberButton = row.AddControl(CxButton.New("."));
            numberButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberButton);

            numberButton = row.AddControl(CxButton.New("0"));
            numberButton.Click += new EventHandler(numberButton_Click);
            Controls.Add(numberButton);

            equalsButton = row.AddControl(CxButton.New("="));
            equalsButton.Click += new EventHandler(equalsButton_Click);
            Controls.Add(equalsButton);

            operatorButton = row.AddControl(CxButton.New("/"));
            operatorButton.Click += new EventHandler(operatorButton_Click);
            Controls.Add(operatorButton);
            
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
