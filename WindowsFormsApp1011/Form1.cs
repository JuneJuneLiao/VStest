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
            dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Anchor = AnchorStyles.Bottom |
                                    AnchorStyles.Right |
                                    AnchorStyles.Top |
                                    AnchorStyles.Left;
            btn_sf.Anchor = AnchorStyles.Top |
                            AnchorStyles.Right;

        }

        private void btn_rf_Click(object sender, EventArgs e)       //read file
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
                //string pattern = @"^[A-Za-z0-9]+$";     //規律字串
                //string sPattern = "^@$";    //規律字串
                //string sjn = "^#json$";         //規律字串
                foreach  (string line in lines)
                {
                    string[] get_data = line.Split(new string[] { "," },StringSplitOptions.RemoveEmptyEntries);
                    //string[] get_tag = get_data[3].Replace(";", ",");

                    DataRow dr = dt.NewRow();
                    dr["Level"] = get_data[0];
                    dr["Category"] = get_data[1];
                    dr["Time"] = get_data[2];
                    //dr["Tags"] = get_tag[0];
                    //dr["Message"] = get_tag[0];

                    bool tack_m = get_data[3].Contains('@');
                    //bool tack_m = Regex.IsMatch(get_tag[0], sPattern);
                    //bool take_sjn = Regex.IsMatch(get_tag[0], sjn);
                    //bool take_mes = Regex.IsMatch(get_tag[0], pattern);


                    if (tack_m == true)
                    {
                        //dt.Rows.Add(dr["Tags"]);
                        //dr["Tags"] = get_tag[0];
                        string[] spl_msg = get_data[3].Replace(";", ",").Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                        dr["Tags"] = spl_msg[0].Replace("@", "");
                        dr["Message"] = spl_msg[1].Substring(5);

                    }
                    else
                    {
                        dr["Message"] = get_data[3];
                    }

                    /*else if (take_sjn == false)
                    {
                        //dt.Rows.Add(dr["Message"]);
                    }
                    else if (take_mes == false)
                    {
                        //dt.Rows.Add(dr["Message"]);
                    }
                    
                    DataRow dr = dt.NewRow();
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
            //dt.DefaultView.Sort = "Time"; //按time排序
            //dt = dt.DefaultView.ToTable();

            /*
            string [] lines = File.ReadAllLines(@"C:\Users\rita5\source\repos\WindowsFormsApp1011\cx_vis.log");
            StreamReader sr = new StreamReader("C:/Users/rita5/source/repos/WindowsFormsApp1011/cx_vis.log");

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
                DataTable newTable = dv.ToTable();
            }
            else
            {
                dv.RowFilter = string.Format("{0} ='{1}'", cmbType.Text, txtSearch.Text);
                DataTable newTable = dv.ToTable();
            }
            
            if (cb_df.Checked) //設定時間
            {
                DateTime Date1 = dateTimePicker_Star.Value.Date;
                DateTime Date2 = dateTimePicker_Stop.Value.Date;
                dv.RowFilter = String.Format("Date1 > #{0:yyyy-MM-dd HH:mm:ss}# AND Date1 < #{0:yyyy-MM-dd HH:mm:ss}#", dateTimePicker_Star.Value, dateTimePicker_Stop.Value);
                //dv.DataSource = dt;
                DataTable newTable = dv.ToTable();

            }
        }

        private void btn_sf_Click(object sender, EventArgs e)       //write file
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = @"C:\Users\rita5\source\repos\WindowsFormsApp1011";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "另存新檔";
            //saveFileDialog.ShowDialog();
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //File.WriteAllText(saveFileDialog.FileName, string.Empty); 
                //dataGridView1.DataSource = saveFileDialog.FileName;
                //Stream myStream;
                //myStream = saveFileDialog.OpenFile();

                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                if(dataGridView1.Rows.Count < 1)
                {
                    MessageBox.Show("沒有數據，輸出失敗","提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sw.WriteLine(dataGridView1.Rows.Count-1);
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            

                            //writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + ",");
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                sw.WriteLine(dataGridView1.Rows[i].Cells[j].Value.ToString() + ",");
                                DataTable table = new DataTable();
                                DataRow row = table.NewRow();
                                if (dt.Rows[3] != null)
                                {
                                    //String.Join("@", dt.Rows[3]);
                                    //String.Join("#json ", dt.Rows[4]);
                                }
                                else
                                {
                                     //row[4].TrimStar(',');
                                }
                            }
                            //else
                            //    sw.WriteLine("");
                        }
                    }
                    //clean 緩衝區
                    //sw.Flush();
                    sw.Close();
                    fs.Close();
                    MessageBox.Show("保存成功 !", "顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                
            }
            
            /* //write one file 
            TextWriter writer = new StreamWriter(@"C:\Users\rita5\source\repos\WindowsFormsApp1011\test.log");
            for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                for(int j = 0; j < dataGridView1.Columns.Count-1; j++)
                {
                    writer.Write( dataGridView1.Rows[i].Cells[j].Value.ToString()  + ",");
                }
                writer.WriteLine("");
            }
            writer.Close();
            MessageBox.Show("Data Exported!");
            */
        }
    }

}
