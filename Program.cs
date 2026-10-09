namespace StudentRecordSystem
{
    internal static class Program
    {
        // Main entry point for the Windows Forms application.
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.Run(new Form1());
        }
    }
}