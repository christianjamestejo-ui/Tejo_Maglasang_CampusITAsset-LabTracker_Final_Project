using System;
using System.IO;

namespace MT_Campus_IT_Asset___Lab_Tracker.Functions
{
    public static class DataDirectory
    {
        public static string Resolve()
        {
            // Get the solution/project data directory.
            string baseDirectory =
                AppContext.BaseDirectory;

            // Go up from bin/Debug/net8.0
            string projectDirectory = Path.GetFullPath(
                Path.Combine(baseDirectory, "..", "..", "..")
            );

            // Create the Data folder if it doesn't exist.
            string dataDirectory = Path.Combine(
                projectDirectory,
                "Data"
            );

            Directory.CreateDirectory(dataDirectory);

            return dataDirectory;
        }
    }
}