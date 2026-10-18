namespace StudentRecordSystem
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lblTitle = new Label();
            lblStudentId = new Label();
            lblName = new Label();
            lblCourse = new Label();
            lblWam = new Label();
            txtStudentId = new TextBox();
            txtName = new TextBox();
            txtCourse = new TextBox();
            numWam = new NumericUpDown();
            btnAddStudent = new Button();
            btnTestSample = new Button();
            btnClear = new Button();
            btnExit = new Button();
            dgvStudents = new DataGridView();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnShowAll = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnStatistics = new Button();
            ((System.ComponentModel.ISupportInitialize)numWam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.MidnightBlue;
            lblTitle.Location = new Point(254, 29);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(538, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Student Record Management System";
            lblTitle.Click += lblTitle_Click;
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(56, 108);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(82, 20);
            lblStudentId.TabIndex = 1;
            lblStudentId.Text = "Student ID:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(56, 168);
            lblName.Name = "lblName";
            lblName.Size = new Size(107, 20);
            lblName.TabIndex = 2;
            lblName.Text = "Student Name:";
            // 
            // lblCourse
            // 
            lblCourse.AutoSize = true;
            lblCourse.Location = new Point(56, 233);
            lblCourse.Name = "lblCourse";
            lblCourse.Size = new Size(57, 20);
            lblCourse.TabIndex = 3;
            lblCourse.Text = "Course:";
            // 
            // lblWam
            // 
            lblWam.AutoSize = true;
            lblWam.Location = new Point(56, 300);
            lblWam.Name = "lblWam";
            lblWam.Size = new Size(48, 20);
            lblWam.TabIndex = 4;
            lblWam.Text = "WAM:";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(193, 108);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(125, 27);
            txtStudentId.TabIndex = 5;
            // 
            // txtName
            // 
            txtName.Location = new Point(193, 168);
            txtName.Name = "txtName";
            txtName.Size = new Size(300, 27);
            txtName.TabIndex = 6;
            // 
            // txtCourse
            // 
            txtCourse.Location = new Point(193, 233);
            txtCourse.Name = "txtCourse";
            txtCourse.Size = new Size(300, 27);
            txtCourse.TabIndex = 7;
            // 
            // numWam
            // 
            numWam.DecimalPlaces = 2;
            numWam.Location = new Point(193, 298);
            numWam.Name = "numWam";
            numWam.Size = new Size(125, 27);
            numWam.TabIndex = 8;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.SteelBlue;
            btnAddStudent.FlatStyle = FlatStyle.Flat;
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(28, 361);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(110, 35);
            btnAddStudent.TabIndex = 9;
            btnAddStudent.Text = "Add Student";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnTestSample
            // 
            btnTestSample.BackColor = Color.SteelBlue;
            btnTestSample.FlatStyle = FlatStyle.Flat;
            btnTestSample.ForeColor = Color.White;
            btnTestSample.Location = new Point(294, 361);
            btnTestSample.Name = "btnTestSample";
            btnTestSample.Size = new Size(100, 35);
            btnTestSample.TabIndex = 10;
            btnTestSample.Text = "Test Sample";
            btnTestSample.UseVisualStyleBackColor = false;
            btnTestSample.Click += btnTestSample_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.SteelBlue;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(423, 361);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 35);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnExit
            // 
            btnExit.ForeColor = Color.Red;
            btnExit.Location = new Point(839, 707);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 35);
            btnExit.TabIndex = 12;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(28, 502);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(911, 188);
            dgvStudents.TabIndex = 13;
            dgvStudents.SelectionChanged += dgvStudents_SelectionChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(56, 419);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(204, 20);
            lblSearch.TabIndex = 14;
            lblSearch.Text = "Search by ID, name or course:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(56, 457);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(260, 27);
            txtSearch.TabIndex = 15;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.DimGray;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(341, 453);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 35);
            btnSearch.TabIndex = 16;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnShowAll
            // 
            btnShowAll.BackColor = Color.DimGray;
            btnShowAll.FlatStyle = FlatStyle.Flat;
            btnShowAll.ForeColor = Color.Transparent;
            btnShowAll.Location = new Point(461, 453);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(100, 35);
            btnShowAll.TabIndex = 17;
            btnShowAll.Text = "Show All";
            btnShowAll.UseVisualStyleBackColor = false;
            btnShowAll.Click += btnShowAll_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.SteelBlue;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(170, 361);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 18;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(555, 361);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 19;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnStatistics
            // 
            btnStatistics.BackColor = Color.Maroon;
            btnStatistics.FlatStyle = FlatStyle.Flat;
            btnStatistics.ForeColor = Color.White;
            btnStatistics.Location = new Point(362, 707);
            btnStatistics.Name = "btnStatistics";
            btnStatistics.Size = new Size(100, 35);
            btnStatistics.TabIndex = 20;
            btnStatistics.Text = "Statistics";
            btnStatistics.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(982, 765);
            Controls.Add(btnStatistics);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnShowAll);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(dgvStudents);
            Controls.Add(btnExit);
            Controls.Add(btnClear);
            Controls.Add(btnTestSample);
            Controls.Add(btnAddStudent);
            Controls.Add(numWam);
            Controls.Add(txtCourse);
            Controls.Add(txtName);
            Controls.Add(txtStudentId);
            Controls.Add(lblWam);
            Controls.Add(lblCourse);
            Controls.Add(lblName);
            Controls.Add(lblStudentId);
            Controls.Add(lblTitle);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Student Record Management System\n";
            ((System.ComponentModel.ISupportInitialize)numWam).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblStudentId;
        private Label lblName;
        private Label lblCourse;
        private Label lblWam;
        private TextBox txtStudentId;
        private TextBox txtName;
        private TextBox txtCourse;
        private NumericUpDown numWam;
        private Button btnAddStudent;
        private Button btnTestSample;
        private Button btnClear;
        private Button btnExit;
        private DataGridView dgvStudents;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnShowAll;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnStatistics;
    }
}
