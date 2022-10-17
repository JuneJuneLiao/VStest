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
        //public Button button1;
        //public TextBox textbox1;
        //public ListBox listbox1;


        public Form1()
        {
            InitializeComponent();

            //this.button1 = new Button();
            //this.button1.Location = new Point(550, 10);
            //this.button1.Text = "Click Me !";
            //this.button1.Click += new EventHandler(this.button_Click);

     
            //this.Controls.Add(button1);
            
            //this.textbox1 = new TextBox();
            //this.listbox1 = new ListBox();
            //this.Controls.Add(textbox1);
            //this.Controls.Add(listbox1);

        }
        //[STAThread]

        DataTable dt = new DataTable();
        private string[] values;
        private string[] tags;
        //DateTimePicker dtp = new DateTimePicker();

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
            //dtp.ShowCheckBox = true;
            dt.Columns.Add("Level", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Time", typeof(string));
            dt.Columns.Add("Tags", typeof(string));
            dt.Columns.Add("Message", typeof(string));
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].MinimumWidth = 90;
            dataGridView1.Columns[1].MinimumWidth = 90;
            dataGridView1.Columns[2].MinimumWidth = 120;
            dataGridView1.Columns[3].MinimumWidth = 90;
            dataGridView1.Columns[4].MinimumWidth = 180;
            //dataGridView1.Rows[0].MinimumHeight = 50;
            

        }

        private void btn_rf_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Multiselect = true;  // 如果要允許選擇一個以上的
            dialog.Title = "請選擇資料夾";
            dialog.InitialDirectory = ".\\";    //設定起始目錄
            //dialog.InitialDirectory = Application.StartupPath;  //設定起始目錄為程式目錄
            dialog.Filter = "所有檔案(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(dialog.FileName);
                string[] lines = File.ReadAllLines(dialog.FileName);
                foreach  (string line in lines)
                {
                        values = line.Split(',');
                        //tags = line.Substring('@');
                        dt.Rows.Add(line);
                }
            }
            else if (dialog.ShowDialog() != DialogResult.OK)
            {
                    dialog.Dispose();
                    return;
            }

            
            /*
            string [] lines = File.ReadAllLines(@"C:\Users\rita5\source\repos\WindowsFormsApp1011\cx_vis.log");
            StreamReader sr = new StreamReader("C:/Users/rita5/source/repos/WindowsFormsApp1011/cx_vis.log");
            string line;

            string [] values;
            string tags ;
            string[] meg;

            //while()

            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split(',');

                //tags = lines[i].ToString().Split();
                lines[i].Contains('@');
                //int index = lines[i].IndexOf(',');
                //string content = lines.Substring(index,lines.Length-index-1);

                string[] row = new string[values.Length];

                for (int j = 0; j< lines.Length; j++)
                {
                    row[j] = values[j].Trim();
                }
                dt.Rows.Add(row);
            }*/
        }


        private void btn_cf_Click(object sender, EventArgs e) //confirm 設定
        {
            DataView dv = dt.DefaultView;
            if (string.IsNullOrEmpty(txtSearch.Text))  //confirm 設定 txt 篩選
            {
                dv.RowFilter = string.Empty;
                    //customersBindingSource.Filter = string.Empty;
            }
            else
            {
                dv.RowFilter = string.Format("{0} ='{1}'", cmbType.Text, txtSearch.Text);
                //customersBindingSource.Filter = string.Format("{0} ='{1}'", cmbType.Text, txtSearch.Text);
                //productsBindingSource.Filter = string.Format("{0} ='{1}'", cmbType.Text, txtSearch.Text);
            }



            /*if (cb_df) //設定時間
            {
                DataTime Date1 = dateTimePicker_Star.Value.Date;
                DataTime Date2 = dateTimePicker_Stop.Value.Date;
                dataGridView1.RowFilter = String.Format("Date1 > #{0:yyyy-MM-dd HH:mm:ss}# AND Date1 < #{0:yyyy-MM-dd HH:mm:ss}#", Date1,Date2);
                dataGridView1.DataSource = dt;

                

            }*/
        }
    }

}
