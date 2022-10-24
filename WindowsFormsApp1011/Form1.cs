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
using System.Threading;

namespace WindowsFormsApp1011
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        //[STAThread]

        DataSet dataSet = new DataSet();
        DataTable dt = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 1;
            //dtp.ShowCheckBox = true;
            dataGridView1.AllowUserToAddRows = false;
            dt.Columns.Add("Level", typeof(string));
            dt.Columns.Add("Category", typeof(string));
            dt.Columns.Add("Time", typeof(string));
            dt.Columns.Add("Tags", typeof(string));
            dt.Columns.Add("Message", typeof(string));
            dt.Columns.Add("all line", typeof(string));
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].MinimumWidth = 90;
            dataGridView1.Columns[1].MinimumWidth = 90;
            dataGridView1.Columns[2].MinimumWidth = 120;
            dataGridView1.Columns[3].MinimumWidth = 90;
            dataGridView1.Columns[4].MinimumWidth = 180;
            dataGridView1.Columns[5].Visible = false;
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
            BtnSaveFile.Anchor = AnchorStyles.Top |
                            AnchorStyles.Right;

        }
        
        // read file
        private void BtnReadFile_Click(object sender, EventArgs e)       
        {
            Thread thread = new Thread(DataTableCollection);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void DataTableCollection()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // 如果要允許選擇一個以上的
            dialog.Multiselect = true;  
            dialog.Title = "請選擇資料夾";
            // 設定起始目錄
            dialog.InitialDirectory = ".\\";
            // 設定起始目錄為程式目錄
            //dialog.InitialDirectory = Application.StartupPath;  
            dialog.Filter = "所有檔案(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {

                string[] lines = File.ReadAllLines(dialog.FileName);

                foreach (string line in lines)
                {
                    DataRow dr = dt.NewRow();
                    dr["all line"] = line;
                    bool get_tags = line.Contains('@');
                    if (get_tags == true)
                    {
                        string[] get_data = line.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
                        string[] get_result = get_data[0].Split(',');
                        dr["Level"] = get_result[0];
                        dr["Category"] = get_result[1];
                        dr["Time"] = get_result[2];

                        string[] get_result_m = get_data[1].Split(new string[] { "#json " }, StringSplitOptions.RemoveEmptyEntries);
                        dr["Tags"] = get_result_m[0].Replace(";", ",");
                        dr["Message"] = get_result_m[1];
                    }
                    else
                    {
                        string[] get_data_else = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        dr["Level"] = get_data_else[0];
                        dr["Category"] = get_data_else[1];
                        dr["Time"] = get_data_else[2];
                        dr["Message"] = get_data_else[3];

                    }

                    dt.Rows.Add(dr);
                    DataTable[] array = { };
                    dataSet.Tables.AddRange(array);
                }
            }
            else    //if (dialog.ShowDialog() != DialogResult.OK)
            {
                dialog.Dispose();
                return;
            }
        }


        // confirm 設定
        private void BtnConfirm_Click(object sender, EventArgs e)  
        {
            DataView dv = dt.DefaultView;
            // confirm 設定 txt 篩選
            if (string.IsNullOrEmpty(txtSearch.Text))   
            {
                //MessageBox.Show("請輸入文字 !", "顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dv.RowFilter = string.Empty;
                DataTable newTable = dv.ToTable();
            }
            else
            {
                dv.RowFilter = string.Format("{0} ='{1}'", cmbType.Text, txtSearch.Text);
                // 設定時間
                if (cb_df.Checked) 
                {
                    DateTime dateTime_Star = dateTimePicker_Start.Value.Date;
                    DateTime dateTime_Stop = dateTimePicker_Stop.Value.Date;
                    dv.RowFilter = String.Format("Time >= #{0:yyyy-MM-dd HH:mm:ss}# AND Time <= #{0:yyyy-MM-dd HH:mm:ss}#"
                        , dateTime_Star, dateTime_Stop);

                    //dv.DataSource = dt;
                    //DataTable newTable = dv.ToTable();

                }

                DataTable newTable = dv.ToTable();
            }

        }

        // write file thread
        private void BtnSaveFile_Click(object sender, EventArgs e)       
        {
            Thread thread_write = new Thread(ThreadWriteFile);
            thread_write.SetApartmentState(ApartmentState.STA);
            thread_write.Start();
            //Thread.Sleep(1);
        }
            
        private void ThreadWriteFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = @"C:\Users\rita5\source\repos\WindowsFormsApp1011";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "另存新檔";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                if (dataGridView1.Rows.Count < 1)
                {
                    MessageBox.Show("沒有數據，輸出失敗", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for(int i = 0; i < dataGridView1.Rows.Count; i++)//
                    { 
                        sw.Write(dataGridView1.Rows[i].Cells[5].Value.ToString());
                        sw.WriteLine("");                       
                        //MessageBox.Show("保存成功 !", "顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    // clean 緩衝區
                    //sw.Flush();
                    sw.Close();
                    fs.Close();
                }


            }

        }
    }

}
