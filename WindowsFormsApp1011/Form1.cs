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
    public partial class form1 : Form
    {

        public form1()
        {
            InitializeComponent();
        }
        //[STAThread]

        private DataSet dataSet = new DataSet();
        private DataTable dt = new DataTable();
        int readAgain = 1;

        class RowItem
        {
            public string RowData;
            public string Level;
            public string Category;
            public DateTime Time;
            public string Tags;
            public string Message;

            public DataGridViewRow ToRow()
            {
                var row = new DataGridViewRow();
                for (int i = 0; i < 5; i++)
                
                    row.Cells.Add(new DataGridViewTextBoxCell());
                

                row.Cells[0].Value = Level;
                row.Cells[1].Value = Category;
                row.Cells[2].Value = Time;
                row.Cells[3].Value = Tags;
                row.Cells[4].Value = Message;

                return row;
            }

        }
        private List<RowItem> rowItems;

        private void form1_Load(object sender, EventArgs e)
        {
            typeComboBox.SelectedIndex = 1;
            //dtp.ShowCheckBox = true;
            dataGridView1.AllowUserToAddRows = false;
            //dt.Columns.Add("Level", typeof(string));
            //dt.Columns.Add("Category", typeof(string));
            //dt.Columns.Add("Time", typeof(string));
            //dt.Columns.Add("Tags", typeof(string));
            //dt.Columns.Add("Message", typeof(string));
            //dt.Columns.Add("all line", typeof(string));
            //dataGridView1.DataSource = dt;
            //dataGridView1.Columns[0].MinimumWidth = 90;
            //dataGridView1.Columns[1].MinimumWidth = 90;
            //dataGridView1.Columns[2].MinimumWidth = 120;
            //dataGridView1.Columns[3].MinimumWidth = 90;
            //dataGridView1.Columns[4].MinimumWidth = 180;
            //dataGridView1.Columns[5].Visible = false;
            //dataGridView1.Rows[0].MinimumHeight = 50;
            //dataGridView1.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView1.Anchor = AnchorStyles.Bottom |
                                    AnchorStyles.Right |
                                    AnchorStyles.Top |
                                    AnchorStyles.Left;
            saveFileButton.Anchor = AnchorStyles.Top |
                            AnchorStyles.Right;
            typeComboBox.Enabled = false;
            searchTextBox.Enabled = false;
            confirmButton.Enabled = false;
            saveFileButton.Enabled = false;
            dateFilterCheckBox.Enabled = false;
            startDateTimePicker.Enabled = false;
            stopDateTimePicker.Enabled = false;

            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (var rowItem in rowItems)
                rows.Add(rowItem.ToRow());

            var filterItems = rowItems.FindAll(x => x.Level == "INFO");

            dataGridView1.Rows.Clear();
            dataGridView1.Rows.AddRange(rows.ToArray());
            rows = filterItems.ConvertAll(x => x.ToRow());

        }



        // read file
        private void readFileButton_Click(object sender, EventArgs e)       
        {
            if (readAgain == 1)
            {
                Thread thread = new Thread(getDataTableCollection);
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                readAgain = 2;
                Thread.Sleep(5000); 
                typeComboBox.Enabled = true;
                searchTextBox.Enabled = true;
                confirmButton.Enabled = true;
                saveFileButton.Enabled = true;
                dateFilterCheckBox.Enabled = true;
                startDateTimePicker.Enabled = true;
                stopDateTimePicker.Enabled = true;
            }
            else if (readAgain == 2)
            {
                MessageBox.Show("檔案執行中 請稍等 !", "顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //readFileButton.Enabled = false;
                readAgain = 1;
            }


        }

        private void getDataTableCollection()
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
                    bool getTags = line.Contains('@');
                    if (getTags == true)
                    {
                        string[] getData = line.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
                        string[] getResult = getData[0].Split(',');
                        dr["Level"] = getResult[0];
                        dr["Category"] = getResult[1];
                        dr["Time"] = getResult[2];

                        string[] getResultTags = getData[1].Split(new string[] { "#json " }, StringSplitOptions.RemoveEmptyEntries);
                        dr["Tags"] = getResultTags[0].Replace(";", ",");
                        dr["Message"] = getResultTags[1];
                    }
                    else
                    {
                        string[] getDataElse = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        dr["Level"] = getDataElse[0];
                        dr["Category"] = getDataElse[1];
                        dr["Time"] = getDataElse[2];
                        dr["Message"] = getDataElse[3];

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
        private void confirmButton_Click(object sender, EventArgs e)  
        {
            DataView dv = dt.DefaultView;
            // confirm 設定 txt 篩選
            if (string.IsNullOrEmpty(searchTextBox.Text))   
            {
                //MessageBox.Show("請輸入文字 !", "顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dv.RowFilter = string.Empty;
                DataTable newTable = dv.ToTable();
            }
            else
            {
                dv.RowFilter = string.Format("{0} ='{1}'", typeComboBox.Text, searchTextBox.Text);
                // 設定時間
                if (dateFilterCheckBox.Checked) 
                {
                    DateTime dateTimeStar = startDateTimePicker.Value.Date;
                    DateTime dateTimeStop = stopDateTimePicker.Value.Date;
                    dv.RowFilter = String.Format("Time >= #{0:yyyy-MM-dd HH:mm:ss}# AND Time <= #{0:yyyy-MM-dd HH:mm:ss}#"
                        , dateTimeStar, dateTimeStop);

                    //dv.DataSource = dt;
                    //DataTable newTable = dv.ToTable();

                }

                DataTable newTable = dv.ToTable();
            }

        }

        // write file thread
        private void saveFileButton_Click(object sender, EventArgs e)       
        {
            Thread threadWrite = new Thread(threadWriteFile);
            threadWrite.SetApartmentState(ApartmentState.STA);
            threadWrite.Start();
            //Thread.Sleep(1);
        }
            
        private void threadWriteFile()
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
