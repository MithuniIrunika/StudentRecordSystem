using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace StudentRecordSystem
{
    public partial class Form1 : Form
    {
        private readonly BindingList<Student> students = new();

        public Form1()
        {
            InitializeComponent();
            ConfigureStudentGrid();
        }

        private void ConfigureStudentGrid()
        {
            dgvStudents.AutoGenerateColumns = true;
            dgvStudents.DataSource = students;
            dgvStudents.ReadOnly = true;
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;

            dgvStudents.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvStudents.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAddStudent_Click(
            object sender,
            EventArgs e)
        {
            if (!int.TryParse(txtStudentId.Text, out int studentId))
            {
                MessageBox.Show(
                    "Enter a valid numeric student ID.",
                    "Invalid Student ID",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtStudentId.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(
                    "Enter the student's name.",
                    "Missing Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCourse.Text))
            {
                MessageBox.Show(
                    "Enter the course name.",
                    "Missing Course",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCourse.Focus();
                return;
            }

            bool duplicateId = students.Any(
                student => student.StudentId == studentId);

            if (duplicateId)
            {
                MessageBox.Show(
                    "This student ID already exists.",
                    "Duplicate Student",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtStudentId.Focus();
                return;
            }

            Student student = new Student
            {
                StudentId = studentId,
                Name = txtName.Text.Trim(),
                Course = txtCourse.Text.Trim()
            };

            student.UpdateWam(numWam.Value);
            students.Add(student);

            MessageBox.Show(
                "The student was added successfully.",
                "Student Added",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ClearInputs();
        }

        private void btnTestSample_Click(
            object sender,
            EventArgs e)
        {
            txtStudentId.Text = "1001";
            txtName.Text = "Mithuni";
            txtCourse.Text = "Bachelor of Computer Science";
            numWam.Value = 75m;
        }

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearInputs();
        }

        private void btnExit_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }

        private void ClearInputs()
        {
            txtStudentId.Clear();
            txtName.Clear();
            txtCourse.Clear();
            numWam.Value = 0m;
            txtStudentId.Focus();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}