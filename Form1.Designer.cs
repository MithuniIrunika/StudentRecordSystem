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
            ((System.ComponentModel.ISupportInitialize)numWam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F);
            lblTitle.Location = new Point(254, 29);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(423, 35);
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
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 6;
            // 
            // txtCourse
            // 
            txtCourse.Location = new Point(193, 233);
            txtCourse.Name = "txtCourse";
            txtCourse.Size = new Size(125, 27);
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
            btnAddStudent.Location = new Point(28, 361);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(110, 29);
            btnAddStudent.TabIndex = 9;
            btnAddStudent.Text = "Add Student";
            btnAddStudent.UseVisualStyleBackColor = true;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnTestSample
            // 
            btnTestSample.Location = new Point(171, 361);
            btnTestSample.Name = "btnTestSample";
            btnTestSample.Size = new Size(111, 29);
            btnTestSample.TabIndex = 10;
            btnTestSample.Text = "Test Sample";
            btnTestSample.UseVisualStyleBackColor = true;
            btnTestSample.Click += btnTestSample_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(326, 361);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 11;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(463, 361);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
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
            dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudents.Location = new Point(28, 415);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(774, 188);
            dgvStudents.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 616);
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
    }
}
