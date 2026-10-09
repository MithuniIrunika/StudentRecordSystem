using Microsoft.Data.Sqlite;

namespace StudentRecordSystem
{
    public sealed class StudentRepository
    : IStudentRepository
    {
        private readonly string connectionString;

        public StudentRepository(string databasePath)
        {
            connectionString = $"Data Source={databasePath}";
        }

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

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();

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

            using SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                students.Add(CreateStudent(reader));
            }

            return students;
        }

        public List<Student> Search(string searchText)
        {
            List<Student> students = new List<Student>();

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

            using SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                students.Add(CreateStudent(reader));
            }

            return students;
        }

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

            object? result = command.ExecuteScalar();

            return Convert.ToInt32(result) > 0;
        }

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