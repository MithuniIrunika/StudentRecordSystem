using Microsoft.Data.Sqlite;
using System.ComponentModel;

namespace StudentRecordSystem
{
    public partial class Form1 : Form
    {
        private readonly BindingList<Student> students = new();
        private readonly IStudentRepository repository;

        public Form1()
        {
            InitializeComponent();

            string applicationFolder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "StudentRecordSystem");

            Directory.CreateDirectory(applicationFolder);

            string databasePath = Path.Combine(
                applicationFolder,
                "studentrecords.db");

            repository = new StudentRepository(databasePath);

            ConfigureStudentGrid();

            try
            {
                repository.InitializeDatabase();
                LoadStudents();
            }
            catch (SqliteException exception)
            {
                ShowDatabaseError(exception);
            }
        }

        private void ConfigureStudentGrid()
        {
            dgvStudents.AutoGenerateColumns = true;
            dgvStudents.DataSource = students;
            dgvStudents.ReadOnly = true;
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.MultiSelect = false;

            dgvStudents.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvStudents.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadStudents(
            IEnumerable<Student>? records = null)
        {
            students.Clear();

            IEnumerable<Student> recordsToDisplay =
                records ?? repository.GetAll();

            foreach (Student student in recordsToDisplay)
            {
                students.Add(student);
            }
        }

        private Student ReadStudentFromInputs()
        {
            if (!int.TryParse(
                txtStudentId.Text.Trim(),
                out int studentId) ||
                studentId <= 0)
            {
                throw new ArgumentException(
                    "Enter a positive numeric student ID.");
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                throw new ArgumentException(
                    "Enter the student's name.");
            }

            if (string.IsNullOrWhiteSpace(txtCourse.Text))
            {
                throw new ArgumentException(
                    "Enter the course name.");
            }

            Student student = new Student
            {
                StudentId = studentId,
                Name = txtName.Text.Trim(),
                Course = txtCourse.Text.Trim()
            };

            student.UpdateWam(numWam.Value);

            return student;
        }

        private void btnAddStudent_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Student student =
                    ReadStudentFromInputs();

                if (repository.Exists(student.StudentId))
                {
                    MessageBox.Show(
                        "This student ID already exists.",
                        "Duplicate Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtStudentId.Focus();
                    return;
                }

                repository.Add(student);
                LoadStudents();
                ClearInputs();

                ShowInformation(
                    "Student record added successfully.");
            }
            catch (ArgumentException exception)
            {
                ShowValidationError(exception.Message);
            }
            catch (SqliteException exception)
            {
                ShowDatabaseError(exception);
            }
        }

        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            string searchText =
                txtSearch.Text.Trim();

            if (searchText.Length == 0)
            {
                ShowValidationError(
                    "Enter a student ID, name or course to search.");

                txtSearch.Focus();
                return;
            }

            try
            {
                List<Student> results =
                    repository.Search(searchText);

                LoadStudents(results);

                if (results.Count == 0)
                {
                    ShowInformation(
                        "No matching student records were found.");
                }
            }
            catch (SqliteException exception)
            {
                ShowDatabaseError(exception);
            }
        }

        private void btnShowAll_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                txtSearch.Clear();
                LoadStudents();
            }
            catch (SqliteException exception)
            {
                ShowDatabaseError(exception);
            }
        }

        private void btnUpdate_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Student student =
                    ReadStudentFromInputs();

                bool updated =
                    repository.Update(student);

                if (!updated)
                {
                    ShowValidationError(
                        "No student exists with this student ID.");

                    return;
                }

                LoadStudents();
                ClearInputs();

                ShowInformation(
                    "Student record updated successfully.");
            }
            catch (ArgumentException exception)
            {
                ShowValidationError(exception.Message);
            }
            catch (SqliteException exception)
            {
                ShowDatabaseError(exception);
            }
        }

        private void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            if (!int.TryParse(
                txtStudentId.Text.Trim(),
                out int studentId))
            {
                ShowValidationError(
                    "Select a student record to delete.");

                return;
            }

            DialogResult confirmation =
                MessageBox.Show(
                    "Are you sure you want to delete "
                    + "this student record?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes)
            {
                return;
            }

            try
            {
                bool deleted =
                    repository.Delete(studentId);

                if (!deleted)
                {
                    ShowValidationError(
                        "The selected student no longer exists.");

                    return;
                }

                LoadStudents();
                ClearInputs();

                ShowInformation(
                    "Student record deleted successfully.");
            }
            catch (SqliteException exception)
            {
                ShowDatabaseError(exception);
            }
        }

        private void dgvStudents_SelectionChanged(
            object sender,
            EventArgs e)
        {
            if (dgvStudents.CurrentRow?.DataBoundItem
                is not Student selectedStudent)
            {
                return;
            }

            txtStudentId.Text =
                selectedStudent.StudentId.ToString();

            txtName.Text =
                selectedStudent.Name;

            txtCourse.Text =
                selectedStudent.Course;

            numWam.Value =
                selectedStudent.Wam;
        }

        private void btnTestSample_Click(
            object sender,
            EventArgs e)
        {
            txtStudentId.Text = "1001";
            txtName.Text = "Mithuni";

            txtCourse.Text =
                "Bachelor of Computer Science";

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

            dgvStudents.ClearSelection();
            txtStudentId.Focus();
        }

        private static void ShowValidationError(
            string message)
        {
            MessageBox.Show(
                message,
                "Invalid Input",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private static void ShowInformation(
            string message)
        {
            MessageBox.Show(
                message,
                "Student Record System",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private static void ShowDatabaseError(
            SqliteException exception)
        {
            MessageBox.Show(
                "The database operation could not be completed."
                + Environment.NewLine
                + Environment.NewLine
                + exception.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void lblTitle_Click(
            object sender,
            EventArgs e)
        {
            // No action is required when the title is clicked.
        }
    }
}