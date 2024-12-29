using System;
using System.Collections.Generic;
using System.IO;

namespace Silvers_ToDo_List
{
    public class TaskManager
    {
        private readonly string baseDirectory;

        public TaskManager()
        {
            // Define a directory to save tasks (can be adjusted as needed)
            baseDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SilversToDoLists");
            Directory.CreateDirectory(baseDirectory); // Ensure the directory exists
        }

        public string GetFilePath(string gameName)
        {
            return Path.Combine(baseDirectory, $"{gameName}.txt");
        }

        // Save tasks to the file corresponding to the selected game
        public void SaveTasks(string gameName, List<string> tasks)
        {
            string filePath = GetFilePath(gameName);
            File.WriteAllLines(filePath, tasks);
        }

        // Load tasks from the file corresponding to the selected game
        public List<string> LoadTasks(string gameName)
        {
            string filePath = GetFilePath(gameName);
            if (File.Exists(filePath))
            {
                return new List<string>(File.ReadAllLines(filePath));
            }
            return new List<string>(); // Return an empty list if no file exists
        }
    }
}
