namespace StudentRecordSystem
{
    // Stores one student's personal and academic information.
    public sealed class Student
    {
        public int StudentId { get; init; }

        public string Name { get; init; } =
            string.Empty;

        public string Course { get; init; } =
            string.Empty;

        // The WAM can only be changed through UpdateWam.
        public decimal Wam { get; private set; }

        // A WAM of at least 50 is considered a pass.
        public bool HasPassed =>
            Wam >= 50m;

        // Calculates the student's status from the current WAM.
        public string AcademicStatus =>
            HasPassed ? "Good Standing" : "At Risk";

        // Validates the value before updating the WAM.
        public void UpdateWam(decimal newWam)
        {
            if (newWam < 0m || newWam > 100m)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(newWam),
                    "WAM must be between 0 and 100.");
            }

            Wam = newWam;
        }
    }
}