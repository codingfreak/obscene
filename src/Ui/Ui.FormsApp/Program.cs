namespace codingfreaks.obscene.Ui.FormsApp
{
    internal static class Program
    {
        #region methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }

        #endregion
    }
}
