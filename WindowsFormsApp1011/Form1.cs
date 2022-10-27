﻿using System;
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
        private void form1_Load(object sender, EventArgs e)
        {
            DataGridView dataGridView1 = new DataGridView();
            typeComboBox.SelectedIndex = 0;
            dataGridView1.AllowUserToAddRows = false;
            saveFileButton.Anchor = AnchorStyles.Top |
                                    AnchorStyles.Right;
        }

        private void uiEnable(bool enable)
        {
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
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "請選擇資料夾";
            // 設定起始目錄
            dialog.InitialDirectory = ".\\";
            // 設定起始目錄為程式目錄
            //dialog.InitialDirectory = Application.StartupPath;  
            dialog.Filter = "所有檔案(*.*)|*.*";
            Thread thread = new Thread(getDataTableCollection);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            readFileButton.Enabled = false;
            uiEnable(false);
        }

        private void getDataTableCollection()
        {
            rowItems = new List<RowItem>();
            //dataGridView1 = new DataGridView();
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
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
            }
            else    //if (dialog.ShowDialog() != DialogResult.OK)
            {
                Action readEnable = () =>
                {
                    readFileButton.Enabled = true;
                };
                Invoke(readEnable);
                dialog.Dispose(); 
                return;
            }

            Action action = () =>
            {
                List<DataGridViewRow> rows = new List<DataGridViewRow>();

                foreach (var rowItem in rowItems)
                    rows.Add(rowItem.ToRow());
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.AddRange(rows.ToArray());
                uiEnable(true);
                readFileButton.Enabled = true;
            };
            Invoke(action);
        }

        // confirm 設定
        private void confirmButton_Click(object sender, EventArgs e)  
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            List<RowItem> filterItems = new List<RowItem>();

            // confirm 設定 txt 篩選
            if (typeComboBox.Text == "Level")
            {
                filterItems = rowItems.FindAll(x => x.Level == searchTextBox.Text);
                rows = filterItems.ConvertAll(x => x.ToRow());

                if (string.IsNullOrEmpty(searchTextBox.Text))
                {
                    MessageBox.Show("請輸入文字 !", "顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rows = rowItems.ConvertAll(x => x.ToRow());
                }
            }
            if (typeComboBox.Text == "Category" )
            {
                filterItems = rowItems.FindAll(x => x.Category == searchTextBox.Text);
                rows = filterItems.ConvertAll(x => x.ToRow());

                if (string.IsNullOrEmpty(searchTextBox.Text))
                {
                    MessageBox.Show("請輸入文字 !", "顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rows = rowItems.ConvertAll(x => x.ToRow());
                }
            }
            if (typeComboBox.Text == "Tags")
            {
                filterItems = rowItems.FindAll(x => x.Tags == searchTextBox.Text);
                rows = filterItems.ConvertAll(x => x.ToRow());

                if (string.IsNullOrEmpty(searchTextBox.Text))
                {
                    MessageBox.Show("請輸入文字 !", "顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rows = rowItems.ConvertAll(x => x.ToRow());
                }
            }
            if (typeComboBox.Text == "Message")
            {
                searchTextBox.Text = string.Format("");
                filterItems = rowItems.FindAll(x => x.Message == searchTextBox.Text);
                rows = filterItems.ConvertAll(x => x.ToRow());

                if (string.IsNullOrEmpty(searchTextBox.Text))
                {
                    MessageBox.Show("請輸入文字 !", "顯示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    rows = rowItems.ConvertAll(x => x.ToRow());
                }
            }

            dataGridView1.Rows.Clear();
            dataGridView1.Rows.AddRange(rows.ToArray());
        }

        private void dateFilterCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            List<RowItem> filterItems = new List<RowItem>();

            if (dateFilterCheckBox.Checked == true)
            {
                var dateTimeStart = startDateTimePicker.Value;
                var dateTimeEnd = endDateTimePicker.Value;
                var filterTimeItems = rowItems.FindAll(x => x.Time >= dateTimeStart && x.Time <= dateTimeEnd);
                rows = filterTimeItems.ConvertAll(x => x.ToRow()); 
            }
            else
            {
                rows = rowItems.ConvertAll(x => x.ToRow());
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.AddRange(rows.ToArray());
        }

        // write file thread
        private void saveFileButton_Click(object sender, EventArgs e)       
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = @"C:\Users\rita5\source\repos\WindowsFormsApp1011";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Title = "另存新檔";
            Thread threadWrite = new Thread(threadWriteFile);
            threadWrite.SetApartmentState(ApartmentState.STA);
            threadWrite.Start();
        }
            
        private void threadWriteFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
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
            }
        }


    }
}
