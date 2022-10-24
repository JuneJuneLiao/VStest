namespace WindowsFormsApp1011
{
    partial class form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.readFileButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.lab_type = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.stopDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateFilterCheckBox = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.saveFileButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // readFileButton
            // 
            this.readFileButton.Location = new System.Drawing.Point(537, 27);
            this.readFileButton.Name = "readFileButton";
            this.readFileButton.Size = new System.Drawing.Size(91, 23);
            this.readFileButton.TabIndex = 0;
            this.readFileButton.Text = "Read File";
            this.readFileButton.UseVisualStyleBackColor = true;
            this.readFileButton.Click += new System.EventHandler(this.readFileButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(441, 27);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // lab_type
            // 
            this.lab_type.AutoSize = true;
            this.lab_type.Location = new System.Drawing.Point(22, 31);
            this.lab_type.Name = "lab_type";
            this.lab_type.Size = new System.Drawing.Size(36, 15);
            this.lab_type.TabIndex = 2;
            this.lab_type.Text = "Type";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDateTimePicker.Location = new System.Drawing.Point(121, 69);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(196, 25);
            this.startDateTimePicker.TabIndex = 3;
            this.startDateTimePicker.Value = new System.DateTime(2022, 10, 19, 10, 3, 1, 0);
            // 
            // stopDateTimePicker
            // 
            this.stopDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.stopDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.stopDateTimePicker.Location = new System.Drawing.Point(366, 69);
            this.stopDateTimePicker.Name = "stopDateTimePicker";
            this.stopDateTimePicker.Size = new System.Drawing.Size(195, 25);
            this.stopDateTimePicker.TabIndex = 4;
            // 
            // dateFilterCheckBox
            // 
            this.dateFilterCheckBox.AutoSize = true;
            this.dateFilterCheckBox.Location = new System.Drawing.Point(25, 75);
            this.dateFilterCheckBox.Name = "dateFilterCheckBox";
            this.dateFilterCheckBox.Size = new System.Drawing.Size(90, 19);
            this.dateFilterCheckBox.TabIndex = 5;
            this.dateFilterCheckBox.Text = "Date Filter";
            this.dateFilterCheckBox.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(848, 314);
            this.dataGridView1.TabIndex = 6;
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Items.AddRange(new object[] {
            "Level",
            "Category",
            "Time",
            "Tags",
            "Message"});
            this.typeComboBox.Location = new System.Drawing.Point(64, 28);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(120, 23);
            this.typeComboBox.TabIndex = 7;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(223, 25);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(196, 25);
            this.searchTextBox.TabIndex = 8;
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(769, 75);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(91, 23);
            this.saveFileButton.TabIndex = 9;
            this.saveFileButton.Text = "Save File";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 458);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateFilterCheckBox);
            this.Controls.Add(this.stopDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.lab_type);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.readFileButton);
            this.Name = "form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readFileButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label lab_type;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker stopDateTimePicker;
        private System.Windows.Forms.CheckBox dateFilterCheckBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button saveFileButton;
    }
}

