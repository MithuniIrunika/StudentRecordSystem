using System;

namespace StudentRecordSystem
{
    public sealed class Student
    {
        public int StudentId { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Course { get; init; } = string.Empty;
        public decimal Wam { get; private set; }
        public bool HasPassed => Wam >= 50m;
        public string AcademicStatus =>
            HasPassed ? "Good Standing" : "At Risk";
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