namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAdd = new Button();
            dataGridView1 = new DataGridView();
            txtFrequency = new TextBox();
            txtDate = new TextBox();
            txtStartTime = new TextBox();
            txtAmount = new TextBox();
            txtEndTime = new TextBox();
            txtUserName = new TextBox();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnAmountPerMinute = new Button();
            btnFilterByTime = new Button();
            txtFilterDate = new TextBox();
            txtFilterTimeFrom = new TextBox();
            txtFilterTimeTo = new TextBox();
            btnSearchMonthStats = new Button();
            txtMonthNumber = new TextBox();
            btnReset = new Button();
            btnFindSession = new Button();
            btnCreateMonthlyReport = new Button();
            btnChooseFilePath = new Button();
            btnCreateFilePath = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(835, 195);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += AddButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(792, 361);
            dataGridView1.TabIndex = 1;
            // 
            // txtFrequency
            // 
            txtFrequency.Location = new Point(826, 50);
            txtFrequency.Name = "txtFrequency";
            txtFrequency.PlaceholderText = "Frequency";
            txtFrequency.Size = new Size(100, 23);
            txtFrequency.TabIndex = 2;
            // 
            // txtDate
            // 
            txtDate.Location = new Point(826, 79);
            txtDate.Name = "txtDate";
            txtDate.PlaceholderText = "Date";
            txtDate.Size = new Size(100, 23);
            txtDate.TabIndex = 3;
            // 
            // txtStartTime
            // 
            txtStartTime.Location = new Point(826, 108);
            txtStartTime.Name = "txtStartTime";
            txtStartTime.PlaceholderText = "StartTime";
            txtStartTime.Size = new Size(100, 23);
            txtStartTime.TabIndex = 4;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(826, 166);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderText = "Amount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 5;
            // 
            // txtEndTime
            // 
            txtEndTime.Location = new Point(826, 137);
            txtEndTime.Name = "txtEndTime";
            txtEndTime.PlaceholderText = "EndTime";
            txtEndTime.Size = new Size(100, 23);
            txtEndTime.TabIndex = 6;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(826, 21);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "UserName";
            txtUserName.Size = new Size(100, 23);
            txtUserName.TabIndex = 7;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(835, 224);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += Update_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(835, 253);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += Delete_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(945, 21);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 10;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(957, 50);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += Searchbutton_Click;
            // 
            // btnAmountPerMinute
            // 
            btnAmountPerMinute.Location = new Point(810, 282);
            btnAmountPerMinute.Name = "btnAmountPerMinute";
            btnAmountPerMinute.Size = new Size(127, 23);
            btnAmountPerMinute.TabIndex = 12;
            btnAmountPerMinute.Text = "AmountPerMinute";
            btnAmountPerMinute.UseVisualStyleBackColor = true;
            btnAmountPerMinute.Click += AmountPerMinute_Click;
            // 
            // btnFilterByTime
            // 
            btnFilterByTime.Location = new Point(1060, 109);
            btnFilterByTime.Name = "btnFilterByTime";
            btnFilterByTime.Size = new Size(102, 23);
            btnFilterByTime.TabIndex = 13;
            btnFilterByTime.Text = "FilterByTime";
            btnFilterByTime.UseVisualStyleBackColor = true;
            btnFilterByTime.Click += FilterByTimeButton_Click;
            // 
            // txtFilterDate
            // 
            txtFilterDate.Location = new Point(1062, 21);
            txtFilterDate.Name = "txtFilterDate";
            txtFilterDate.PlaceholderText = "FilterDate";
            txtFilterDate.Size = new Size(100, 23);
            txtFilterDate.TabIndex = 14;
            // 
            // txtFilterTimeFrom
            // 
            txtFilterTimeFrom.Location = new Point(1062, 51);
            txtFilterTimeFrom.Name = "txtFilterTimeFrom";
            txtFilterTimeFrom.PlaceholderText = "FilterTimeFrom";
            txtFilterTimeFrom.Size = new Size(100, 23);
            txtFilterTimeFrom.TabIndex = 15;
            // 
            // txtFilterTimeTo
            // 
            txtFilterTimeTo.Location = new Point(1062, 80);
            txtFilterTimeTo.Name = "txtFilterTimeTo";
            txtFilterTimeTo.PlaceholderText = "FilterTimeTo";
            txtFilterTimeTo.Size = new Size(100, 23);
            txtFilterTimeTo.TabIndex = 16;
            // 
            // btnSearchMonthStats
            // 
            btnSearchMonthStats.Location = new Point(133, 408);
            btnSearchMonthStats.Name = "btnSearchMonthStats";
            btnSearchMonthStats.Size = new Size(126, 23);
            btnSearchMonthStats.TabIndex = 17;
            btnSearchMonthStats.Text = "SearchMonthStats";
            btnSearchMonthStats.UseVisualStyleBackColor = true;
            btnSearchMonthStats.Click += btnSearchMonthStats_Click;
            // 
            // txtMonthNumber
            // 
            txtMonthNumber.Location = new Point(143, 379);
            txtMonthNumber.Name = "txtMonthNumber";
            txtMonthNumber.PlaceholderText = "MonthNumber";
            txtMonthNumber.Size = new Size(100, 23);
            txtMonthNumber.TabIndex = 18;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(1074, 138);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 19;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnFindSession
            // 
            btnFindSession.Location = new Point(727, 379);
            btnFindSession.Name = "btnFindSession";
            btnFindSession.Size = new Size(77, 23);
            btnFindSession.TabIndex = 20;
            btnFindSession.Text = "FindSession";
            btnFindSession.UseVisualStyleBackColor = true;
            btnFindSession.Click += btnFindSession_Click;
            // 
            // btnCreateMonthlyReport
            // 
            btnCreateMonthlyReport.Location = new Point(592, 379);
            btnCreateMonthlyReport.Name = "btnCreateMonthlyReport";
            btnCreateMonthlyReport.Size = new Size(129, 23);
            btnCreateMonthlyReport.TabIndex = 21;
            btnCreateMonthlyReport.Text = "CreateMonthlyReport";
            btnCreateMonthlyReport.UseVisualStyleBackColor = true;
            btnCreateMonthlyReport.Click += btnCreateMonthlyReport_Click;
            // 
            // btnChooseFilePath
            // 
            btnChooseFilePath.Location = new Point(12, 408);
            btnChooseFilePath.Name = "btnChooseFilePath";
            btnChooseFilePath.Size = new Size(100, 23);
            btnChooseFilePath.TabIndex = 22;
            btnChooseFilePath.Text = "ChooseFilePath";
            btnChooseFilePath.UseVisualStyleBackColor = true;
            btnChooseFilePath.Click += btnChooseFilePath_Click;
            // 
            // btnCreateFilePath
            // 
            btnCreateFilePath.Location = new Point(12, 379);
            btnCreateFilePath.Name = "btnCreateFilePath";
            btnCreateFilePath.Size = new Size(100, 23);
            btnCreateFilePath.TabIndex = 23;
            btnCreateFilePath.Text = "CreateFilePath";
            btnCreateFilePath.UseVisualStyleBackColor = true;
            btnCreateFilePath.Click += btnCreateFilePath_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 456);
            Controls.Add(btnCreateFilePath);
            Controls.Add(btnChooseFilePath);
            Controls.Add(btnCreateMonthlyReport);
            Controls.Add(btnFindSession);
            Controls.Add(btnReset);
            Controls.Add(txtMonthNumber);
            Controls.Add(btnSearchMonthStats);
            Controls.Add(txtFilterTimeTo);
            Controls.Add(txtFilterTimeFrom);
            Controls.Add(txtFilterDate);
            Controls.Add(btnFilterByTime);
            Controls.Add(btnAmountPerMinute);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(txtUserName);
            Controls.Add(txtEndTime);
            Controls.Add(txtAmount);
            Controls.Add(txtStartTime);
            Controls.Add(txtDate);
            Controls.Add(txtFrequency);
            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private DataGridView dataGridView1;
        private TextBox txtFrequency;
        private TextBox txtDate;
        private TextBox txtStartTime;
        private TextBox txtAmount;
        private TextBox txtEndTime;
        private TextBox txtUserName;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnAmountPerMinute;
        private Button btnFilterByTime;
        private TextBox txtFilterDate;
        private TextBox txtFilterTimeFrom;
        private TextBox txtFilterTimeTo;
        private Button btnSearchMonthStats;
        private TextBox txtMonthNumber;
        private Button btnReset;
        private Button btnFindSession;
        private Button btnCreateMonthlyReport;
        private Button btnChooseFilePath;
        private Button btnCreateFilePath;
    }
}