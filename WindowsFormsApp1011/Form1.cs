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
            this.button1.Location = new Point(550, 10);
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
            //button1.Visible = false;

            DataGridView dataGridView = new DataGridView();
            
            // 填滿視窗
            dataGridView.Dock = DockStyle.Fill;
            //dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //自動調欄寬
            dataGridView.AutoResizeColumns();

            //自動調欄高
            dataGridView.AutoResizeRows();


            DataTable dt = new DataTable();
            dt.Columns.Add("Level", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Time", typeof(string));
            dt.Columns.Add("Tags", typeof(string));
            dt.Columns.Add("Message", typeof(string));
            dataGridView.DataSource = dt;

            //width
            //dataGridView.Columns["Level"].Width = 200;
            //dataGridView.Columns["Level"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;


            using (StreamReader sr = new StreamReader("C:/Users/rita5/source/repos/WindowsFormsApp1011/cx_vis.log"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line.Length);

                    int i = line.IndexOf("@");
                    int j = line.IndexOf("#");
                    line = (line.Substring(i + 1)).Substring(0, j - i - 1); //找出@#之間的字串
                    Console.WriteLine(line.Length);

                    //string[] elements = line.Replace('@', ',').Split(',');
                    string[] elements = line.Replace(';', ',').Split(new char[] { ',' });         
                    DataRow dr = dt.NewRow();


                    StreamWriter str = new StreamWriter("C:/Users/rita5/source/repos/WindowsFormsApp1011/cx_vis_1.log");

                    str.WriteLine(line);
                    /*
                    foreach (string info in elements)
                    {
                        str.WriteLine("   {0}", info.Substring(info.IndexOf("@ ") + 1));
                    }
                    */
                    str.Close();

                    
                    if (dataGridView.Rows.Count == 0)
                    {
                        
                    }
                    
                   
                    if (elements[3] == "@" )
                    {
                        dr[3] = elements[3];
                    }
                    else
                    {
                        dr[3] = null;
                    }

                    

                    dr[0] = elements[0];
                    dr[1] = elements[1];
                    dr[2] = elements[2];

                    dr[3] = elements[3];
                    //dr[4] = elements[4];
                    

                    //將資料加入到datatable中
                    dt.Rows.Add(dr);
                }
            }
            
            // 新增到當前的 Form 中
            this.Controls.Add(dataGridView);
        }


    }
   
   }
