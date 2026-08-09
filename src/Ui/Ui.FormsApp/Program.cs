namespace codingfreaks.obscene.Ui.FormsApp
{
    internal static class Program
    {
        #region constants

        private static Mutex? _singleRunMutex;

        #endregion

        #region methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static int Main()
        {
            _singleRunMutex = new Mutex(true, @"Global\codingfreaks.obscene", out var createdNew);
            if (!createdNew)
            {
                MessageBox.Show("Another instance of obscene is already running.");
                return 1;
            }
            _singleRunMutex.WaitOne();
            try
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new MainForm());
            }
            finally
            {
                _singleRunMutex.ReleaseMutex();
            }
            return 0;
        }

        #endregion
    }
}
