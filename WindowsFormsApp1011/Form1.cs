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
using System.Text.RegularExpressions;

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
        //DateTimePicker dtp = new DateTimePicker();

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 1;
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
                string pattern = @"^[A-Za-z0-9]+$";     //規律字串
                string sPattern = "^@$";    //規律字串
                string sjn = "^#json$";         //規律字串
                foreach  (string line in lines)
                {
                    string[] get_data = line.Split(new string[] { "," },StringSplitOptions.RemoveEmptyEntries);
                    string[] get_tag = get_data[3].Replace(';', ',').Split(new string[] { "#json" }, StringSplitOptions.RemoveEmptyEntries);
                    


                    DataRow dr = dt.NewRow();
                    dr["Level"] = get_data[0];
                    dr["Category"] = get_data[1];
                    dr["Time"] = get_data[2];
                    dr["Tags"] = get_tag[0];
                    //dr["Message"] = get_tag[0];

                    bool tack_m = get_tag[0].Contains('@');
                    //bool tack_m = Regex.IsMatch(get_tag[0], sPattern);
                    bool take_sjn = Regex.IsMatch(get_tag[0], sjn);
                    bool take_mes = Regex.IsMatch(get_tag[0], pattern);
                    

                    if (tack_m == true)
                    {
                        //dt.Rows.Add(dr["Tags"]);
                        //dr["Tags"] = get_tag[0];

                    }
                    else if (take_sjn == false)
                    {
                        //dt.Rows.Add(dr["Message"]);
                    }
                    else if (take_mes == false)
                    {
                        //dt.Rows.Add(dr["Message"]);
                    }
                    /*
                    DataRow dr = dt.NewRow();
                    bool tack_m = Regex.IsMatch(get_data[3], sPattern);
                    bool take_sjn = Regex.IsMatch(line, sjn);
                    
                    //tags = line.Substring('@');
                    */
                    dt.Rows.Add(dr);
                    
                }
            }
            else if (dialog.ShowDialog() != DialogResult.OK)
            {
                    dialog.Dispose();
                    return;
            }
            dt.DefaultView.Sort = "Time"; //按time排序
            dt = dt.DefaultView.ToTable();

            /*
            string [] lines = File.ReadAllLines(@"C:\Users\rita5\source\repos\WindowsFormsApp1011\cx_vis.log");
            StreamReader sr = new StreamReader("C:/Users/rita5/source/repos/WindowsFormsApp1011/cx_vis.log");

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
            /*
            if (cb_df.Checked) //設定時間
            {
                //DataTime Date1 = dateTimePicker_Star.Value.Date;
                //DataTime Date2 = dateTimePicker_Stop.Value.Date;
                dv.RowFilter = String.Format("Date1 > #{0:yyyy-MM-dd HH:mm:ss}# AND Date1 < #{0:yyyy-MM-dd HH:mm:ss}#", dateTimePicker_Star.Value, dateTimePicker_Stop.Value);
                //dv.DataSource = dt;

            }*/
        }

        private void btn_sf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = @"C:\Users\rita5\source\repos\WindowsFormsApp1011";
            //if (saveFileDialog.ShowDialog() == true)
            //    File.WriteAllText(saveFileDialog.FileName, txtEditor.Text);    

            /* //read one file 
            TextWriter writer = new StreamWriter(@"C:\Users\rita5\source\repos\WindowsFormsApp1011\test.log");
            for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                for(int j = 0; j < dataGridView1.Columns.Count-1; j++)
                {
                    writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + ",");
                }
                writer.WriteLine("");
            }
            writer.Close();
            MessageBox.Show("Data Exported!");
            */
        }
    }

}
