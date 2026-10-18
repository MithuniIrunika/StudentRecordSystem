using Microsoft.Data.Sqlite;
using System.ComponentModel;

namespace StudentRecordSystem
{
    public partial class Form1 : Form
    {
        // Holds the records displayed in the DataGridView.
        private readonly BindingList<Student> students =
            new();

        // Provides database operations without exposing SQLite
        // commands directly to the Windows Form.
        private readonly IStudentRepository repository;

        public Form1()
        {
            InitializeComponent();

            // Store the database in the user's local application
            // folder so records remain after rebuilding the project.
            string applicationFolder = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder
                        .LocalApplicationData),
                "StudentRecordSystem");

            Directory.CreateDirectory(applicationFolder);

            string databasePath = Path.Combine(
                applicationFolder,
                "studentrecords.db");

            repository =
                new StudentRepository(databasePath);

            ConfigureStudentGrid();

            // Event subscriptions added in code. The database is now
            // loaded in Form1_Load instead of the constructor so that
            // the window can appear before the data has been read.
            Load += Form1_Load;
            btnStatistics.Click += btnStatistics_Click;
            dgvStudents.CellFormatting += dgvStudents_CellFormatting;
        }

        // Runs when the form first opens. The async keyword allows
        // await to be used, so the window stays responsive while the
        // database is prepared on a background thread.
        private async void Form1_Load(
            object? sender,
            EventArgs e)
        {
            try
            {
                SetBusy(true);

                await Task.Run(
                    () => repository.InitializeDatabase());

                await LoadStudentsAsync();
            }
            catch (SqliteException exception)
            {
                ShowDatabaseError(exception);
            }
            finally
            {
                SetBusy(false);
            }
        }

        // Connects the DataGridView to the display list and
        // prevents users from editing database records directly.
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

        // Reads every student on a background thread using Task.Run.
        // After await, execution returns to the UI thread, so the
        // DataGridView can be updated safely.
        private async Task LoadStudentsAsync()
        {
            List<Student> records =
                await Task.Run(() => repository.GetAll());

            DisplayStudents(records);
        }

        // Replaces the rows shown in the DataGridView.
        private void DisplayStudents(
            IEnumerable<Student> records)
        {
            students.Clear();

            foreach (Student student in records)
            {
                students.Add(student);
            }
        }

        // Shows a wait cursor while a database operation is running.
        private void SetBusy(bool isBusy)
        {
            UseWaitCursor = isBusy;
        }

        // Validates the form input and creates a Student object.
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

            // UpdateWam performs the range validation.
            student.UpdateWam(numWam.Value);

            return student;
        }

        // Adds a validated student record to SQLite.
        private async void btnAddStudent_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Student student =
                    ReadStudentFromInputs();

                SetBusy(true);

                bool exists = await Task.Run(
                    () => repository.Exists(student.StudentId));

                if (exists)
                {
                    MessageBox.Show(
                        "This student ID already exists.",
                        "Duplicate Student",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtStudentId.Focus();
                    return;
                }

                await Task.Run(() => repository.Add(student));

                await LoadStudentsAsync();
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
            finally
            {
                SetBusy(false);
            }
        }

        // Displays records that contain the entered ID,
        // student name or course.
        private async void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            string searchText =
                txtSearch.Text.Trim();

            if (searchText.Length == 0)
            {
                ShowValidationError(
                    "Enter a student ID, name or course "
                    + "to search.");

                txtSearch.Focus();
                return;
            }

            try
            {
                SetBusy(true);

                List<Student> results = await Task.Run(
                    () => repository.Search(searchText));

                DisplayStudents(results);

                if (results.Count == 0)
                {
                    ShowInformation(
                        "No matching student records "
                        + "were found.");
                }
            }
            catch (SqliteException exception)
            {
                ShowDatabaseError(exception);
            }
            finally
            {
                SetBusy(false);
            }
        }

        // Clears the search and reloads every record.
        private async void btnShowAll_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                SetBusy(true);
                txtSearch.Clear();
                await LoadStudentsAsync();
            }
            catch (SqliteException exception)
            {
                ShowDatabaseError(exception);
            }
            finally
            {
                SetBusy(false);
            }
        }

        // Updates the student with the ID entered in the form.
        private async void btnUpdate_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Student student =
                    ReadStudentFromInputs();

                SetBusy(true);

                bool updated = await Task.Run(
                    () => repository.Update(student));

                if (!updated)
                {
                    ShowValidationError(
                        "No student exists with this "
                        + "student ID.");

                    return;
                }

                await LoadStudentsAsync();
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
            finally
            {
                SetBusy(false);
            }
        }

        // Requests confirmation before deleting a record.
        private async void btnDelete_Click(
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
                SetBusy(true);

                bool deleted = await Task.Run(
                    () => repository.Delete(studentId));

                if (!deleted)
                {
                    ShowValidationError(
                        "The selected student no longer "
                        + "exists.");

                    return;
                }

                await LoadStudentsAsync();
                ClearInputs();

                ShowInformation(
                    "Student record deleted successfully.");
            }
            catch (SqliteException exception)
            {
                ShowDatabaseError(exception);
            }
            finally
            {
                SetBusy(false);
            }
        }

        // Uses LINQ to summarise every record in the database.
        // Lambda expressions such as student => student.Wam tell
        // each LINQ method which value to use.
        private async void btnStatistics_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                SetBusy(true);

                List<Student> allStudents =
                    await Task.Run(() => repository.GetAll());

                if (allStudents.Count == 0)
                {
                    ShowInformation(
                        "There are no student records "
                        + "to summarise.");

                    return;
                }

                decimal averageWam =
                    allStudents.Average(student => student.Wam);

                int atRiskCount =
                    allStudents.Count(student => !student.HasPassed);

                // MaxBy returns a nullable result, so ? is used
                // when reading its properties.
                Student? topStudent =
                    allStudents.MaxBy(student => student.Wam);

                // Groups students by course and builds one
                // summary line for each course.
                IEnumerable<string> courseSummaries = allStudents
                    .GroupBy(student => student.Course)
                    .OrderBy(group => group.Key)
                    .Select(group =>
                        $"  {group.Key}: {group.Count()} student(s), "
                        + $"average WAM {group.Average(student => student.Wam):0.00}");

                string newLine = Environment.NewLine;

                string message =
                    $"Total students: {allStudents.Count}{newLine}"
                    + $"Average WAM: {averageWam:0.00}{newLine}"
                    + $"Students at risk: {atRiskCount}{newLine}"
                    + $"Highest WAM: {topStudent?.Name} "
                    + $"({topStudent?.Wam:0.00}){newLine}{newLine}"
                    + $"By course:{newLine}"
                    + string.Join(newLine, courseSummaries);

                MessageBox.Show(
                    message,
                    "Student Statistics",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (SqliteException exception)
            {
                ShowDatabaseError(exception);
            }
            finally
            {
                SetBusy(false);
            }
        }

        // Runs for every cell before it is drawn. Rows for students
        // who are at risk are highlighted, and the WAM column is
        // shown with two decimal places.
        private void dgvStudents_CellFormatting(
            object? sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.CellStyle is null)
            {
                return;
            }

            if (dgvStudents.Rows[e.RowIndex].DataBoundItem
                is not Student student)
            {
                return;
            }

            if (!student.HasPassed)
            {
                e.CellStyle.BackColor = Color.MistyRose;
                e.CellStyle.ForeColor = Color.DarkRed;
            }

            if (dgvStudents.Columns[e.ColumnIndex].DataPropertyName
                    == nameof(Student.Wam)
                && e.Value is decimal wam)
            {
                e.Value = wam.ToString("0.00");
                e.FormattingApplied = true;
            }
        }

        // Copies the selected row into the input controls so
        // the record can be updated or deleted.
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

        // Places sample values in the controls for demonstration.
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

        // Clears the student input controls without deleting data.
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

        // Displays database errors without terminating
        // the entire application.
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

        // This method remains because the original Designer
        // connected the title label's Click event to it.
        private void lblTitle_Click(
            object sender,
            EventArgs e)
        {
            // No action is required.
        }
    }
}