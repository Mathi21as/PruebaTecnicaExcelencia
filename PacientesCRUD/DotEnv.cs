namespace PacientesCRUD
{
    using System;
    using System.IO;

    public static class DotEnv
    {
        static string filePath = "/.env.local";
        public static void Load()
        {
            if (!File.Exists(filePath))
                return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('=', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                    continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }
    }
}