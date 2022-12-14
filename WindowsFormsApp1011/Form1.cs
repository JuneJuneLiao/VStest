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
using Newtonsoft.Json;

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
                rowItem.RawData = line;
                bool containsJson = line.Contains("#json ");

                if (containsJson)
                {
                    string[] containsJsonSplit = line.Split(new string[] { "#json " }, StringSplitOptions.RemoveEmptyEntries);
                    string[] containsJsonResults = containsJsonSplit[0].Split(',');
                    rowItem.Level = containsJsonResults[0];
                    rowItem.Category = containsJsonResults[1];
                    rowItem.Time = DateTime.Parse(containsJsonResults[2]);
                    rowItem.Tags = containsJsonResults[3].Replace("@", "").Replace(";", ",");
                    rowItem.Message = containsJsonSplit[1];
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
            Parameter parameter = new Parameter();
            parameter.TypeCombo = typeComboBox.Text;
            parameter.SearchText = searchTextBox.Text;
            parameter.DateFilterCheck = dateFilterCheckBox.Checked;
            parameter.StartDateTime = startDateTimePicker.Value;
            parameter.EndDateTime = endDateTimePicker.Value;
            new Thread(new ParameterizedThreadStart(confirmThread)).Start(parameter);
        }

        private List<RowItem> filterItems = new List<RowItem>();
   
        private void confirmThread (object obj)
        {
            Parameter parameter = obj as Parameter;
            var dateTimeStart = parameter.StartDateTime;
            var dateTimeEnd = parameter.EndDateTime;
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            filterItems = rowItems.ToList();

            // confirm 設定 txt 篩選
            if (parameter.DateFilterCheck)
            {
                filterItems = rowItems.FindAll(x => x.Time >= dateTimeStart && x.Time <= dateTimeEnd);
            }

            if (!string.IsNullOrEmpty(parameter.SearchText))
            {
                if (parameter.TypeCombo == "Level")
                {
                    filterItems = filterItems.FindAll(x => x.Level.ToLower() == parameter.SearchText);
                }
                else if (parameter.TypeCombo == "Category")
                {
                    filterItems = filterItems.FindAll(x => x.Category.ToLower() == parameter.SearchText);
                }
                else if (parameter.TypeCombo == "Tags")
                {
                    filterItems = filterItems.FindAll(x => x.Tags == parameter.SearchText);
                }
                else if (parameter.TypeCombo == "Message")
                {
                    filterItems = filterItems.FindAll(x => x.Message.ToLower().Contains(parameter.SearchText));
                }
            }

            rows = filterItems.ConvertAll(x => x.ToRow());

            Action confirm = () =>
            {
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string jsonData = dataGridView1[4,dataGridView1.CurrentRow.Index].Value.ToString();
            JsonPath form2 = new JsonPath(jsonData);
            form2.Show();
        }

        class RowItem
        {
            public string RawData;
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
                row.Cells[5].Value = RawData;

                return row;
            }
        }

        class Parameter
        {
            public string TypeCombo;
            public string SearchText;
            public bool DateFilterCheck;
            public DateTime StartDateTime;
            public DateTime EndDateTime;
        }
    }
}