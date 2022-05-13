namespace IRacingSpeedTrainer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            if (!Directory.Exists(GetDirPath()))
            {
                Directory.CreateDirectory(GetDirPath());
            }
            Application.Run(new MainForm());
        }
        public static string GetDirPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "iRacing Speed Trainer");
        }
    }
}