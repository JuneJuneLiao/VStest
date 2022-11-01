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
            uiEnable(false);
            readFileButton.Enabled = true;
        }

        private List<RowItem> rowItems;

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

        // read file
        private void readFileButton_Click(object sender, EventArgs e)       
        {
            uiEnable(false);
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "請選擇資料夾";
            // 設定起始目錄
            dialog.InitialDirectory = ".\\";
            // 設定起始目錄為程式目錄
            //dialog.InitialDirectory = Application.StartupPath;  x
            dialog.Filter = "所有檔案(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                new Thread(new ParameterizedThreadStart(getDataPutInTheUI)).Start(dialog.FileName);
            }
            else
            {
                readFileButton.Enabled = true;
                dialog.Dispose();
                return;
            }
        }

        private void getDataPutInTheUI(object fileName)
        {
            rowItems = new List<RowItem>();
            string[] lines = File.ReadAllLines(fileName.ToString());
            foreach (string line in lines)
            {
                RowItem rowItem = new RowItem();
                rowItem.RowData = line;
                bool containsMouse = line.Contains('@');
                if (containsMouse)
                {
                    string[] containsMouseSplit = line.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
                    string[] containsMouseResults = containsMouseSplit[0].Split(',');
                    rowItem.Level = containsMouseResults[0];
                    rowItem.Category = containsMouseResults[1];
                    rowItem.Time = DateTime.Parse(containsMouseResults[2]);

                    string[] mouseMessageSplit = containsMouseSplit[1].Split(new string[] { "#json " }, StringSplitOptions.RemoveEmptyEntries);
                    rowItem.Tags = mouseMessageSplit[0].Replace(";", ",");
                    rowItem.Message = mouseMessageSplit[1];
                }
                else
                {
                    string[] uncontainsMouseSplit = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    rowItem.Level = uncontainsMouseSplit[0];
                    rowItem.Category = uncontainsMouseSplit[1];
                    rowItem.Time = DateTime.Parse(uncontainsMouseSplit[2]);
                    rowItem.Message = uncontainsMouseSplit[3];
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
            new Thread(confirmThread).Start();
        }

        private List<RowItem> filterItems = new List<RowItem>();

        private void confirmThread ()
        {
            var dateTimeStart = startDateTimePicker.Value;
            var dateTimeEnd = endDateTimePicker.Value;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            Action confirm = () =>
            {
                // confirm 設定 txt 篩選
                if (dateFilterCheckBox.Checked)
                {
                    uiEnable(false);
                    if (string.IsNullOrEmpty(searchTextBox.Text))
                    {
                        var filterTimeItems = rowItems.FindAll(x => x.Time >= dateTimeStart && x.Time <= dateTimeEnd);
                        rows = filterTimeItems.ConvertAll(x => x.ToRow());
                    }
                    else if (typeComboBox.Text == "Level")
                    {
                        var filterTimeItems = rowItems.FindAll(x => x.Time >= dateTimeStart && x.Time <= dateTimeEnd);
                        filterItems = filterTimeItems.FindAll(x => x.Level.ToLower() == searchTextBox.Text);
                        rows = filterItems.ConvertAll(x => x.ToRow());
                    }
                    else if (typeComboBox.Text == "Category")
                    {
                        var filterTimeItems = rowItems.FindAll(x => x.Time >= dateTimeStart && x.Time <= dateTimeEnd);
                        filterItems = filterTimeItems.FindAll(x => x.Category.ToLower() == searchTextBox.Text);
                        rows = filterItems.ConvertAll(x => x.ToRow());
                    }
                    else if (typeComboBox.Text == "Tags")
                    {
                        var filterTimeItems = rowItems.FindAll(x => x.Time >= dateTimeStart && x.Time <= dateTimeEnd);
                        filterItems = rowItems.FindAll(x => x.Tags == searchTextBox.Text);
                        rows = filterItems.ConvertAll(x => x.ToRow());
                    }
                    else if (typeComboBox.Text == "Message")
                    {
                        var filterTimeItems = rowItems.FindAll(x => x.Time >= dateTimeStart && x.Time <= dateTimeEnd);
                        filterItems = rowItems.FindAll(x => x.Message.ToLower().Contains(searchTextBox.Text));
                        rows = filterItems.ConvertAll(x => x.ToRow());
                    }
                }
                else
                {
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

        // write file thread
        private void saveFileButton_Click(object sender, EventArgs e)
        {
            uiEnable(false);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = @"C:\Users\rita5\source\repos\WindowsFormsApp1011";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "另存新檔";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                new Thread(new ParameterizedThreadStart(threadWriteFile)).Start(saveFileDialog.FileName);
            }
            else
            {
                uiEnable(true);
                saveFileDialog.Dispose();
                return;
            }
        }

        private void threadWriteFile(object fileName)
        {
            Action saveFile = () =>
            {
                FileStream fs = new FileStream(fileName.ToString(), FileMode.Create);
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
                uiEnable(true);
            };
            Invoke(saveFile);
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
    }
}