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
                for (int i = 0; i < 6; i++)
                    row.Cells.Add(new DataGridViewTextBoxCell());

                row.Cells[0].Value = Level;
                row.Cells[1].Value = Category;
                row.Cells[2].Value = Time;
                row.Cells[3].Value = Tags;
                row.Cells[4].Value = Message;
                row.Cells[5].Value = RowData;

                return row;
            }
        }
        private List<RowItem> rowItems;
        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridView dataGridView1 = new DataGridView();
            typeComboBox.SelectedIndex = 0;
            dataGridView1.AllowUserToAddRows = false;
            saveFileButton.Anchor = AnchorStyles.Top |
                                    AnchorStyles.Right;
            uiEnable(false);
            readFileButton.Enabled = true;
        }

        private void uiEnable(bool enable)
        {
            readFileButton.Enabled = enable;
            typeComboBox.Enabled = enable;
            searchTextBox.Enabled = enable;
            confirmButton.Enabled = enable;
            saveFileButton.Enabled = enable;
            dateFilterCheckBox.Enabled = enable;
            startDateTimePicker.Enabled = enable;
            endDateTimePicker.Enabled = enable;
        }

        private OpenFileDialog dialog = new OpenFileDialog();
        // read file
        private void readFileButton_Click(object sender, EventArgs e)       
        {
            uiEnable(false);
            dialog.Multiselect = true;
            dialog.Title = "請選擇資料夾";
            // 設定起始目錄
            dialog.InitialDirectory = ".\\";
            // 設定起始目錄為程式目錄
            //dialog.InitialDirectory = Application.StartupPath;  
            dialog.Filter = "所有檔案(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Thread thread = new Thread(getDataTableCollection);
                thread.Start();
            }
            else
            {
                readFileButton.Enabled = true;
                dialog.Dispose();
                return;
            }
        }

        private void getDataTableCollection()
        {
            rowItems = new List<RowItem>();
            string[] lines = File.ReadAllLines(dialog.FileName);
            foreach (string line in lines)
            {
                RowItem rowItem = new RowItem();
                rowItem.RowData = line;
                bool getTags = line.Contains('@');
                if (getTags == true)
                {
                    string[] getData = line.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
                    string[] getResult = getData[0].Split(',');
                    rowItem.Level = getResult[0];
                    rowItem.Category = getResult[1];
                    rowItem.Time = DateTime.Parse(getResult[2]);

                    string[] getResultTags = getData[1].Split(new string[] { "#json " }, StringSplitOptions.RemoveEmptyEntries);
                    rowItem.Tags = getResultTags[0].Replace(";", ",");
                    rowItem.Message = getResultTags[1];
                }
                else
                {
                    string[] getDataElse = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    rowItem.Level = getDataElse[0];
                    rowItem.Category = getDataElse[1];
                    rowItem.Time = DateTime.Parse(getDataElse[2]);
                    rowItem.Message = getDataElse[3];
                }
                rowItems.Add(rowItem);
            }

            DataGridViewRow[] rows = rowItems.ConvertAll(x => x.ToRow()).ToArray();

            Action action = () =>
            {
                dataGridView1.Rows.Clear();                
                dataGridView1.Rows.AddRange(rows);   
                uiEnable(true);
            };
            Invoke(action);
        }

        // confirm 設定
        private void confirmButton_Click(object sender, EventArgs e)  
        {
            uiEnable(false);
            Thread thread = new Thread(confirmThread);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private List<DataGridViewRow> rows = new List<DataGridViewRow>();
        private List<RowItem> filterItems = new List<RowItem>();
        private void confirmThread ()
        {
            Action confirm = () =>
            {
                // confirm 設定 txt 篩選
                if (typeComboBox.Text == "Level")
                {
                    filterItems = rowItems.FindAll(x => x.Level.ToLower() == searchTextBox.Text);
                    rows = filterItems.ConvertAll(x => x.ToRow());

                    if (string.IsNullOrEmpty(searchTextBox.Text))
                    {
                        MessageBox.Show("請輸入文字 !", "顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rows = rowItems.ConvertAll(x => x.ToRow());
                    }
                }
                else if (typeComboBox.Text == "Category")
                {
                    filterItems = rowItems.FindAll(x => x.Category.ToLower() == searchTextBox.Text);
                    rows = filterItems.ConvertAll(x => x.ToRow());

                    if (string.IsNullOrEmpty(searchTextBox.Text))
                    {
                        MessageBox.Show("請輸入文字 !", "顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rows = rowItems.ConvertAll(x => x.ToRow());
                    }
                }
                else if (typeComboBox.Text == "Tags")
                {
                    filterItems = rowItems.FindAll(x => x.Tags == searchTextBox.Text);
                    rows = filterItems.ConvertAll(x => x.ToRow());

                    if (string.IsNullOrEmpty(searchTextBox.Text))
                    {
                        MessageBox.Show("請輸入文字 !", "顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rows = rowItems.ConvertAll(x => x.ToRow());
                    }
                }
                else if (typeComboBox.Text == "Message")
                {
                    filterItems = rowItems.FindAll(x => x.Message.ToLower().Contains(searchTextBox.Text));
                    rows = filterItems.ConvertAll(x => x.ToRow());

                    if (string.IsNullOrEmpty(searchTextBox.Text))
                    {
                        MessageBox.Show("請輸入文字 !", "顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        rows = rowItems.ConvertAll(x => x.ToRow());
                    }
                }
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.AddRange(rows.ToArray());
                uiEnable(true);
            };
            Invoke(confirm);           
        }

        private void dateFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            uiEnable(false);
            if (dateFilterCheckBox.Checked == true)
            {
                Thread thread = new Thread(dateFilterCheck);
                thread.Start();
            }
            else
            {
                Thread thread = new Thread(dateFilterUnchecked);
                thread.Start();
            }
        }

        private void dateFilterCheck()
        {
            var dateTimeStart = startDateTimePicker.Value;
            var dateTimeEnd = endDateTimePicker.Value;
            if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                var filterTimeItems = rowItems.FindAll(x => x.Time >= dateTimeStart && x.Time <= dateTimeEnd);
                rows = filterTimeItems.ConvertAll(x => x.ToRow());
                Action checkNoSearchTextBox = () =>
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.AddRange(rows.ToArray());
                    uiEnable(true);
                };
                Invoke(checkNoSearchTextBox);
            }
            else
            {
                var filterTimeItems = filterItems.FindAll(x => x.Time >= dateTimeStart && x.Time <= dateTimeEnd);
                rows = filterTimeItems.ConvertAll(x => x.ToRow());
                Action check = () =>
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.AddRange(rows.ToArray());
                    uiEnable(true);
                };
                Invoke(check);
            }  
        }
        private void dateFilterUnchecked()
        {
            if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                rows = rowItems.ConvertAll(x => x.ToRow());
                Action uncheck = () =>
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.AddRange(rows.ToArray());
                    uiEnable(true);
                };
                Invoke(uncheck);
            }
            else
            {
                rows = filterItems.ConvertAll(x => x.ToRow());
                Action uncheck = () =>
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Rows.AddRange(rows.ToArray());
                    uiEnable(true);
                };
                Invoke(uncheck);
            }                
        }

        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        // write file thread
        private void saveFileButton_Click(object sender, EventArgs e)
        {
            uiEnable(false);
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = @"C:\Users\rita5\source\repos\WindowsFormsApp1011";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "另存新檔";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Thread threadWrite = new Thread(threadWriteFile);
                threadWrite.SetApartmentState(ApartmentState.STA);
                threadWrite.Start();
            }
            else
            {
                uiEnable(true);
                dialog.Dispose();
                return;
            }
        }

        private void threadWriteFile()
        {
            Action saveFile = () =>
            {
                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                if (dataGridView1.Rows.Count < 1)
                {
                    MessageBox.Show("沒有數據，輸出失敗", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)//
                    {
                        sw.Write(dataGridView1.Rows[i].Cells[5].Value.ToString());
                        sw.WriteLine("");
                    }
                    // clean 緩衝區
                    //sw.Flush();
                    sw.Close();
                    fs.Close();
                }
            };
            Invoke(saveFile);
        }
    }
}