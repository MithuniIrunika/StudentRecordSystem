namespace StudentRecordSystem
{
    public interface IStudentRepository
    {
        void InitializeDatabase();

        List<Student> GetAll();

        List<Student> Search(string searchText);

        bool Exists(int studentId);

        void Add(Student student);

        bool Update(Student student);

        bool Delete(int studentId);
    }
}