using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1011
{
    public partial class Form1 : Form
    {
        public Button button1;
        public TextBox textbox1;
        public ListBox listbox1;


        public Form1()
        {
            InitializeComponent();

            this.button1 = new Button();
            this.button1.Location = new Point(10, 10);
            this.button1.Text = "Click Me !";
            this.button1.Click += new EventHandler(this.button_Click);

     
            this.Controls.Add(button1);
            
            //this.textbox1 = new TextBox();
            //this.listbox1 = new ListBox();
            //this.Controls.Add(textbox1);
            //this.Controls.Add(listbox1);

        }
        [STAThread]
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Click (object sender, EventArgs e)
        {
            //Console.WriteLine ("hello");
            button1.Visible = false;

            DataGridView dataGridView = new DataGridView();
            //dataGridView.Dock = DockStyle.Fill;// 填滿視窗
            //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Level", typeof(string));
            dataTable.Columns.Add("Category", typeof(string));
            dataTable.Columns.Add("Time", typeof(string));
            dataTable.Columns.Add("Tags", typeof(string));
            dataTable.Columns.Add("Message", typeof(string));
            dataGridView.DataSource = dataTable;

            using (StreamReader sr = new StreamReader("C:/Users/rita5/source/repos/WindowsFormsApp1011/cx_vis.log"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] elements = line.Split(new char[2] { ',', ' '});
                    DataRow dr = dataTable.NewRow();
                    dr[0] = elements[0];
                    dr[1] = elements[1];
                    dr[2] = elements[2];
                    dr[3] = elements[3];
                    dr[4] = elements[4];

                    dataTable.Rows.Add(dr);
                }
            }

            this.Controls.Add(dataGridView);// 新增到當前的 Form 中
        }


    }
   
   }
