namespace CWOC_Audio_Scheduler
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
            if (true)
            {
                ApplicationConfiguration.Initialize();
                Application.Run(new BasicFunctionForm());
            } else
            {
                WorkBench.RunTest();
            }
        }
    }
}