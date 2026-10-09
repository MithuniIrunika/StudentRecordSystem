using Microsoft.Data.Sqlite;

namespace StudentRecordSystem
{
    // Implements student database operations using SQLite.
    // Parameterised SQL keeps user input separate from SQL commands.
    public sealed class StudentRepository
        : IStudentRepository
    {
        private readonly string connectionString;

        public StudentRepository(string databasePath)
        {
            connectionString =
                $"Data Source={databasePath}";
        }

        // Creates the Students table automatically when the
        // application runs for the first time.
        public void InitializeDatabase()
        {
            using SqliteConnection connection =
                new SqliteConnection(connectionString);

            connection.Open();

            const string sql = """
                CREATE TABLE IF NOT EXISTS Students
                (
                    StudentId INTEGER PRIMARY KEY,
                    Name TEXT NOT NULL,
                    Course TEXT NOT NULL,
                    Wam REAL NOT NULL
                        CHECK (Wam >= 0 AND Wam <= 100)
                );
                """;

            using SqliteCommand command =
                new SqliteCommand(sql, connection);

            command.ExecuteNonQuery();
        }

        // Retrieves every student in student-ID order.
        public List<Student> GetAll()
        {
            List<Student> students =
                new List<Student>();

            using SqliteConnection connection =
                new SqliteConnection(connectionString);

            connection.Open();

            const string sql = """
                SELECT StudentId, Name, Course, Wam
                FROM Students
                ORDER BY StudentId;
                """;

            using SqliteCommand command =
                new SqliteCommand(sql, connection);

            using SqliteDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                students.Add(CreateStudent(reader));
            }

            return students;
        }

        // Searches by student ID, name or course.
        public List<Student> Search(string searchText)
        {
            List<Student> students =
                new List<Student>();

            using SqliteConnection connection =
                new SqliteConnection(connectionString);

            connection.Open();

            const string sql = """
                SELECT StudentId, Name, Course, Wam
                FROM Students
                WHERE CAST(StudentId AS TEXT) LIKE $search
                   OR Name LIKE $search
                   OR Course LIKE $search
                ORDER BY StudentId;
                """;

            using SqliteCommand command =
                new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue(
                "$search",
                $"%{searchText.Trim()}%");

            using SqliteDataReader reader =
                command.ExecuteReader();

            while (reader.Read())
            {
                students.Add(CreateStudent(reader));
            }

            return students;
        }

        // Checks for an existing student ID before insertion.
        public bool Exists(int studentId)
        {
            using SqliteConnection connection =
                new SqliteConnection(connectionString);

            connection.Open();

            const string sql = """
                SELECT COUNT(1)
                FROM Students
                WHERE StudentId = $studentId;
                """;

            using SqliteCommand command =
                new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue(
                "$studentId",
                studentId);

            object? result =
                command.ExecuteScalar();

            return Convert.ToInt32(result) > 0;
        }

        // Inserts a new student into the database.
        public void Add(Student student)
        {
            using SqliteConnection connection =
                new SqliteConnection(connectionString);

            connection.Open();

            const string sql = """
                INSERT INTO Students
                    (StudentId, Name, Course, Wam)
                VALUES
                    ($studentId, $name, $course, $wam);
                """;

            using SqliteCommand command =
                new SqliteCommand(sql, connection);

            AddStudentParameters(command, student);

            command.ExecuteNonQuery();
        }

        // Updates the record identified by StudentId.
        public bool Update(Student student)
        {
            using SqliteConnection connection =
                new SqliteConnection(connectionString);

            connection.Open();

            const string sql = """
                UPDATE Students
                SET Name = $name,
                    Course = $course,
                    Wam = $wam
                WHERE StudentId = $studentId;
                """;

            using SqliteCommand command =
                new SqliteCommand(sql, connection);

            AddStudentParameters(command, student);

            return command.ExecuteNonQuery() == 1;
        }

        // Deletes the record identified by StudentId.
        public bool Delete(int studentId)
        {
            using SqliteConnection connection =
                new SqliteConnection(connectionString);

            connection.Open();

            const string sql = """
                DELETE FROM Students
                WHERE StudentId = $studentId;
                """;

            using SqliteCommand command =
                new SqliteCommand(sql, connection);

            command.Parameters.AddWithValue(
                "$studentId",
                studentId);

            return command.ExecuteNonQuery() == 1;
        }

        // Converts the current database row into a Student object.
        private static Student CreateStudent(
            SqliteDataReader reader)
        {
            Student student = new Student
            {
                StudentId = reader.GetInt32(0),
                Name = reader.GetString(1),
                Course = reader.GetString(2)
            };

            decimal wam =
                Convert.ToDecimal(reader.GetDouble(3));

            student.UpdateWam(wam);

            return student;
        }

        // Adds student values as parameters to an SQL command.
        // Parameters avoid placing user input directly in SQL.
        private static void AddStudentParameters(
            SqliteCommand command,
            Student student)
        {
            command.Parameters.AddWithValue(
                "$studentId",
                student.StudentId);

            command.Parameters.AddWithValue(
                "$name",
                student.Name);

            command.Parameters.AddWithValue(
                "$course",
                student.Course);

            command.Parameters.AddWithValue(
                "$wam",
                student.Wam);
        }
    }
}