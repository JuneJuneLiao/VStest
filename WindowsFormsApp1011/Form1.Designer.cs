namespace WindowsFormsApp1011
{
    partial class Form1
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
            this.btn_rf = new System.Windows.Forms.Button();
            this.btn_cf = new System.Windows.Forms.Button();
            this.lab_type = new System.Windows.Forms.Label();
            this.dateTimePicker_Star = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Stop = new System.Windows.Forms.DateTimePicker();
            this.cb_df = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btn_sf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_rf
            // 
            this.btn_rf.Location = new System.Drawing.Point(537, 27);
            this.btn_rf.Name = "btn_rf";
            this.btn_rf.Size = new System.Drawing.Size(91, 23);
            this.btn_rf.TabIndex = 0;
            this.btn_rf.Text = "Read File";
            this.btn_rf.UseVisualStyleBackColor = true;
            this.btn_rf.Click += new System.EventHandler(this.btn_rf_Click);
            // 
            // btn_cf
            // 
            this.btn_cf.Location = new System.Drawing.Point(441, 27);
            this.btn_cf.Name = "btn_cf";
            this.btn_cf.Size = new System.Drawing.Size(75, 23);
            this.btn_cf.TabIndex = 1;
            this.btn_cf.Text = "Confirm";
            this.btn_cf.UseVisualStyleBackColor = true;
            this.btn_cf.Click += new System.EventHandler(this.btn_cf_Click);
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
            // dateTimePicker_Star
            // 
            this.dateTimePicker_Star.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_Star.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_Star.Location = new System.Drawing.Point(121, 69);
            this.dateTimePicker_Star.Name = "dateTimePicker_Star";
            this.dateTimePicker_Star.Size = new System.Drawing.Size(196, 25);
            this.dateTimePicker_Star.TabIndex = 3;
            this.dateTimePicker_Star.Value = new System.DateTime(2022, 10, 19, 10, 3, 1, 0);
            // 
            // dateTimePicker_Stop
            // 
            this.dateTimePicker_Stop.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker_Stop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_Stop.Location = new System.Drawing.Point(366, 69);
            this.dateTimePicker_Stop.Name = "dateTimePicker_Stop";
            this.dateTimePicker_Stop.Size = new System.Drawing.Size(195, 25);
            this.dateTimePicker_Stop.TabIndex = 4;
            // 
            // cb_df
            // 
            this.cb_df.AutoSize = true;
            this.cb_df.Location = new System.Drawing.Point(25, 75);
            this.cb_df.Name = "cb_df";
            this.cb_df.Size = new System.Drawing.Size(90, 19);
            this.cb_df.TabIndex = 5;
            this.cb_df.Text = "Date Filter";
            this.cb_df.UseVisualStyleBackColor = true;
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
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Level",
            "Category",
            "Time",
            "Tags",
            "Message"});
            this.cmbType.Location = new System.Drawing.Point(64, 28);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(120, 23);
            this.cmbType.TabIndex = 7;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(223, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(196, 25);
            this.txtSearch.TabIndex = 8;
            // 
            // btn_sf
            // 
            this.btn_sf.Location = new System.Drawing.Point(769, 75);
            this.btn_sf.Name = "btn_sf";
            this.btn_sf.Size = new System.Drawing.Size(91, 23);
            this.btn_sf.TabIndex = 9;
            this.btn_sf.Text = "Save File";
            this.btn_sf.UseVisualStyleBackColor = true;
            this.btn_sf.Click += new System.EventHandler(this.btn_sf_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 458);
            this.Controls.Add(this.btn_sf);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cb_df);
            this.Controls.Add(this.dateTimePicker_Stop);
            this.Controls.Add(this.dateTimePicker_Star);
            this.Controls.Add(this.lab_type);
            this.Controls.Add(this.btn_cf);
            this.Controls.Add(this.btn_rf);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_rf;
        private System.Windows.Forms.Button btn_cf;
        private System.Windows.Forms.Label lab_type;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Star;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Stop;
        private System.Windows.Forms.CheckBox cb_df;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btn_sf;
    }
}

